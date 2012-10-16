using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TeaEWebStore.Models
{
    public class Tea
    {

        [ScaffoldColumn(false)]
        public int TeaID { get; set; }

        [DisplayName("Country")]
        public int CountryID { get; set; }

        [DisplayName("TeaType")]
        public int TeaTypeID { get; set; }

        [Required(ErrorMessage = "An album title is required.")]
        [StringLength(160)]
        public string Title { get; set; }

        [Range(0.01, 100.00, ErrorMessage = "Price must be between 0.01 and 100.00")]
        public decimal Price { get; set; }

        [DisplayName("Album Art URL")]
        [StringLength(1024)]
        public string TeaArtUrl { get; set; }

        public virtual TeaType TeaType { get; set; }
        public virtual Country Country { get; set; }
    }
}