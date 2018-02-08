using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IShop.BusinessLayer.UnitTests.MockHelpers
{
    public class FakeAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> _localEnumerator;

        public FakeAsyncEnumerator(IEnumerator<T> localEnumerator)
        {
            _localEnumerator = localEnumerator;
        }

        public void Dispose()
        {
            _localEnumerator.Dispose();
        }

        public Task<bool> MoveNext(CancellationToken cancellationToken)
        {
            return Task.FromResult(_localEnumerator.MoveNext());
        }

        public T Current => _localEnumerator.Current;
    }
}
