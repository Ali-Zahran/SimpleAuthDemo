using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FecbookDemoAPI.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Content { get; set; }
    }
}
