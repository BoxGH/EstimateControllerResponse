using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tj.ResponseTimer.Models
{
    public class ForTable
    {
        [Key]
        public int Id { get; set; }
        public string PagePath { get; set; }
        public string PagePath2 { get; set; }
        public string PagePath3 { get; set; }
    }
}
