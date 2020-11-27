using MS.ServerRoleAuthorization.Contracts;
using System;
using System.Linq;

namespace MS.ServerRoleAuthorization
{
    internal class SupportedActionsHelper
    {
        public static bool IsActionConfigured(string action, string subAction, SupportedActions[] supportedActions, SupportedActions[] notSupportedActions, ConfigurationOptions configurationOptions)
        {
            var isActionAllowed = false;

            // Does it allow all requests
            if (supportedActions.Any(sa => sa.Request.Equals(Constants.Asterisk)))
            {
                isActionAllowed = true;
            }
            else
            {
                // Check Action, if configured
                // var actionConfigured = SupportedActions.FirstOrDefault(sa => sa.Request.Equals(action, configurationOptions.EnableIgnoreCaseMode ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal));
                var actionsConfigured = supportedActions.Where(sa => sa.Request.Equals(action, configurationOptions.EnableIgnoreCaseMode ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal));


                // If not found then not allowed.
                if (actionsConfigured == null && !actionsConfigured.Any())
                {
                    isActionAllowed = false;
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

                    isActionAllowed = result;

                }
            }

            // if action is allowed we should check if that action is not allowed also, if not then send notAllowed
            if(isActionAllowed)
            {
                if(notSupportedActions != null && notSupportedActions.Any())
                {
                    // it means notSupportedActions configured.
                    var notsupportedActionsConfigured = notSupportedActions.Where(sa => sa.Request.Equals(action, configurationOptions.EnableIgnoreCaseMode ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal));

                    // If not found then not allowed.
                    if (notsupportedActionsConfigured == null && !notsupportedActionsConfigured.Any())
                    {
                        // it means no notSupportedActions configured so we are good.
                    }
                    else
                    {
                        // it means notSupportedActions configured for this request

                        var subResult_IsAllowed = true;

                        foreach (var actionConfigured in notsupportedActionsConfigured)
                        {
                            //Request is configured.

                            //If configured request = * then not allow
                            if (actionConfigured.Request.Equals(Constants.Asterisk))
                            {
                                subResult_IsAllowed = false;
                                break;
                            }

                            // check if incoming request == configured request

                            if (actionConfigured.Request.Equals(action, configurationOptions.EnableIgnoreCaseMode ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal))
                            {
                                // if sub action is * then not allowed
                                if (subAction.Equals(Constants.Asterisk))
                                {
                                    subResult_IsAllowed = false;
                                    break;
                                }

                                // check sub action

                                //If configured sub action is * then not allowed
                                if (actionConfigured.RequestSubType.Equals(Constants.Asterisk))
                                {
                                    subResult_IsAllowed = false;
                                    break;
                                }

                                //check sub action
                                if (actionConfigured.RequestSubType.Equals(subAction, configurationOptions.EnableIgnoreCaseMode ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal))
                                {
                                    subResult_IsAllowed = false;
                                    break;
                                }
                            }
                        }

                        isActionAllowed = subResult_IsAllowed;
                    }

                }
                else
                {
                    // it means no notSupportedActions configured so we are good.
                }

            }

            return isActionAllowed;
        }
    }
}