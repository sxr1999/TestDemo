using NewMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.ComponentModel.DataAnnotations.Schema;
using IdentityUser = NewMVC.Models.IdentityUser;
using NewMVC.Models2;

namespace NewMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
       

        public DbSet<Equipment> equipments { get; set; }
        public DbSet<DropDownData> dropDownDatas { get; set; }
        public DbSet<Location> locations { get; set; }
        public DbSet<SeedModel> SeedModels { get; set; }
        public DbSet<DegreeName> DegreeName { get; set; }
        public DbSet<Item> item { get; set; }
        public DbSet<Room> rooms { get; set; }
        public DbSet<Floors> floors { get; set; }
        //public DbSet<ListModel> listmodel { get; set; }

        public DbSet<IdentityUser> identityUsers{ get; set; }

        public DbSet<Favorite> favorites { get; set; }


        public DbSet<Student> students { get; set; }

        public DbSet<User> User { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Professor> prefessor { get; set; }
        public DbSet<CursosModel> cursosModels { get; set; }

        public DbSet<Officer> Officers { get; set; }
        public DbSet<Agency> Agency { get; set; }

        // public DbSet<Attachment> attachments { get; set; }

        public DbSet<AppFile> File { get; set; }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Classe> Classes { get; set; }

        public DbSet<Show> shows { get; set; }
        public DbSet<Cast> casts { get; set; }

       



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Show>().ToTable("Show");
            builder.Entity<Cast>().ToTable("Cast");

            builder.Entity<Location>()
                .HasOne(x => x.equipment)
                .WithOne(y => y.Location)
                .HasForeignKey<Equipment>(z => z.LocationId);

            builder.Entity<Room>()
                .HasOne(x => x.location)
                .WithOne(y => y.Room)
                .HasForeignKey<Location>(z => z.RoomId);

            builder.Entity<Floors>()
                .HasOne(x => x.location)
                .WithOne(y => y.Floor)
                .HasForeignKey<Location>(z => z.FloorId);
            

           
        }
    }
}