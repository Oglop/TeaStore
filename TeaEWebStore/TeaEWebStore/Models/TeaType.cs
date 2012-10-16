using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeaEWebStore.Models
{
    public class TeaType
    {
        public int TeaTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Tea> Teas { get; set; }
    }
}