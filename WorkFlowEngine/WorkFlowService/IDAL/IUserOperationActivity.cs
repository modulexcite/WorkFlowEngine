﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkFlowService.Help;

namespace WorkFlowService.IDAL
{
    public interface IUserOperationActivity
    {
        string Crebool CreateUser(string userName, string password);

        string LoginIn(string userName, string password);

        bool ModifyPassword(string userId, string password);

        bool DeleteUser(string userId);

        bool AssignUserRole(string userId, string workflowState);

        bool ModifyUserRole(string userId, string workflowState);

        bool DeleteUserRole(string userId);
    }
}