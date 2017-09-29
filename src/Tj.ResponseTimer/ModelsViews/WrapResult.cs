using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tj.ResponseTimer.Models;

namespace Tj.ResponseTimer.ModelsViews
{
    public class WrapResult
    {
        public string PagePath { get; set; }
        public long measSerTime { get; set; }
        public long measScTime { get; set; }
        public long measSerPersTime { get; set; }
        public long measScPersTime { get; set; }
    }
}
