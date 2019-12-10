using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    //inherit from asp.net identity's IdentityUser class for authentication 
    public class ApplicationUser : IdentityUser
    {
    }
}
