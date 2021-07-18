using System;
using System.Collections.Generic;

namespace CSharp80Features.Tests.UsingDeclarations
{
    public class DisposableResource : IDisposable
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
            if (!_disposed)
            {
                _disposed = true;
                _disposeLog.Add(_name);
            }
        }
    }
}
