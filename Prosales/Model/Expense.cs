using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosales.Model
{
    public class Expense
    {
        public int Id { get; set; }
        public decimal Quantity { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User user { get; set; }
    }
}
