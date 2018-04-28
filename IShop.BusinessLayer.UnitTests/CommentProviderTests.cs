using NUnit.Framework;
using Moq;
using Domain = IShop.DataLayer.Entities;
using IShop.DataLayer;
using System.Collections.Generic;
using System.Linq;
using IShop.BussinesLayer.Providers.Interfaces;
using IShop.BussinesLayer.Providers;
using IShop.BusinessLayer.UnitTests.MockHelpers;
using System.Threading.Tasks;
using AutoMapper;
using IShop.BussinesLayer.Mapping;
using IShop.BussinesLayer.Entities;
using System;

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

            var mockShopUnitOfWork = new Mock<IShopUnitOfWork>();
            mockShopUnitOfWork.Setup(x => x.Comments).Returns(mockCommentRepository.Object);

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
        public void Sould_Not_Delete_Comment_If_It_Not_Exitsts_And_Throw_Ex()
        {
            //Act & Assert
            Assert.ThrowsAsync<Exception>(
                () => _commentProvider.DeleteComment(100500)
            );
        }

        [Test]
        public async Task Sould_Delete_Comment()
        {
            var existsComment = TestComments.First();
            _comments.Add(existsComment);

            //Act
            await _commentProvider.DeleteComment(existsComment.CommentId);

            //Assert
            Assert.IsEmpty(_comments);
        }

        [Test]
        public void Sould_Not_Create_New_Comment_If_It_Exitsts_And_Throw_Ex()
        {
            //Arrange
            var newComment = new Comment
            {
                CommentId = 1,
                CommentText = "TestComment"
            };
            var existsComment = TestComments.First();
            _comments.Add(existsComment);

            //Act & Assert
            Assert.ThrowsAsync<Exception>(
                () => _commentProvider.CreateComment(newComment)
            );
        }

        [Test]
        public async Task Sould_Create_New_Comment()
        {
            //Arrange
            var newComment = new Comment
            {
                CommentText = "TestComment"
            };

            //Act
            await _commentProvider.CreateComment(newComment);

            //Assert
            Assert.AreEqual(_comments.First().CommentText, newComment.CommentText);
        }

        [Test]
        public async Task Sould_Get_Comment_By_Id()
        {
            //Arrange
            _comments.AddRange(TestComments);
            var commentId = TestComments.First().CommentId;

            //Act
            var commetn = await _commentProvider.GetComment(commentId);

            //Assert
            Assert.AreEqual(commentId, commetn.CommentId);
        }

        [Test]
        public async Task Sould_Get_All_Comments()
        {
            //Arrange
            _comments.AddRange(TestComments);

            //Act
            var commetns = await _commentProvider.GetAllComments();

            //Assert
            Assert.AreEqual(TestComments.Count(), commetns.Count);
            CollectionAssert.AreEqual(
                TestComments.Select(x => x.CommentId),
                commetns.Select(x => x.CommentId)
            );
        }

        [Test]
        public async Task Sould_Get_Post_Comments()
        {
            //Arrange
            _comments.AddRange(TestComments);
            var postId = TestComments.First().PostId;

            //Act
            var commetns = await _commentProvider.GetPostComments(postId);

            //Assert
            CollectionAssert.AreEqual(
                TestComments.Take(1).Select(x => x.CommentId),
                commetns.Select(x => x.CommentId)
            );
        }

        private ICollection<Domain.Comment> TestComments =>
            new List<Domain.Comment>
            {
                new Domain.Comment
                {
                    CommentId = 1,
                    PostId = 1,
                    CommentText = "TestComment1"
                },
                new Domain.Comment
                {
                    CommentId = 2,
                    CommentText = "TestComment2"
                },
                new Domain.Comment
                {
                    CommentId = 3,
                    CommentText = "TestComment3"
                }
            };
    }
}
