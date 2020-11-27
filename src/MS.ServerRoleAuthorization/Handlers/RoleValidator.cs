using MS.ServerRoleAuthorization.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace MS.ServerRoleAuthorization
{
    internal class RoleValidator : IValidator
    {
        public bool Validate(IEnumerable<RoleConfigurations> roleConfigurations, (string Action, string SubAction) action, ConfigurationOptions configurationOptions)
        {
            var result = false;

            var asteriskRoleConfigurations = roleConfigurations.FirstOrDefault(config => config.Roles.FirstOrDefault(role => role.Equals(Constants.Asterisk)) != null);

            if (asteriskRoleConfigurations != null)
            {
                result = SupportedActionsHelper.IsActionConfigured(action.Action, action.SubAction, asteriskRoleConfigurations.SupportedActions, asteriskRoleConfigurations.NotSupportedActions, configurationOptions);
            }

            if (!result)
            {
                //get all roles configured other than Asterisk and validate
                var otherRoleConfigurations = roleConfigurations.Where(config => config.Roles.FirstOrDefault(role => !role.Equals(Constants.Asterisk)) != null);

                foreach (var cR in otherRoleConfigurations)
                {
                    result = SupportedActionsHelper.IsActionConfigured(action.Action, action.SubAction, cR.SupportedActions, cR.NotSupportedActions, configurationOptions);

                    if (result)
                    {
                        break;
                    }
                }
            }

            return result;
        }
    }
}