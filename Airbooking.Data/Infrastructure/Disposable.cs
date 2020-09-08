using System;

namespace Airbooking.Data.Infrastructure
{
    /// <summary>
    /// Disposable helper class
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class Disposable : IDisposable
    {
        private bool _isDisposed;

        /// <summary>
        /// Finalizes an instance of the <see cref="Disposable"/> class.
        /// </summary>
        ~Disposable()
        {
            Dispose(false);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        private void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing)
            {
                DisposeCore();
            }

            _isDisposed = true;
        }


        /// <summary>
        /// Disposes the core.
        /// </summary>
        protected virtual void DisposeCore()
        {
        }
    }
}
