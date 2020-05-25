﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourses.Interfaces
{
    public interface IPasswordProvider
    {
        string Hash(string password);

        bool VerifyHashedPassword(string password, string hashedPassword);
    }
}