using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosales.Model
{
    public class Supplier
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string Phone { get; set; }
        public string AtherPhone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int TSId { get; set; }
        public int UserId { get; set; }

        [ForeignKey("TSId")]
        public TOSupplier tosupplier { get; set; }

        [ForeignKey("UserId")]
        public User user { get; set; }
    }
}
