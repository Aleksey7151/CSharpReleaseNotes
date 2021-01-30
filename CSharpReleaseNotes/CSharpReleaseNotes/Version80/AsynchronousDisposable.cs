using System;
using System.IO;
using System.Threading.Tasks;

namespace CSharpReleaseNotes.Version80
{
    internal class DisposableBase : IAsyncDisposable, IDisposable
    {
        private IDisposable _disposableResource = new MemoryStream();
        private IAsyncDisposable _asyncDisposableResource = new MemoryStream();

        public async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore();
            Dispose(disposing: false);

            // if Finalize method is defined in this class, than add
            // GC.SuppressFinalize(this);
        }

        public void Dispose()
        {
            Dispose(disposing: true);

            // if Finalize method is defined in this class, than add
            // GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _disposableResource?.Dispose();
                (_asyncDisposableResource as IDisposable)?.Dispose();
            }

            _disposableResource = null;
            _asyncDisposableResource = null;
        }

        protected virtual async ValueTask DisposeAsyncCore()
        {
            if (_asyncDisposableResource != null)
            {
                Console.WriteLine("Start async disposing...");
                await Task.Delay(3000);
                await _asyncDisposableResource.DisposeAsync().ConfigureAwait(false);
                Console.WriteLine("Async disposing finished.");
            }

            if (_disposableResource is IAsyncDisposable disposable)
            {
                await disposable.DisposeAsync().ConfigureAwait(false);
            }
            else
            {
                _disposableResource.Dispose();
            }

            _disposableResource = null;
            _asyncDisposableResource = null;
        }
    }

    internal class AsynchronousDisposable
    {
        public static async Task Sample()
        {
            var asyncDisposable = new DisposableBase();
            await using (asyncDisposable)
            {
                Console.WriteLine("Inside async using");
                await Task.Delay(500);
            }

            Console.WriteLine("Async dispose finished");
        }
    }
}
