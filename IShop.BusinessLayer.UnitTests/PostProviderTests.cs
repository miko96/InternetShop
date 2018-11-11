using AutoMapper;
using IShop.BusinessLayer.UnitTests.MockHelpers;
using IShop.BussinesLayer.Common.Exceptions;
using IShop.BussinesLayer.Entities.Comment;
using IShop.BussinesLayer.Entities.Post;
using IShop.BussinesLayer.Mapping;
using IShop.BussinesLayer.Providers;
using IShop.BussinesLayer.Providers.Interfaces;
using IShop.DataLayer.ShopDbContext;
using Moq;
using NUnit.Framework;
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

            var mockShopUnitOfWork = new Mock<IShopDbContext>();
            mockShopUnitOfWork.Setup(x => x.PostRepository).Returns(mockPostsRepository.Object);

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
        public async Task Should_Create_New_Post()
        {
            // Arrange
            var postCreate = new PostCreate
            {
                Content = "Content",
                Title = "Title",
                Comments = new[]
                {
                    new CommentCreate{ CommentText = "CommentText" }
                }
            };

            // Act
            var post = await _postProvider.CreatePost(postCreate);

            // Assert
            var createdPost = _posts.First();
            Assert.AreEqual(post.Content, createdPost.Content);
            Assert.AreEqual(post.Title, createdPost.Title);
            CollectionAssert.IsNotEmpty(createdPost.Comments);
            CollectionAssert.AreEqual(
                post.Comments.Select(x => x.CommentText),
                createdPost.Comments.Select(x => x.CommentText));
        }

        [Test]
        public async Task Should_Delete_Post()
        {
            // Arrange
            var post = new Domain.Post
            {
                Content = "Content",
                Title = "Title",
                Comments = new []
                {
                    new Domain.Comment{ CommentText = "CommentText" }
                }
            };
            _posts.Add(post);

            // Act
            await _postProvider.DeletePost(post.PostId);

            // Assert
            Assert.IsEmpty(_posts);
        }

        [Test]
        public void Should_Not_Delete_Post_If_It_Not_Found()
        {
            // Arrange
            var post = new Domain.Post
            {
                Content = "Content",
                Title = "Title",
                Comments = new[]
                {
                    new Domain.Comment{ CommentText = "CommentText" }
                }
            };
            _posts.Add(post);

            // Act & Assert
            Assert.ThrowsAsync<EntityNotFoundException>(
                () => _postProvider.DeletePost(100500));
            Assert.IsNotEmpty(_posts);
        }

        [Test]
        public async Task Should_Get_Post_By_Id()
        {
            // Arrange
            _posts.AddRange(TestPosts);
            var postId = TestPosts[0].PostId;

            // Act
            var post = await _postProvider.GetPost(postId);

            // Assert
            Assert.AreEqual(postId, post.PostId);
        }

        [Test]
        public void Should_Not_Get_Post_By_Id_If_It_Not_Found()
        {
            // Arrange
            _posts.AddRange(TestPosts);

            // Act & Assert
            Assert.ThrowsAsync<EntityNotFoundException>(
                () => _postProvider.GetPost(100500));
        }

        [Test]
        public async Task Should_Get_All_Posts()
        {
            // Arrange
            _posts.AddRange(TestPosts);

            //Act
            var posts = await _postProvider.GetAllPosts();

            //Assert
            Assert.AreEqual(TestPosts.Count, posts.Count);
            CollectionAssert.AreEqual(
                TestPosts.Select(x => x.PostId),
                posts.Select(x => x.PostId)
            );
        }

        private static List<Domain.Post> TestPosts => new List<Domain.Post>
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
