using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Airbooking.Api.Providers
{
    /// <summary>
    /// Authorization Provider Class
    /// </summary>
    /// <seealso cref="Airbooking.Api.Providers.IHttpAuthorizationProvider" />
    public class HttpAuthorizationProvider:IHttpAuthorizationProvider
    {
        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public string UserId {
            get
            {
                if (HttpContext.Current == null
                    || HttpContext.Current.User == null
                    || HttpContext.Current.User.Identity == null)
                    return null;

                return HttpContext.Current.User.Identity.GetUserId();
            }
        }

        /// <summary>
        /// Gets the current email.
        /// </summary>
        /// <value>
        /// The current email.
        /// </value>
        public string CurrentEmail {
            get
            {
                if (HttpContext.Current == null
                    || HttpContext.Current.User == null
                    || HttpContext.Current.User.Identity == null)
                    return null;

                return HttpContext.Current.GetOwinContext()
                                .GetUserManager<ApplicationUserManager>()
                                .FindById(HttpContext.Current.User.Identity.GetUserId()).Email;
            }
        }
    }

    /// <summary>
    /// Authorization Provider Interface
    /// </summary>
    public interface IHttpAuthorizationProvider
    {
        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        string UserId { get; }

        /// <summary>
        /// Gets the current email.
        /// </summary>
        /// <value>
        /// The current email.
        /// </value>
        string CurrentEmail { get; }
    }
}