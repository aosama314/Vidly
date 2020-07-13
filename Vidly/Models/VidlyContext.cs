namespace Vidly.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Vidly.Models;

    public class VidlyContext : IdentityDbContext
    {
        // Your context has been configured to use a 'VidlyContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Vidly.Models.VidlyContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'VidlyContext' 
        // connection string in the application configuration file.
        public VidlyContext()
            : base("name=VidlyContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}