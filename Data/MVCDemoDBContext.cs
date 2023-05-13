using Microsoft.EntityFrameworkCore;
using WebApplication1_Scrum2.Models;

namespace WebApplication1_Scrum2.Data
{
    public class MVCDemoDBContext : DbContext
    {

        public MVCDemoDBContext(DbContextOptions options) : base(options) { }

        public DbSet<AddProductViewModel> product { get; set; }
    }
    
    

}
