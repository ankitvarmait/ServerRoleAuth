using MS.ServerRoleAuthorization.Contracts;
using System.Collections.Generic;

namespace MS.ServerRoleAuthorization
{
    public interface ISetupConfigurations
    {
        IEnumerable<RoleConfigurations> RoleConfigurationsByRole(string role);

        ConfigurationOptions ConfigurationOptions();
    }
}