﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosales.Model
{
    public class PSRBarcode
    {
        public int Id { get; set; }
        public string Pronumber { get; set; }
        public int ProId { get; set; }


        [ForeignKey("ProId")]
        public PSR psrs { get; set; }
    }
}
