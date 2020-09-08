using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Airbooking.Model
{
    /// <summary>
    /// User class
    /// </summary>
    /// <seealso cref="Airbooking.Model.BaseModel" />
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// User ID (Primary Key)
        /// </summary>
        public override string Id { get; set; }

        /// <summary>
        /// Gets or sets the hometown.
        /// </summary>
        /// <value>
        /// The hometown.
        /// </value>
        public string Hometown { get; set; }

        /// <summary>
        /// Gets or sets the bookings.
        /// </summary>
        /// <value>
        /// The bookings.
        /// </value>
        public virtual IEnumerable<Booking> Bookings { get; set; }

        /// <summary>
        /// Generates the user identity asynchronous.
        /// </summary>
        /// <param name="manager">The manager.</param>
        /// <returns></returns>
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
