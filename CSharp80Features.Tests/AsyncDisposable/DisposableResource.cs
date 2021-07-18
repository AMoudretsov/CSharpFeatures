using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharp80Features.Tests.AsyncDisposable
{
    public class DisposableResource : IDisposable, IAsyncDisposable
    {
        private readonly string _name;
        private readonly IList<string> _disposeLog;
        private bool _disposed = false;

        public DisposableResource(string name, IList<string> disposeLog)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _disposeLog = disposeLog ?? throw new ArgumentNullException(nameof(disposeLog));
        }

        public string Process()
        {
            return $"Call {nameof(DisposableResource)}.{nameof(Process)}";
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

            _disposeLog.Add(_name);
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore();
            Dispose(false);
            GC.SuppressFinalize(this);

            _disposeLog.Add(_name);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _disposed = true;
                // Dispose managed resources
            }

            // Dispose unmanaged resources
        }

        protected virtual async ValueTask DisposeAsyncCore()
        {
            await Task
                .Delay(TimeSpan.FromMilliseconds(100))
                .ConfigureAwait(false);
            // Dispose managed resources
        }

        ~DisposableResource()
        {
            Dispose(false);
        }
    }
}
