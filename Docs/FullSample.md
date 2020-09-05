# Full sample

Project Path: [ServerRoleAuthorization.FunctionalTests](https://github.com/ankitvarmait/ServerRoleAuth/blob/master/src/MS.ServerRoleAuthorization.FunctionalTests)

* [Configuration sample.](https://github.com/ankitvarmait/ServerRoleAuth/blob/master/src/MS.ServerRoleAuthorization.FunctionalTests/RoleBasedConfigurations.json) 
   ``` .cs       
         * Configuration says:
         * For system 1
         *      1. All Roles can access to Request D and all its sub requests.
         *      2. Role 2 and Role 3 can access to Request C and all its sub requests.
         *      3. Role 1 can access to following requests:
         *         3.1. Request A and Request Sub B
         *         3.2. Request A and Request Sub C
         *         3.1. Request C and All Request Sub requests
         *      4. Role 4 can access to all requests.
         * For system 2:
         *    
  ```
* [Server side changes.](https://github.com/ankitvarmait/ServerRoleAuth/blob/master/src/MS.ServerRoleAuthorization.FunctionalTests/TestContainer.cs)
* [Validate at server side.](https://github.com/ankitvarmait/ServerRoleAuth/blob/master/src/MS.ServerRoleAuthorization.FunctionalTests/ServerRoleTests.cs)

