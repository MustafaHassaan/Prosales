using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosales.Model
{
    public class PSR
    {
        public int Id { get; set; }
        public string Productname { get; set; }
        public string Flages { get; set; }
        public string Time { get; set; }
        public DateTime Date { get; set; }
        public decimal Startprice { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public int UserId { get; set; }
        public int UnitId { get; set; }
        public int StorId { get; set; }

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
    }
}
