using MS.ServerRoleAuthorization.Contracts;
using System;
using System.Linq;

namespace MS.ServerRoleAuthorization
{
    public class SupportedActionsHelper
    {
        public static bool IsActionConfigured(string action, string subAction, SupportedActions[] SupportedActions, ConfigurationOptions configurationOptions)
        {
            // Does it allow all requests
            if (SupportedActions.Any(sa => sa.Request.Equals(Constants.Asterisk)))
            {
                return true;
            }

            // Check Action, if configured
            // var actionConfigured = SupportedActions.FirstOrDefault(sa => sa.Request.Equals(action, configurationOptions.EnableIgnoreCaseMode ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal));
            var actionsConfigured = SupportedActions.Where(sa => sa.Request.Equals(action, configurationOptions.EnableIgnoreCaseMode ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal));


            // If not found then not allowed.
            if (actionsConfigured == null && !actionsConfigured.Any())
            {
                return false;
            }
            else
            {
                var result = false;

                foreach (var actionConfigured in actionsConfigured)
                { 
                    //Request is configured.

                    //If configured request = * then allow
                    if (actionConfigured.Request.Equals(Constants.Asterisk))
                    {
                        result = true;
                        break;
                    }

                    // check if incoming request == configured request

                    if (actionConfigured.Request.Equals(action, configurationOptions.EnableIgnoreCaseMode ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal))
                    {
                        // if sub action is * then allowed
                        if (subAction.Equals(Constants.Asterisk))
                        {
                            result = true;
                            break;
                        }

                        // check sub action

                        //If configured sub action is * then allowed
                        if (actionConfigured.RequestSubType.Equals(Constants.Asterisk))
                        {
                            result = true;
                            break;
                        }

                        //check sub action
                        if (actionConfigured.RequestSubType.Equals(subAction, configurationOptions.EnableIgnoreCaseMode ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal))
                        {
                            result = true;
                            break;
                        }
                    }
                }

                return result;

            }
        }
    }
}