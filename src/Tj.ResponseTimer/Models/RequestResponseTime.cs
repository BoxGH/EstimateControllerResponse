using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tj.ResponseTimer.Models
{
    public class RequestResponseTime
    {
        [Key]
        public int Id { get; set; }
        public string PagePath { get; set; }
        public Int64 MeasureTime  { get; set; }
        public Int64 ServerIn { get; set; }
        public Int64 ServerOut { get; set; }
        public Int64 EndRequest { get; set; }
    }
}
