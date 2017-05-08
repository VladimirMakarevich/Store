namespace Store.DAL.Migrations
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Store.DAL.Context.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Store.DAL.Context.StoreContext context)
        {
            var category = new List<Category>
            {
                new Category { Name = "Category1", Description = "Description1" },
                new Category { Name = "Category2", Description = "Description2" }
            };
            category.ForEach(s => context.Categories.Add(s));
            context.SaveChanges();

            var product = new List<Product>
            {
                new Product { Name = "Product1", Description = "Description1", Price = 12, ImageData = null, ImageMimeType = null, Availability = Availability.InStock },
                new Product { Name = "Product2", Description = "Description2", Price = 32, ImageData = null, ImageMimeType = null, Availability = Availability.NotAvailable },
                new Product { Name = "Product3", Description = "Description3", Price = 23, ImageData = null, ImageMimeType = null, Availability = Availability.ToOrder }
            };
            product.ForEach(s => context.Products.Add(s));
            context.SaveChanges();

            //for (int j = 1; j <= store.Count; ++j)
            //{
            //    for (int i = 0; i <= 20; i++)
            //    {
            //        var item = new Item
            //        {
            //            Name = $"Item{i} " + $"by {store[j - 1].Name}",
            //            Description = $"Description{i} " + $"by {store[j - 1].Name}",
            //            StoreId = j
            //        };
            //        context.Items.Add(item);
            //        context.SaveChanges();
            //    }
            //}
        }
    }
}
