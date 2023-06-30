using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practical_11_1.Models
{
    public class Employees
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string Address { get; set; }
    }
}