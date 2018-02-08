using IShop.DataLayer.Common.UnitOfWork;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IShop.BusinessLayer.UnitTests.MockHelpers
{
    public static class MockHelper
    {
        public static Mock<IRepository<T>> GetMockRepository<T>(List<T> sourceList) where T : class
        {
            var mockQuery = new Mock<IQueryable<T>>();
            var fakeAsyncEnumerable = new FakeAsyncEnumerable<T>(sourceList);

            mockQuery.As<IQueryable<T>>().Setup(x => x.Provider).Returns(fakeAsyncEnumerable.AsQueryable().Provider);
            mockQuery.As<IQueryable<T>>().Setup(x => x.Expression).Returns(fakeAsyncEnumerable.AsQueryable().Expression);
            mockQuery.As<IQueryable<T>>().Setup(x => x.ElementType).Returns(fakeAsyncEnumerable.AsQueryable().ElementType);
            mockQuery.As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(() => fakeAsyncEnumerable.AsQueryable().GetEnumerator());
            mockQuery.As<IAsyncEnumerable<T>>().Setup(x => x.GetEnumerator()).Returns(() => fakeAsyncEnumerable.GetEnumerator());

            var query = mockQuery.Object;

            var mockCommentRepository = new Mock<IRepository<T>>();
            mockCommentRepository.Setup(x => x.Add(It.IsAny<T>())).Callback<T>(sourceList.Add);
            mockCommentRepository.Setup(x => x.AddRange(It.IsAny<IEnumerable<T>>())).Callback<IEnumerable<T>>(sourceList.AddRange);
            mockCommentRepository.Setup(x => x.Remove(It.IsAny<T>())).Callback<T>(obj => sourceList.Remove(obj));
            mockCommentRepository.Setup(d => d.RemoveRange(It.IsAny<IEnumerable<T>>())).Callback<IEnumerable<T>>(obj =>
            {
                if (obj == null) return;
                obj.ForEach(x => sourceList.Remove(x));
            });
            mockCommentRepository.Setup(x => x.All).Returns(query);

            return mockCommentRepository;
        }

        private static void ForEach<T>(this IEnumerable<T> coll, Action<T> action)
        {
            if (coll != null && action != null)
            {
                foreach (var el in coll)
                    action(el);
            }
        }
    }
}