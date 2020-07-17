using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace finalmawjoud_nlh.Models
{
    // Vous pouvez ajouter des données de profil pour l'utilisateur en ajoutant d'autres propriétés à votre classe ApplicationUser. Pour en savoir plus, consultez https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {

    
        //  public  virtual Product Products { get; set; }
       // public virtual ICollection<Notification> Notifications { get; set; }
        public string LastName{ get; set; }
        public string FirstName { get; set; }
        public string City { get; set;}
        public string MemberPhoto { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Notez qu'authenticationType doit correspondre à l'élément défini dans CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Ajouter les revendications personnalisées de l’utilisateur ici
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {



 
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        internal void Attach(IDbSet<ApplicationUser> users )
        {
            throw new NotImplementedException();
        }

        internal void Attach(object applicationUser)
        {
            throw new NotImplementedException();
        }

        public DbSet<Product> Products { get; set; }
      
        public DbSet<Images> Images { get; set; }
                                   // for an ApplicationUser
        

    }
    
}