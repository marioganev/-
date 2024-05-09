using System;
using System.Collections.Generic;

#nullable disable

namespace Въвеждане_на_продукти_в_склад_НОВ.Models
{
    public partial class SkladV
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
    }
}
