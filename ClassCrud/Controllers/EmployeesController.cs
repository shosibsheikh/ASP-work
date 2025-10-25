using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using ClassCrud.Models;

namespace ClassCrud.Controllers
{
    public class EmployeesController : Controller
    {
        string cs = ConfigurationManager.ConnectionStrings["testdbConnection"].ConnectionString;
        // GET: Employees
        public ActionResult Index()
        {
            List<Employees> emp = new List<Employees>();
            SqlConnection con = new SqlConnection(cs);

            string query = "SELECT * from Employees"; // Id, Name, Email, Salary
            SqlCommand queryRun = new SqlCommand(query, con);

            con.Open();
            SqlDataReader fetch = queryRun.ExecuteReader();

            while (fetch.Read())
            {
                emp.Add(new Employees()
                {
                    Id = Convert.ToInt32(fetch["Id"]),
                    Name = fetch["Name"].ToString(),
                    Email = fetch["Email"].ToString(),
                    Salary = Convert.ToInt32(fetch["Salary"])
                });
            }

            
            return View(emp);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {
            Employees emp = new Employees();
            SqlConnection con = new SqlConnection(cs);

            string query = "SELECT * FROM Employees WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();
            SqlDataReader fetch = cmd.ExecuteReader();

            if (fetch.Read())
            {
                emp.Id = Convert.ToInt32(fetch["Id"]);
                emp.Name = fetch["Name"].ToString();
                emp.Email = fetch["Email"].ToString();
                emp.Salary = Convert.ToInt32(fetch["Salary"]);
            }

            con.Close();
            return View(emp);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(Employees emp)
        {
            SqlConnection con = new SqlConnection(cs);
            string qurey = "INSERT into Employees(Name, Email, Salary) Values(@Name ,@Email ,@Salary)";
            SqlCommand qureyRun = new SqlCommand(qurey, con);
            con.Open();

            qureyRun.Parameters.AddWithValue("Name", emp.Name);
            qureyRun.Parameters.AddWithValue("Email", emp.Email);
            qureyRun.Parameters.AddWithValue("Salary", emp.Salary);

            qureyRun.ExecuteNonQuery();
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            Employees emp = new Employees();
            SqlConnection con = new SqlConnection(cs);

            string query = "SELECT * FROM Employees WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();
            SqlDataReader fetch = cmd.ExecuteReader();

            if (fetch.Read())
            {
                emp.Id = Convert.ToInt32(fetch["Id"]);
                emp.Name = fetch["Name"].ToString();
                emp.Email = fetch["Email"].ToString();
                emp.Salary = Convert.ToInt32(fetch["Salary"]);
            }

            con.Close();
            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit(Employees emp)
        {
            SqlConnection con = new SqlConnection(cs);

            string query = "UPDATE Employees SET Name=@Name, Email=@Email, Salary=@Salary WHERE Id=@Id";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Id", emp.Id);
            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@Email", emp.Email);
            cmd.Parameters.AddWithValue("@Salary", emp.Salary);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            return RedirectToAction("Index");
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            Employees emp = new Employees();
            SqlConnection con = new SqlConnection(cs);

            string query = "SELECT * FROM Employees WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();
            SqlDataReader fetch = cmd.ExecuteReader();

            if (fetch.Read())
            {
                emp.Id = Convert.ToInt32(fetch["Id"]);
                emp.Name = fetch["Name"].ToString();
                emp.Email = fetch["Email"].ToString();
                emp.Salary = Convert.ToInt32(fetch["Salary"]);
            }

            con.Close();
            return View(emp);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            SqlConnection con = new SqlConnection(cs);

            string query = "DELETE FROM Employees WHERE Id=@Id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            return RedirectToAction("Index");
        }
    }
}
