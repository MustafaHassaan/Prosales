using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosales.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Phonenumber { get; set; }
        public string Password { get; set; }

        public int PositionId { get; set; }


        [ForeignKey("PositionId")]
        public Position position { get; set; }

    }
}
