using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FecbookDemoAPI.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {

        // constructor
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }


    }
}
