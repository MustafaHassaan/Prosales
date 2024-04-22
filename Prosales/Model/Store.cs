using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosales.Model
{
    public class Store
    {
        public int Id { get; set; }
        public string Storename { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User user { get; set; }
    }
}
