using AutoMapper;
using IShop.BusinessLayer.UnitTests.MockHelpers;
using IShop.BussinesLayer.Entities;
using IShop.BussinesLayer.Mapping;
using IShop.BussinesLayer.Providers;
using IShop.BussinesLayer.Providers.Interfaces;
using IShop.DataLayer;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain = IShop.DataLayer.Entities;

namespace IShop.BusinessLayer.UnitTests
{
    [TestFixture]
    public class PostProviderTests
    {
        private IPostProvider _postProvider;
        private List<Domain.Post> _posts;

        [SetUp]
        public void SetUp()
        {
            _posts = new List<Domain.Post>();

            var mockPostsRepository = MockHelper.GetMockRepository(_posts);

            var mockShopUnitOfWork = new Mock<IShopUnitOfWork>();
            mockShopUnitOfWork.Setup(x => x.Posts).Returns(mockPostsRepository.Object);

            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            var mapper = new Mapper(mapperConfig);

            _postProvider = new PostProvider(mockShopUnitOfWork.Object, mapper);
        }

        [TearDown]
        public void TearDown()
        {
            _posts.Clear();
        }

        [Test]
        public void Sould_Not_Delete_Post_If_It_Not_Exitsts_And_Throw_Ex()
        {
            //Act & Assert
            Assert.ThrowsAsync<Exception>(
                () => _postProvider.DeletePost(100500)
            );
        }

        [Test]
        public async Task Sould_Delete_Post()
        {
            var existsPost = TestPostss.First();
            _posts.Add(existsPost);

            //Act
            await _postProvider.DeletePost(existsPost.PostId);

            //Assert
            Assert.IsEmpty(_posts);
        }

        [Test]
        public void Sould_Not_Create_New_Post_If_It_Exitsts_And_Throw_Ex()
        {
            //Arrange
            var newPost = new Post
            {
                PostId = 1,
            };
            var existsPost = TestPostss.First();
            _posts.Add(existsPost);

            //Act & Assert
            Assert.ThrowsAsync<Exception>(
                () => _postProvider.CreatePost(newPost)
            );
        }

        [Test]
        public async Task Sould_Create_New_Post()
        {
            //Arrange
            var newPost = new Post
            {
                Content = "Content",
                Title = "Title"
            };

            //Act
            await _postProvider.CreatePost(newPost);

            //Assert
            Assert.AreEqual(_posts.First().Content, newPost.Content);
            Assert.AreEqual(_posts.First().Title, newPost.Title);
        }

        [Test]
        public async Task Sould_Get_Post_By_Id()
        {
            //Arrange
            _posts.AddRange(TestPostss);
            var postId = TestPostss.First().PostId;

            //Act
            var post = await _postProvider.GetPost(postId);

            //Assert
            Assert.AreEqual(postId, post.PostId);
        }

        [Test]
        public async Task Sould_Get_All_Posts()
        {
            //Arrange
            _posts.AddRange(TestPostss);

            //Act
            var posts = await _postProvider.GetAllPosts();

            //Assert
            Assert.AreEqual(TestPostss.Count(), posts.Count);
            CollectionAssert.AreEqual(
                TestPostss.Select(x => x.PostId),
                posts.Select(x => x.PostId)
            );
        }

        private ICollection<Domain.Post> TestPostss =>
            new List<Domain.Post>
            {
                new Domain.Post
                {
                    PostId = 1,
                    Content = "Content1",
                    Title = "Title1",
                    Comments = new [] 
                    {
                        new Domain.Comment {PostId = 1, CommentText = "Comment_1_Post_1"},
                        new Domain.Comment {PostId = 1, CommentText = "Comment_2_Post_1"}
                    }
                },
                new Domain.Post
                {
                    PostId = 2,
                    Content = "Content2",
                    Title = "Title2",
                    Comments = new []
                    {
                        new Domain.Comment {PostId = 1, CommentText = "Comment_1_Post_2"},
                        new Domain.Comment {PostId = 1, CommentText = "Comment_2_Post_2"}
                    }
                },
            };
    }
}
