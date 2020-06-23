using AutoMapper;
using ComicStoreBL.Interfaces;
using ComicStoreBL.Models;
using ComicStoreBL.Services;
using ComicStoreDAL.Entities;
using ComicStoreDAL.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ComicStoreUnitTests.Services
{
    public class ComicBookServiceTests
    {
        private IComicBookService _bookService;

        [SetUp]
        public void Setup()
        {
            var _comicBookRepositoryMock = new Mock<IGenericRepository<ComicBook>>();

            var mapperProfile = new MapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mapperProfile));
            var mapper = new Mapper(configuration);

            _comicBookRepositoryMock
                .Setup(x => x.Create(It.IsNotNull<ComicBook>()));

            _comicBookRepositoryMock
                .Setup(x => x.Create(It.Is<ComicBook>(x => x == null)))
                .Throws(new ArgumentNullException());

            _comicBookRepositoryMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns((int id) => new ComicBook
                {
                    Id = id,
                    Description = Faker.StringFaker.Alpha(10),
                    CategoryId = Faker.NumberFaker.Number(0, 4),
                    Name = Faker.NameFaker.Name(),
                    Price = Faker.NumberFaker.Number(5, 20),
                    PublisherId = Faker.NumberFaker.Number(0, 4),
                    Quantity = Faker.NumberFaker.Number(10, 100)

                });

            _comicBookRepositoryMock.Setup(x => x.GetAll()).Returns(() => new List<ComicBook>()
            {
                new ComicBook{ Id = 1, Name = Faker.NameFaker.Name(), CategoryId = 1, PublisherId = 2, Quantity = Faker.NumberFaker.Number(10, 100)},
                new ComicBook{ Id = 2, Name = Faker.NameFaker.Name(), CategoryId = 2, PublisherId = 2, Quantity = Faker.NumberFaker.Number(10, 100)},
                new ComicBook{ Id = 3, Name = Faker.NameFaker.Name(), CategoryId = 3, PublisherId = 2, Quantity = Faker.NumberFaker.Number(10, 100)}
            });


            _comicBookRepositoryMock.Setup(x => x.Delete(It.IsAny<int>()));

            _comicBookRepositoryMock.Setup(x => x.Update(It.IsAny<ComicBook>()));

            _comicBookRepositoryMock.Setup(x => x.CreateGetCreatedItem(It.IsAny<ComicBook>())).Returns((ComicBook book) => new ComicBook
            {
                Id = book.Id,
                Description = Faker.StringFaker.Alpha(10),
                CategoryId = Faker.NumberFaker.Number(0, 4),
                Name = Faker.NameFaker.Name(),
                Price = Faker.NumberFaker.Number(5, 20),
                PublisherId = Faker.NumberFaker.Number(0, 4),
                Quantity = Faker.NumberFaker.Number(10, 100)

            });

            _bookService = new ComicBookService(_comicBookRepositoryMock.Object, mapper);

        }

        [Test]
        [TestCase(20)]
        public void GetById_SameId(int id)
        {
            var bookById = _bookService.GetById(id);
            Assert.AreEqual(id, bookById.Id);
        }
        
        [Test]
        public void GetAll_ListOfBooksIsNotNull() 
        {
            var comicBookList = _bookService.GetAll();
            Assert.IsNotNull(comicBookList);
        }

        [Test]
        [TestCase(1)]
        public void Delete_Success(int id) 
        {
            _bookService.Delete(id);
        }

        [Test, TestCaseSource(typeof(ComicBookFactory), "TestCases")]
        public void CreateGetCreatedItem_NotNull(ComicBookBL comicBook)
        {
            var book = _bookService.CreateGetCreatedItem(comicBook);
            Assert.IsNotNull(book);
        }

        [Test, TestCaseSource(typeof(ComicBookFactory), "TestCases")]
        public void Update_Success(ComicBookBL comicBook) 
        {
            _bookService.Update(comicBook);
        }

        [Test]
        [TestCase(null)]
        public void Create_Null_ThrowsException(ComicBookBL comicBook) 
        {
            Assert.Throws<ArgumentNullException>(() => _bookService.Create(comicBook));
        }

        [Test, TestCaseSource(typeof(ComicBookFactory), "TestCases")]
        public void Create_Success(ComicBookBL comicBook) 
        {
            _bookService.Create(comicBook);
        }

        public class ComicBookFactory
        {
            public static IEnumerable TestCases
            {
                get
                {
                    yield return new TestCaseData(new ComicBookBL
                    {
                        Id = Faker.NumberFaker.Number(0, 100),
                        Name = Faker.NameFaker.Name(),
                        CategoryId = Faker.NumberFaker.Number(0, 4),
                        Description = Faker.StringFaker.Alpha(10),
                        PublisherId = Faker.NumberFaker.Number(0, 3),
                        Price = Faker.NumberFaker.Number(2, 15),
                        Quantity = Faker.NumberFaker.Number(20, 50)
                    });
                }
            }

        }

    }

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ComicBookBL, ComicBook>().ReverseMap();
        }

    }
}
