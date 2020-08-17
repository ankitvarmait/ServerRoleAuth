using MS.ServerRoleAuthorization.Contracts;
using System.Collections.Generic;

namespace MS.ServerRoleAuthorization
{
    public interface IValidator
    {
        bool Validate(IEnumerable<RoleConfigurations> roleConfigurations, (string Action, string SubAction) action, ConfigurationOptions configurationOptions);
    }
}