using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Budulea_Denis_LAB2.Data
{

        public class LibraryIdentityContext : IdentityDbContext<IdentityUser>
        {
            public LibraryIdentityContext(DbContextOptions<LibraryIdentityContext> options)
                : base(options)
            {
            }
        }
    
}
