using AutoMapper;
using IShop.BusinessLayer.UnitTests.MockHelpers;
using IShop.BussinesLayer.Entities.Comment;
using IShop.BussinesLayer.Mapping;
using IShop.BussinesLayer.Providers;
using IShop.BussinesLayer.Providers.Interfaces;
using IShop.DataLayer.ShopDbContext;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IShop.BussinesLayer.Common.Exceptions;
using Domain = IShop.DataLayer.Entities;

namespace IShop.BusinessLayer.UnitTests
{
    [TestFixture]
    public class CommentProviderTests
    {
        private ICommentProvider _commentProvider;
        private List<Domain.Comment> _comments;

        [SetUp]
        public void SetUp()
        {
            _comments = new List<Domain.Comment>();
            var mockCommentRepository = MockHelper.GetMockRepository(_comments);

            var mockShopUnitOfWork = new Mock<IShopDbContext>();
            mockShopUnitOfWork.Setup(x => x.CommentRepository).Returns(mockCommentRepository.Object);

            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            var mapper = new Mapper(mapperConfig);

            _commentProvider = new CommentProvider(mockShopUnitOfWork.Object, mapper);
        }

        [TearDown]
        public void TearDown()
        {
            _comments.Clear();
        }

        [Test]
        public async Task Should_Create_New_Comment()
        {
            // Arrange
            var commentCreate = new CommentCreate
            {
                CommentText = "CommentText"
            };

            // Act
            var comment = await _commentProvider.CreateComment(commentCreate);

            // Assert
            Assert.AreEqual(_comments.First().CommentText, comment.CommentText);
        }

        [Test]
        public async Task Should_Delete_Comment()
        {
            // Arrange
            var comment = new Domain.Comment
            {
                CommentId = 1,
                CommentText = "CommentText"
            };
            _comments.Add(comment);

            // Act
            await _commentProvider.DeleteComment(comment.CommentId);

            // Assert
            Assert.IsEmpty(_comments);
        }

        [Test]
        public void Should_Not_Delete_Comment_If_It_Not_Found()
        {
            // Arrange
            var comment = new Domain.Comment
            {
                CommentId = 1,
                CommentText = "CommentText"
            };
            _comments.Add(comment);

            // Act & Assert
            Assert.ThrowsAsync<EntityNotFoundException>(
                () => _commentProvider.DeleteComment(100500));

            Assert.IsNotEmpty(_comments);
        }

        [Test]
        public async Task Should_Get_Comment_By_Id()
        {
            // Arrange
            _comments.AddRange(TestComments);
            var commentId = TestComments[0].CommentId;

            // Act
            var comment = await _commentProvider.GetComment(commentId);

            // Assert
            Assert.AreEqual(commentId, comment.CommentId);
        }

        [Test]
        public void Should_Not_Get_Comment_By_Id_If_It_Not_Found()
        {
            // Arrange
            var comment = new Domain.Comment
            {
                CommentId = 1,
                CommentText = "CommentText"
            };
            _comments.Add(comment);

            // Act & Assert
            Assert.ThrowsAsync<EntityNotFoundException>(
                () => _commentProvider.GetComment(100500));
        }

        [Test]
        public async Task Should_Get_All_Comments()
        {
            //Arrange
            _comments.AddRange(TestComments);

            //Act
            var commetns = await _commentProvider.GetAllComments();

            //Assert
            Assert.AreEqual(TestComments.Count, commetns.Count);
            CollectionAssert.AreEqual(
                TestComments.Select(x => x.CommentId),
                commetns.Select(x => x.CommentId));
        }

        [Test]
        public async Task Should_Get_Post_Comments()
        {
            //Arrange
            _comments.AddRange(TestComments);
            var postId = TestComments[0].PostId;

            //Act
            var commetns = await _commentProvider.GetPostComments(postId);

            //Assert
            CollectionAssert.AreEqual(
                TestComments
                    .Where(x => x.PostId == postId)
                    .Select(x => x.CommentId),
                commetns.Select(x => x.CommentId)
            );
        }

        private static List<Domain.Comment> TestComments => new List<Domain.Comment>
        {
            new Domain.Comment
            {
                CommentId = 1,
                PostId = 1,
                CommentText = "CommentText1"
            },
            new Domain.Comment
            {
                CommentId = 2,
                PostId = 1,
                CommentText = "CommentText2"
            },
            new Domain.Comment
            {
                CommentId = 3,
                PostId = 2,
                CommentText = "CommentText3"
            }
        };
    }
}
