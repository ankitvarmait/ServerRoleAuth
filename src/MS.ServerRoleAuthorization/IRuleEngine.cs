namespace MS.ServerRoleAuthorization
{
    public interface IRuleEngine
    {
        bool IsAllowed(string role, string actionName, string subActionName);

        bool IsAllowed(string role, string actionName);
    }
}