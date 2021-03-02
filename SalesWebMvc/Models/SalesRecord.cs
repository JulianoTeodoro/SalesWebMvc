using SalesWebMvc.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class SalesRecord
    {

        public int ID { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SaleStatus status { get; set; }

        public SalesRecord(int iD, DateTime date, double amount, SaleStatus status)
        {
            ID = iD;
            Date = date;
            Amount = amount;
            this.status = status;
        }
    }
}
