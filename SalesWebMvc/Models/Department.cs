using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models.ViewModels;

namespace SalesWebMvc.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department()
        {

        }

        public Department(int iD, string name)
        {
            ID = iD;
            Name = name;
        }

        public void addSeller(Seller sr)
        {
            Sellers.Add(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.totalSales(initial, final));
        }

    }
}
