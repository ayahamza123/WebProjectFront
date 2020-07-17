using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace finalmawjoud_nlh.Models
{
    [Table("Dbo.Images")]
    public class Images
    {

        [Key]
        public int ImageId { get; set; }
        public string SlideImageName { get; set; }

        public string SlideImage { get; set; }
        public string MenuImageName { get; set; }
        public string MenuImage { get; set; }
        public string DiscountImageName { get;set; }
        public string DiscountImage { get; set; }
        public string otherImageName { get; set; }
        public string OtherImage { get; set; }
    }
}