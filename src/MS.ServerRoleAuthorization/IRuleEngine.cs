namespace MS.ServerRoleAuthorization
{
    /// <summary>
    /// The engine that validates role with allowed requests.
    /// </summary>
    public interface IRuleEngine
    {
        /// <summary>
        /// Check if given <paramref name="role"/> is allowed to access to <paramref name="actionName"/> and <paramref name="subActionName"/> for <paramref name="group"/>.
        /// </summary>
        bool IsAllowed(string role, string actionName, string subActionName, string group = "*");

        /// <summary>
        /// <inheritdoc cref="IsAllowed(string, string, string, string)"/>
        /// </summary>
        bool IsAllowed(string role, string actionName, string group = "*");
    }
}