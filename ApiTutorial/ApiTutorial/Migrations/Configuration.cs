namespace ApiTutorial.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ApiTutorial.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ApiTutorial.Models.ProductContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApiTutorial.Models.ProductContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Products.AddOrUpdate(x => x.ProductId,
                new Product()
                {
                    ProductId = 1,
                    ProductName = "Extending Bootstrap with CSS, JavaScript and jQuery",
                    IntroductionDate = Convert.ToDateTime("11/6/2015"),
                    Url = "http://bit.ly/1SNzc0i"
                },
                new Product()
                {
                    ProductId = 2,
                    ProductName = "Build your own Bootstrap Business Application Template in MVC",
                    IntroductionDate = Convert.ToDateTime("29/01/2015"),
                    Url = "http://bit.ly/1I8ZqZg"
                },
                new Product()
                {
                    ProductId = 3,
                    ProductName = "Building Mobile Web Sites Using,Web Forms, Bootstrap, and HTML5",
                    IntroductionDate = Convert.ToDateTime("28/8/2014"),
                    Url = "http://bit.ly/1J2dcrj"
                }
            );
        }
    }
}
