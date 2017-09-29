using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tj.ResponseTimer.Models
{
    public class SomeDataClassForView
    {
        [Key]
        public int Id { get; set; }
        public int FieldNamber { get; set; }
        public string FieldString { get; set; }
    }
}
