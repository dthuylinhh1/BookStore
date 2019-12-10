﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    // used to manage roles for authentications, inherits from IdentityRole 
    public class ApplicationRole : IdentityRole
    {
    }
}
