﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosales.Model
{
    public class Sold
    {
        public int Id { get; set; }
        public string Productname { get; set; }
        public string Billnumber { get; set; }
        public string Productnumber { get; set; }
        public string Flages { get; set; }
        public decimal Endprice { get; set; }
        public int Quantity { get; set; }
        public decimal Tottal { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public int UserId { get; set; }
        public int UnitId { get; set; }
        public int StorId { get; set; }
        public int CashId { get; set; }

        [ForeignKey("CategoryId")]
        public Category categories { get; set; }

        [ForeignKey("SupplierId")]
        public Supplier supplier { get; set; }

        [ForeignKey("UserId")]
        public User user { get; set; }

        [ForeignKey("UnitId")]
        public Unit unit { get; set; }

        [ForeignKey("StorId")]
        public Store store { get; set; }

        [ForeignKey("CashId")]
        public Cash cash { get; set; }
    }
}
