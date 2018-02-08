using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace IShop.BusinessLayer.UnitTests.MockHelpers
{
    public class FakeAsyncQueryProvider<T> : IAsyncQueryProvider
    {
        private readonly IQueryProvider _localQueryProvider;

        internal FakeAsyncQueryProvider(IQueryProvider localQueryProvider)
        {
            _localQueryProvider = localQueryProvider;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            return new FakeAsyncEnumerable<T>(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new FakeAsyncEnumerable<TElement>(expression);
        }

        public object Execute(Expression expression)
        {
            return _localQueryProvider.Execute(expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return _localQueryProvider.Execute<TResult>(expression);
        }

        public IAsyncEnumerable<TResult> ExecuteAsync<TResult>(Expression expression)
        {
            return new FakeAsyncEnumerable<TResult>(expression);
        }

        public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute<TResult>(expression));
        }
    }
}
