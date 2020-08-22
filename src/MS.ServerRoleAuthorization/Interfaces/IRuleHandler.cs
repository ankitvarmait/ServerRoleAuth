﻿using MS.ServerRoleAuthorization.Contracts;
using System.Collections.Generic;

namespace MS.ServerRoleAuthorization
{
    internal interface IRuleHandler
    {
        bool ExecuteRule(IEnumerable<RoleConfigurations> roleConfigurations, (string Action, string SubAction) action);
    }
}