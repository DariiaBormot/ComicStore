using ComicStoreDAL.Entities;
using Common.Enums;
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

            var user1 = new User { FirstName = "Stephen", LastName = "Strange", Birthday = DateTime.Now, Email = "strange@gmail.com", Image = "~/Assets/images/users/strange.png" };
            var user2 = new User { FirstName = "Tony", LastName = "Stark", Birthday = DateTime.Now, Email = "stark@gmail.com", Image = "~/Assets/images/users/tony.png" };
            var user3 = new User { FirstName = "Natasha", LastName = "Romanoff", Birthday = DateTime.Now, Email = "nata@gmail.com", Image = "~/Assets/images/users/nat.png" };
            var user4 = new User { FirstName = "Bruce", LastName = "Banner", Birthday = DateTime.Now, Email = "bruce@gmail.com", Image = "~/Assets/images/users/bruce.png" };
            var user5 = new User { FirstName = "Steven", LastName = "Rogers", Birthday = DateTime.Now, Email = "steven@gmail.com", Image = "~/Assets/images/users/steven.png" };
            var user6 = new User { FirstName = "Wanda", LastName = "Maximoff", Birthday = DateTime.Now, Email = "wanda@gmail.com", Image = "~/Assets/images/users/wanda.png" };
            var user7 = new User { FirstName = "Peter", LastName = "Parker", Birthday = DateTime.Now, Email = "peter@gmail.com", Image = "~/Assets/images/users/peter.png" };
            var user8 = new User { FirstName = "Peter", LastName = "Quill", Birthday = DateTime.Now, Email = "quill@gmail.com", Image = "~/Assets/images/users/starlord.png" };

            context.Users.Add(user1);
            context.Users.Add(user2);
            context.Users.Add(user3);
            context.Users.Add(user4);
            context.Users.Add(user5);
            context.Users.Add(user6);
            context.Users.Add(user7);
            context.Users.Add(user8);
            context.SaveChanges();

            var category1 = new Category { Name = "Best Sellers", Description = "Best-Selling Books of this year", Image = "noimage"};
            var category2 = new Category { Name = "New Releases", Description = "List of New Release books", Image = "noimage" };
            var category3 = new Category { Name = "Monthly Top 10", Description = "The 10 best comic books to read this month", Image = "noimage" };

            context.Categories.Add(category1);
            context.Categories.Add(category2);
            context.Categories.Add(category3);
            context.SaveChanges();

            var publisher1 = new Publisher 
            { 
                Name = "DC Comics", Description = "DC Comics, Inc. is an American comic book publisher. " +
                                                   "It is the publishing unit of DC Entertainment, a subsidiary of Warner Bros. " +
                                                   "Global Brands and Experiences. DC Comics is one of the largest and oldest American " +
                                                   "comic book companies." 
            };

            var publisher2 = new Publisher
            {
                Name = "Marvel Comics", Description = "Marvel Comics is the brand name and primary imprint of Marvel Worldwide Inc., formerly Marvel Publishing," +
                                                       " Inc. and Marvel Comics Group, a publisher of American comic books and related media. In 2009, The Walt Disney Company acquired Marvel Entertainment," +
                                                       " Marvel Worldwide's parent company."
            };

            var publisher3 = new Publisher
            {
                Name = "Dark Horse Comics", Description = "Dark Horse Comics is an American comic book and manga publisher. " +
                                                          "It was founded in 1986 by Mike Richardson in Milwaukie, Oregon."
            };

            var publisher4 = new Publisher
            {
                Name = "Disney", Description = "Disney comics are comic books and comic strips featuring characters created by the Walt Disney Company, " +
                                                "including Mickey Mouse, Donald Duck and Uncle Scrooge."
            };

            context.Publishers.Add(publisher1);
            context.Publishers.Add(publisher2);
            context.Publishers.Add(publisher3);
            context.Publishers.Add(publisher4);
            context.SaveChanges();

            var order1 = new Order { TotalPrice = 10, OrderDate = DateTime.Now, OrderStatus = OrderStatus.Completed, UserId = 1 };
            var order2 = new Order { TotalPrice = 20, OrderDate = DateTime.Now, OrderStatus = OrderStatus.Completed, UserId = 2 };
            var order3 = new Order { TotalPrice = 30, OrderDate = DateTime.Now, OrderStatus = OrderStatus.Completed, UserId = 3 };
            var order4 = new Order { TotalPrice = 40, OrderDate = DateTime.Now, OrderStatus = OrderStatus.Completed, UserId = 4 };
            var order5 = new Order { TotalPrice = 50, OrderDate = DateTime.Now, OrderStatus = OrderStatus.Completed, UserId = 5 };

            context.Orders.Add(order1);
            context.Orders.Add(order2);
            context.Orders.Add(order3);
            context.Orders.Add(order4);
            context.Orders.Add(order5);
            context.SaveChanges();

            var book1 = new ComicBook
            {
                Name = "SPIDER-VERSE",
                Description = "Miles Morales falls through a dimensional portal into a new multiversal adventure! Wait, wasn’t the Web of Life and " +
                "Destiny destroyed? Maybe not, True Believer! But who spun this new web? And why? Whatever the answers, the entire Spider-Verse is " +
                "in big trouble — and it’s time to come together once again! ",
                Price = 20,
                Quantity = 50,
                CategoryId = 1,
                PublisherId = 2,
                Image = "~/Assets/images/books/spidervercezero.png"
            };

            var book2 = new ComicBook
            {
                Name = "WONDER WOMAN",
                Description = "Noted Psychologist Revealed as Author of Best-Selling ‘Wonder Woman,’” read the astonishing headline. In the summer of 1942, " +
                "a press release from the New York offices of All-American Comics turned up at newspapers, magazines and radio stations all over the United States. " +
                "The identity of Wonder Woman’s creator had been “at first kept secret,” it said, but the time had come to make a shocking announcement: " +
                "“the author of ‘Wonder Woman’ is Dr. William Moulton Marston, internationally famous psychologist.” The truth about Wonder Woman had come out at last.",
                Price = 15,
                Quantity = 100,
                CategoryId = 2,
                PublisherId = 1,
                Image = "~/Assets/images/books/wonder.png"
            };

            var book3 = new ComicBook
            {
                Name = "DEADPOOL",
                Description = "LET’S GET CRAZY! At long last, Deadpool is ready to get his head straight and checks himself into Ravencroft Institute. Unfortunately, " +
                "there’s another new arrival: CARNAGE! But I don’t think he’s here for a group therapy session…Madness and mayhem abound in the can’t-miss showdown of the year!",
                Price = 10,
                Quantity = 200,
                CategoryId = 3,
                PublisherId = 2,
                Image = "~/Assets/images/books/deadpoolcarn.png"
            };

            var book4 = new ComicBook
            {
                Name = "BIRDS OF PREY",
                Description = "When Gotham's favorite sociopath inherits a building on the famous Coney Island boardwalk, she feels right at home in the (literal) freakshow. " +
                "Unfortunately, the legion of bounty hunters after the price on her head seem to know it, too. Who else but Harley Quinn could handle all that Brooklyn's " +
                "criminal underbelly has to offer-Russian spies, senior citizens, and rival roller derby teams included-and still have time for a double chili dog!",
                Price = 15,
                Quantity = 150,
                CategoryId = 1,
                PublisherId = 1,
                Image = "~/Assets/images/books/harley.png"
            };

            var book5 = new ComicBook
            {
                Name = "THE IMMORTAL HULK",
                Description = "Since 2018, Immortal Hulk, written by Al Ewing with art by Joe Bennett, inker Ruy José, colorist Paul Mounts, and letterer Cory Petit, " +
                "has been the most consistent, surprising, and satisfying superhero comic released by any major publisher. Together, building off the character’s nearly 60-year history, " +
                "the creative team has established Hulk as the ultimate hero for a bleak age defined by environmental collapse and institutional corruption.",
                Price = 20,
                Quantity = 800,
                CategoryId = 2,
                PublisherId = 2,
                Image = "~/Assets/images/books/hulkink.png"
            };

            var book6 = new ComicBook
            {
                Name = "HELLBOY",
                Description = "Dark Horse presents new editions of the entire Hellboy line with new covers, beginning with Seed of Destruction, the basis of director " +
                "Guillermo del Toro's blockbuster films.",
                Price = 12,
                Quantity = 200,
                CategoryId = 3,
                PublisherId = 3,
                Image = "~/Assets/images/books/hellboy.png"
            };

            var book7 = new ComicBook
            {
                Name = "GRAVITY FALLS",
                Description = "Gravity Falls: Lost Legends is a graphic novel set within the universe of Gravity Falls. Written by series creator Alex Hirsch, " +
                "it consists of three stories that take place during the final season, as well as a fourth taking place during Grunkle Stan's childhood. " +
                "The comic was released on July 24, 2018.",
                Price = 18,
                Quantity = 300,
                CategoryId = 1,
                PublisherId = 4,
                Image = "~/Assets/images/books/gravityfalls.png"
            };

            var book8 = new ComicBook
            {
                Name = "SUPERMAN VS DOOMSDAY",
                Description = "Superman travels to the nightmare world of Apokolips for a confrontation with Doomsday, the creature who cost the Man of Steel his life. " +
                "With the help of the mysterious, time-traveling Waverider, Superman at last discovers the shocking truth of his greatest enemy's origin. And just when " +
                "he thinks the terror is finally over, the murderous juggernaut returns to Earth even more powerful than ever!",
                Price = 14,
                Quantity = 400,
                CategoryId = 2,
                PublisherId = 1,
                Image = "~/Assets/images/books/superman.png"
            };

            var book9 = new ComicBook
            {
                Name = "BATMAN",
                Description = "Batman’s origin story, Two-Face’s rise, Robin’s reckoning — the list has been heavy so far on the bullet points of Batman continuity. " +
                "The Last Arkham, the first and best Mr. Zsasz story, is different. This book is exactly the kind of story that you are unlikely to get in a superhero movie, " +
                "because it works on the strength of the a serialized format: Batman isn’t saving the city, he’s solving one case. None of his friends die or change costumes, " +
                "and things do return to the status quo at the end. And yet, this case.",
                Price = 10,
                Quantity = 100,
                CategoryId = 3,
                PublisherId = 1,
                Image = "~/Assets/images/books/batman.png"
            };

            var book10 = new ComicBook
            {
                Name = "IRON MAN",
                Description = "Over the last decade-plus, Iron Man has shot through the ranks from C-list or fringe B-list hero in Marvel’s stable to a bonafide star thanks to Marvel " +
                "Studios film output and the revitalized career of Robert Downey Jr. With Avengers: Endgame killing off the MCU Tony Stark, it seems comic books may follow suit, " +
                "with an upcoming Iron Man 2020 project teasing his death in comic books as well. With that in mind, we're counting down the greatest Iron Man stories of all time.",
                Price = 21,
                Quantity = 200,
                CategoryId = 1,
                PublisherId = 2,
                Image = "~/Assets/images/books/ironman.png"
            };


            var book11 = new ComicBook
            {
                Name = "BLACKWOOD #1",
                Description = "From the multi-Eisner award-winning creator of Beasts of Burden and the artist of Archie and Slam comes this " +
                "supernatural fantasy about a magical murder in a sorcery school. When four teenagers with haunted pasts enroll in Blackwood" +
                " College--a school that trains students in the occult-their desire to enhance their supernatural abilities and bond with others " +
                "is hampered by an undead deans curse, ghosts in their dorm, a mischievous two-headed mummy-chimp, a plague of mutant insects, and " +
                "the discovery of an ancient evil that forces our heroes to undergo a crash course in the occult for the sake of the world. ",
                Price = 5,
                Quantity = 200,
                CategoryId = 2,
                PublisherId = 3,
                Image = "~/Assets/images/books/blackwood.png"
            };


            var book12 = new ComicBook
            {
                Name = "STRANGER THINGS",
                Description = "When Will Byers finds himself in the Upside Down, an impossible dark parody of his own world, he's understandably " +
                "frightened. But that's nothing compared with the fear that takes hold when he realizes what's in that world with him! ",
                Price = 6,
                Quantity = 100,
                CategoryId = 3,
                PublisherId = 3,
                Image = "~/Assets/images/books/strangerthings.png"
            };

            var book13 = new ComicBook
            {
                Name = "GIANT",
                Description = "When Will Byers finds himself in the Upside Down, an impossible dark parody of his own world, he's understandably " +
                "frightened. But that's nothing compared with the fear that takes hold when he realizes what's in that world with him! ",
                Price = 6,
                Quantity = 100,
                CategoryId = 3,
                PublisherId = 4,
                Image = "~/Assets/images/books/giantdisney.png"
            };

            var book14 = new ComicBook
            {
                Name = "HAUNTED MANSION",
                Description = "Welcome, foolish mortals, to the Haunted Mansion - enter if you dare! You might think that no one lives in this elegant house " +
                "on the hill...but then where's that creepy organ music coming from? Are its iron gates meant to keep people out...or keep something in? ",
                Price = 7,
                Quantity = 500,
                CategoryId = 1,
                PublisherId = 4,
                Image = "~/Assets/images/books/hantedmaison.png"
            };

            var book15 = new ComicBook
            {
                Name = "GRAVITY FALLS",
                Description = "The book is presented as a series of stories told by Shmebulock, who was placed under a warlock's curse to say his own name, but every" +
                " thousand years, is able to speak coherently in English.",
                Price = 7,
                Quantity = 200,
                CategoryId = 2,
                PublisherId = 4,
                Image = "~/Assets/images/books/gravity.png"
            };

            var book16 = new ComicBook
            {
                Name = "STAR WARS",
                Description = "A long time ago in a galaxy far, far away, the adventures of Luke Skywalker, Han Solo, Princess, Leia, Darth Vader and more continue! " +
                "Set following the events of Episode IV",
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
