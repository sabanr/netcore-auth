using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityExample.Data
{
    /// <summary>
    /// Contains all the users and roles tables
    /// </summary>
    public class AppDbContext: IdentityDbContext {      // IdentityDbcontext contains user and role tables

        public AppDbContext(DbContextOptions options) 
            :base(options) {

        }
    }
}
