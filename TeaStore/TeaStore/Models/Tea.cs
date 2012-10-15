using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeaStore.Models
{
    public class Tea
    {
        public int TeaID { get; set; }
        public string Title { get; set; }
        public Type Type { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}