using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using static Congreso_1.Enum.Enum;

namespace Congreso_1.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser

    {
        [Display(Name = "Nombres")]
        public string FirstName { get; set; }
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }

        [Display(Name = "Rol")]
        public Roles Rol { get; set; }
        
        [Display(Name = "Empresa")]
        [ForeignKey("Enterprise")]
        public int EnterpriseId { get; set; }
        public virtual Enterprise Enterprise { get; set; }

        [Display(Name = "Ciudad")]
        [ForeignKey("City")]
        public int CityId { get; set; }
        public virtual City City { get; set; }

        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<City> Tb_City { get; set; }

        public DbSet<Congress> Tb_Congress { get; set; }
        public DbSet<Congress_Enterprise> Tb_Congress_Enterprise { get; set; }
        public DbSet<Country> Tb_Country { get; set; }
        public DbSet<Digital_Resource> Tb_Digitar_Resource { get; set; }
        public DbSet<Enterprise> Tb_Enterprise { get; set; }
        public DbSet<Schedule> Tb_Schedule { get; set; }
        public DbSet<Stand> Tb_Stand { get; set; }
        public DbSet<Stand_Resource> Tb_Stand_Resource { get; set; }
        public DbSet<Stand_Type> Tb_Stand_Type { get; set; }
        public DbSet<UserInteractions> Tb_User_Interactions{get; set; }
        public DbSet<Webinar> Tb_Webinar { get; set; }











        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}