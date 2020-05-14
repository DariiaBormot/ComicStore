using ComicStoreDAL.Entities;
using Common.Enums;
using Faker;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreDAL
{
    public class StoreInitializer : DropCreateDatabaseAlways<ComicStoreContext>
    {
        protected override void Seed(ComicStoreContext context)
        {
            
            var category1 = new Category { Name = "Best Sellers", Description = "Best-Selling Books of this year", Image = "noimage"};
            var category2 = new Category { Name = "New Releases", Description = "List of New Release books", Image = "noimage" };
            var category3 = new Category { Name = "Monthly Top 10", Description = "The 10 best comic books to read this month", Image = "noimage" };

            context.Categories.Add(category1);
            context.Categories.Add(category2);
            context.Categories.Add(category3);
            context.SaveChanges();

            var publisher1 = new Publisher
            {
                Name = "DC Comics", 
                Description = TextFaker.Sentence()
            };

            var publisher2 = new Publisher
            {
                Name = "Marvel Comics",
                Description = TextFaker.Sentence()
            };

            var publisher3 = new Publisher
            {
                Name = "Dark Horse Comics",
                Description = TextFaker.Sentence()
            };

            var publisher4 = new Publisher
            {
                Name = "Disney",
                Description = TextFaker.Sentence()
            };

            context.Publishers.Add(publisher1);
            context.Publishers.Add(publisher2);
            context.Publishers.Add(publisher3);
            context.Publishers.Add(publisher4);
            context.SaveChanges();

            var order1 = new Order { TotalPrice = 10, OrderDate = DateTime.Now, OrderStatus = OrderStatus.Completed, UserId = "" };
            var order2 = new Order { TotalPrice = 20, OrderDate = DateTime.Now, OrderStatus = OrderStatus.Completed, UserId = "" };
            var order3 = new Order { TotalPrice = 30, OrderDate = DateTime.Now, OrderStatus = OrderStatus.Completed, UserId = "" };
            var order4 = new Order { TotalPrice = 40, OrderDate = DateTime.Now, OrderStatus = OrderStatus.Completed, UserId = "" };
            var order5 = new Order { TotalPrice = 50, OrderDate = DateTime.Now, OrderStatus = OrderStatus.Completed, UserId = "" };

            context.Orders.Add(order1);
            context.Orders.Add(order2);
            context.Orders.Add(order3);
            context.Orders.Add(order4);
            context.Orders.Add(order5);
            context.SaveChanges();

            var orderDetails1 = new OrderDetails { Name = NameFaker.FirstName(), LastName = NameFaker.LastName(), Country = LocationFaker.Country(), City = LocationFaker.City(), Street = LocationFaker.Street(), Appartment = LocationFaker.StreetNumber(), ZipCode = LocationFaker.ZipCode(), PhoneNumber = NumberFaker.Number(), OrderId = 1 };
            var orderDetails2 = new OrderDetails { Name = NameFaker.FirstName(), LastName = NameFaker.LastName(), Country = LocationFaker.Country(), City = LocationFaker.City(), Street = LocationFaker.Street(), Appartment = LocationFaker.StreetNumber(), ZipCode = LocationFaker.ZipCode(), PhoneNumber = NumberFaker.Number(), OrderId = 2 };
            var orderDetails3 = new OrderDetails { Name = NameFaker.FirstName(), LastName = NameFaker.LastName(), Country = LocationFaker.Country(), City = LocationFaker.City(), Street = LocationFaker.Street(), Appartment = LocationFaker.StreetNumber(), ZipCode = LocationFaker.ZipCode(), PhoneNumber = NumberFaker.Number(), OrderId = 3 };
            var orderDetails4 = new OrderDetails { Name = NameFaker.FirstName(), LastName = NameFaker.LastName(), Country = LocationFaker.Country(), City = LocationFaker.City(), Street = LocationFaker.Street(), Appartment = LocationFaker.StreetNumber(), ZipCode = LocationFaker.ZipCode(), PhoneNumber = NumberFaker.Number(), OrderId = 4 };
            var orderDetails5 = new OrderDetails { Name = NameFaker.FirstName(), LastName = NameFaker.LastName(), Country = LocationFaker.Country(), City = LocationFaker.City(), Street = LocationFaker.Street(), Appartment = LocationFaker.StreetNumber(), ZipCode = LocationFaker.ZipCode(), PhoneNumber = NumberFaker.Number(), OrderId = 5 };

            context.OrderDetails.Add(orderDetails1);
            context.OrderDetails.Add(orderDetails2);
            context.OrderDetails.Add(orderDetails3);
            context.OrderDetails.Add(orderDetails4);
            context.OrderDetails.Add(orderDetails5);


            var book1 = new ComicBook
            {
                Name = "SPIDER-VERSE",
                Description = TextFaker.Sentence(),
                Price = 20,
                Quantity = 50,
                CategoryId = 1,
                PublisherId = 2,
                Image = "~/Assets/images/books/spidervercezero.png"
            };

            var book2 = new ComicBook
            {
                Name = "WONDER WOMAN",
                Description = TextFaker.Sentence(),
                Price = 15,
                Quantity = 100,
                CategoryId = 2,
                PublisherId = 1,
                Image = "~/Assets/images/books/wonder.png"
            };

            var book3 = new ComicBook
            {
                Name = "DEADPOOL",
                Description = TextFaker.Sentence(),
                Price = 10,
                Quantity = 200,
                CategoryId = 3,
                PublisherId = 2,
                Image = "~/Assets/images/books/deadpoolcarn.png"
            };

            var book4 = new ComicBook
            {
                Name = "BIRDS OF PREY",
                Description = TextFaker.Sentence(),
                Price = 15,
                Quantity = 150,
                CategoryId = 1,
                PublisherId = 1,
                Image = "~/Assets/images/books/harley.png"
            };

            var book5 = new ComicBook
            {
                Name = "THE IMMORTAL HULK",
                Description = TextFaker.Sentence(),
                Price = 20,
                Quantity = 800,
                CategoryId = 2,
                PublisherId = 2,
                Image = "~/Assets/images/books/hulkink.png"
            };

            var book6 = new ComicBook
            {
                Name = "HELLBOY",
                Description = TextFaker.Sentence(),
                Price = 12,
                Quantity = 200,
                CategoryId = 3,
                PublisherId = 3,
                Image = "~/Assets/images/books/hellboy.png"
            };

            var book7 = new ComicBook
            {
                Name = "GRAVITY FALLS",
                Description = TextFaker.Sentence(),
                Price = 18,
                Quantity = 300,
                CategoryId = 1,
                PublisherId = 4,
                Image = "~/Assets/images/books/gravityfalls.png"
            };

            var book8 = new ComicBook
            {
                Name = "SUPERMAN VS DOOMSDAY",
                Description = TextFaker.Sentence(),
                Price = 14,
                Quantity = 400,
                CategoryId = 2,
                PublisherId = 1,
                Image = "~/Assets/images/books/superman.png"
            };

            var book9 = new ComicBook
            {
                Name = "BATMAN",
                Description = TextFaker.Sentence(),
                Price = 10,
                Quantity = 100,
                CategoryId = 3,
                PublisherId = 1,
                Image = "~/Assets/images/books/batman.png"
            };

            var book10 = new ComicBook
            {
                Name = "IRON MAN",
                Description = TextFaker.Sentence(),
                Price = 21,
                Quantity = 200,
                CategoryId = 1,
                PublisherId = 2,
                Image = "~/Assets/images/books/ironman.png"
            };


            var book11 = new ComicBook
            {
                Name = "BLACKWOOD #1",
                Description = TextFaker.Sentence(),
                Price = 5,
                Quantity = 200,
                CategoryId = 2,
                PublisherId = 3,
                Image = "~/Assets/images/books/blackwood.png"
            };


            var book12 = new ComicBook
            {
                Name = "STRANGER THINGS",
                Description = TextFaker.Sentence(),
                Price = 6,
                Quantity = 100,
                CategoryId = 3,
                PublisherId = 3,
                Image = "~/Assets/images/books/strangerthings.png"
            };

            var book13 = new ComicBook
            {
                Name = "GIANT",
                Description = TextFaker.Sentence(),
                Price = 6,
                Quantity = 100,
                CategoryId = 3,
                PublisherId = 4,
                Image = "~/Assets/images/books/giantdisney.png"
            };

            var book14 = new ComicBook
            {
                Name = "HAUNTED MANSION",
                Description = TextFaker.Sentence(),
                Price = 7,
                Quantity = 500,
                CategoryId = 1,
                PublisherId = 4,
                Image = "~/Assets/images/books/hantedmaison.png"
            };

            var book15 = new ComicBook
            {
                Name = "GRAVITY FALLS",
                Description = TextFaker.Sentence(),
                Price = 7,
                Quantity = 200,
                CategoryId = 2,
                PublisherId = 4,
                Image = "~/Assets/images/books/gravity.png"
            };

            var book16 = new ComicBook
            {
                Name = "STAR WARS",
                Description = TextFaker.Sentence(),
                Price = 7,
                Quantity = 200,
                CategoryId = 2,
                PublisherId = 3,
                Image = "~/Assets/images/books/starwars.png"
            };


            context.ComicBooks.Add(book1);
            context.ComicBooks.Add(book2);
            context.ComicBooks.Add(book3);
            context.ComicBooks.Add(book4);
            context.ComicBooks.Add(book5);
            context.ComicBooks.Add(book6);
            context.ComicBooks.Add(book7);
            context.ComicBooks.Add(book8);
            context.ComicBooks.Add(book9);
            context.ComicBooks.Add(book10);
            context.ComicBooks.Add(book11);
            context.ComicBooks.Add(book12);
            context.ComicBooks.Add(book13);
            context.ComicBooks.Add(book14);
            context.ComicBooks.Add(book15);
            context.ComicBooks.Add(book16);


            context.SaveChanges();

            base.Seed(context);
        }
    }
}
