using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosales.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string Customername { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AnotherPhone { get; set; }
        public string Address { get; set; }
        public int Tcustid { get; set; }
        public int UserId { get; set; }

        [ForeignKey("Tcustid")]
        public TOCustomer toCustomer { get; set; }

        [ForeignKey("UserId")]
        public User user { get; set; }
    }
}
