using MS.ServerRoleAuthorization.Contracts;
using System.Collections.Generic;

namespace MS.ServerRoleAuthorization
{
    public class RuleHandler : IRuleHandler
    {
        private readonly ISetupConfigurations setupConfigurations;
        private readonly IValidator validator;

        public RuleHandler(ISetupConfigurations setupConfigurations, IValidator validator)
        {
            this.setupConfigurations = setupConfigurations;
            this.validator = validator;
        }

        public virtual bool ExecuteRule(IEnumerable<RoleConfigurations> roleConfigurations, (string Action, string SubAction) action)
        {
            return validator.Validate(roleConfigurations, action, setupConfigurations.ConfigurationOptions());
        }
    }
}