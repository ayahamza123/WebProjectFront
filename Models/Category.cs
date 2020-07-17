using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace finalmawjoud_nlh.Models
{
    [Table("dbo.Category")]

    public class Category { 
    [Key]
    public int CategoryId { get; set; }
    [Required]
    public string CategoryName { get; set; }
    public bool IsActive { get; set; }

}
 

}