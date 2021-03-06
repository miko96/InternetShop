﻿using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IShop.BusinessLayer.UnitTests.MockHelpers
{
    public class FakeAsyncEnumerable<T> : EnumerableQuery<T>, IAsyncEnumerable<T>, IQueryable<T>
    {
        public FakeAsyncEnumerable(IEnumerable<T> enumerable)
            : base(enumerable)
        { }

        public FakeAsyncEnumerable(Expression expression)
            : base(expression)
        { }

        public IAsyncEnumerator<T> GetEnumerator()
        {
            return new FakeAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
        }

        IQueryProvider IQueryable.Provider => new FakeAsyncQueryProvider<T>(this);
    }
}
