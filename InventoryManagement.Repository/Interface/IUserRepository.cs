﻿using InventoryManagement.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Repository.Interface
{
    public interface IUserRepository: IBaseRepository<User>
    {
        User FindUserByEmail(string email);
        User FindUserByEmailAndPassword(string email, string password);
    }
}
