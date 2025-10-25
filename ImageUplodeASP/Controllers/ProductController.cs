using ImageUplodeASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ImageUplodeASP.Controllers
{
    public class ProductController : Controller
    {
        ImagedbContext context;
        IWebHostEnvironment env;
        public ProductController(ImagedbContext context, IWebHostEnvironment env)
        {
            this.context = context;
            this.env = env;
        }
        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View(context.Products.ToList());
        }
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(ProductViewModel prod)
        {
            string fileName = "";
            if (prod.photo != null)
            {
                var ext = Path.GetExtension(prod.photo.FileName);
                var size = prod.photo.Length;
                if (ext.Equals(".png") || ext.Equals(".jpg") || ext.Equals(".jpeg"))
                {
                    if (size <= 1000000)
                    {
                        string folder = Path.Combine(env.WebRootPath, "images");
                        fileName = Guid.NewGuid().ToString() + "_" + prod.photo.FileName;
                        string filePath = Path.Combine(folder, fileName);
                        prod.photo.CopyTo(new FileStream(filePath, FileMode.Create));

                        Product p = new Product()
                        {
                            Name = prod.Name,
                            Price = prod.Price,
                            ImagePath = fileName

                        };
                        context.Products.Add(p);
                        context.SaveChanges();
                        TempData["Success"] = "Added Product";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Size_Error"] = "Image size only 1MB";
                    }
                }
                else
                {
                    TempData["Ext_Error"] = "Allowed only Png,Jpg,Jpeg";
                }
            }
            return View();
        }
        public IActionResult Edit(int id)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            ProductViewModel prodVM = new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ExistingImagePath = product.ImagePath
            };

            return View(prodVM);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel prod)
        {
            var product = context.Products.Find(prod.Id);
            if (product == null)
            {
                return NotFound();
            }


            if (prod.photo != null)
            {
                var ext = Path.GetExtension(prod.photo.FileName);
                var size = prod.photo.Length;

                if (ext.Equals(".png", StringComparison.OrdinalIgnoreCase)
                    || ext.Equals(".jpg", StringComparison.OrdinalIgnoreCase)
                    || ext.Equals(".jpeg", StringComparison.OrdinalIgnoreCase))
                {
                    if (size <= 1000000)
                    {
                        string folder = Path.Combine(env.WebRootPath, "images");
                        string fileName = Guid.NewGuid().ToString() + "_" + prod.photo.FileName;
                        string filePath = Path.Combine(folder, fileName);

                        //  Save new image with using (auto close stream)
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            prod.photo.CopyTo(stream);
                        }

                        //  delete old image
                        if (!string.IsNullOrEmpty(product.ImagePath))
                        {
                            string oldImagePath = Path.Combine(folder, product.ImagePath);
                            //if (System.IO.File.Exists(oldImagePath))
                            //{
                            //    System.IO.File.Delete(oldImagePath);
                            //}
                        }

                        product.ImagePath = fileName;
                    }
                    else
                    {
                        TempData["Size_Error"] = "Image size only 1MB";
                        return View(prod);
                    }
                }
                else
                {
                    TempData["Ext_Error"] = "Allowed only Png, Jpg, Jpeg";
                    return View(prod);
                }
            }

            // Update other fields
            product.Name = prod.Name;
            product.Price = prod.Price;

            context.Products.Update(product);
            context.SaveChanges();

            TempData["Success"] = "Product Updated Successfully";
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            ProductViewModel prodVM = new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ExistingImagePath = product.ImagePath
            };

            return View(prodVM);
        }
        public IActionResult Delete(int id)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            ProductViewModel prodVM = new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ExistingImagePath = product.ImagePath
            };

            return View(prodVM);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            // delete image from folder
            if (!string.IsNullOrEmpty(product.ImagePath))
            {
                string folder = Path.Combine(env.WebRootPath, "images");
                string oldImagePath = Path.Combine(folder, product.ImagePath);
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }

            context.Products.Remove(product);
            context.SaveChanges();

            TempData["Success"] = "Product Deleted Successfully";
            return RedirectToAction("Index");
        }


    }
}
