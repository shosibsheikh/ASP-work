using System.ComponentModel.DataAnnotations;

namespace CrudAppADO.Models
{
    public class Employees
    {
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public string city {  get; set; }

    }
}
