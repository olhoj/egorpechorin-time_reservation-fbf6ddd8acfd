using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TR.Web.Models.Models
{
    public class MeetingVariant
    {
        public int MeetingVariantID { get; set; }
        public string Owner { get; set; }
        [Required( ErrorMessage ="Please give a title!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please write a description!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please select duration!")]
        public TimeSpan Duration { get; set; }

    }
}
