using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QRCodeProjectLast.Models
{
    public class QRCodeModel
    {

        [Display(Name ="Enter QRCode Text")]
        public string QRCodeText { get; set; }
    }
}