using System;
using System.Net;
using System.Web.Http;
using Airbooking.Utils.Logging;

namespace Airbooking.Utils
{
    /// <summary>
    /// Web Api Exception Helper Class
    /// </summary>
    public class ApiExceptionHelper
    {
        /// <summary>
        /// Wraps the exception.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func">The function.</param>
        /// <param name="logger">The logger.</param>
        /// <returns></returns>
        /// <exception cref="HttpResponseException">
        /// </exception>
        public static T WrapException<T>(Func<T> func, ILoggingService logger)
        {
            try
            {
                return func();
            }
            catch (ArgumentNullException ex)
            {
                logger?.Error(ex);
                throw new HttpResponseException(HttpStatusCode.ExpectationFailed);
            }
            catch (NotImplementedException ex)
            {
                logger?.Error(ex);
                throw new HttpResponseException(HttpStatusCode.NotImplemented);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                logger?.Error(ex);
                throw new HttpResponseException(HttpStatusCode.ExpectationFailed);
            }
            catch (Exception ex)
            {
                logger?.Error(ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Wraps the exception.
        /// </summary>
        /// <param name="func">The function.</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="HttpResponseException">
        /// </exception>
        public static void WrapException(Action func, ILoggingService logger)
        {
            try
            {
                func();
            }
            catch (ArgumentNullException ex)
            {
                logger?.Error(ex);
                throw new HttpResponseException(HttpStatusCode.ExpectationFailed);
            }
            catch (NotImplementedException ex)
            {
                logger?.Error(ex);
                throw new HttpResponseException(HttpStatusCode.NotImplemented);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                logger?.Error(ex);
                throw new HttpResponseException(HttpStatusCode.ExpectationFailed);
            }
            catch (Exception ex)
            {
                logger?.Error(ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}
