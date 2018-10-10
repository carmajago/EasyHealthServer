using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace EasyHealth.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
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
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<EasyHealth.Models.Afiliado> Afiliados { get; set; }

        public System.Data.Entity.DbSet<EasyHealth.Models.Categoria> Categorias { get; set; }

        public System.Data.Entity.DbSet<EasyHealth.Models.Cita> Citas { get; set; }

        public System.Data.Entity.DbSet<EasyHealth.Models.Medico> Medicos { get; set; }

        public System.Data.Entity.DbSet<EasyHealth.Models.Servicio> Servicios { get; set; }


        public System.Data.Entity.DbSet<EasyHealth.Models.Hora> Horas { get; set; }
        public System.Data.Entity.DbSet<EasyHealth.Models.Dia> Dias { get; set; }
    }
}