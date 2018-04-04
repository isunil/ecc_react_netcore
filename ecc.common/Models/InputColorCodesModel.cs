using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace ecc.common.Models
{
    public class InputColorCodesModel
    {
        [Required]
        public string BandAColor { get; set; }
        [Required]
        public string BandBColor { get; set; }
        [Required]
        public string BandCColor { get; set; }
        public string BandDColor { get; set; }
    }
}
