using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace finalmawjoud_nlh.Models
{
    [Table("Dbo.Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Le nom du produit est obligatoire")]
        [StringLength(100, ErrorMessage = "la longueur du nom du produit doit être comprise entre 3 et 100 caractères")]
        public string ProductName { get; set; }
        public string Place { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Il faut inserer une image")]
        public string ProductImage {get;set;}
        [Required(ErrorMessage = "il faut préciser le prix")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]

        public float Price { get; set; }
     
        
   
   public int CategoryId { get; set; }
      
       [ForeignKey("CategoryId")] 
       
        public virtual Category category { get; set; }

        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
    
        public ApplicationUser User { get; set; }
    }
   

} 