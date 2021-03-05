using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int ID { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O tamanho do nome tem que ser entre 3 e 60")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [Range(100.0, 50000.00, ErrorMessage = "{0} must be from {1} to {2}")]
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public int DepartmentID { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {

        }
        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            ID = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void addSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void removeSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double totalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }


    }
}
