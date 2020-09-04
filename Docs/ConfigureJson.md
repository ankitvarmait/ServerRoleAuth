# How To configure Role based configurations

### schema
```json
[
 "Group": "System1",
 "RoleConfigurations": [
	 {
	   "Roles": [ "" ],
	    "SupportedActions": [
	      {
		"Request": "",
		"RequestSubType": ""
	      }
	    ]
	 }
 ]
]
````
* Request : RequestName or api name or public method name defined at server side.
* RequestSubType: [optional]: An additional parameter to consider along with Request.
* Group:[optional]: Multiple configurations for multiple system or customers.  
  * For example: Group1 has different configurations than Group2.
  Use case: 
    1. Server supports two( can be added more as well) types of customers: customer1 and customer2.
    2. Roles and access are different for customer1 than customer2.
    3. Roles can be diffrent based on the region or location etc.
  
 * Use `*` in case for an optional parameter or should be consider for all.
 
E.g.
  * Valide for all roles:  
  
  ```json
     "Roles" : ["*"]
   ```
   * Valid for all requests:   
   ```json
     "Request": "*"
   ```   
   * Valid for all sub requests:
   ```json
     "RequestSubType": "*"
   ```
   
  * Define Role4 should have access to all requests. 
    * RequestSubType is an optional param in case we want to control with additional parameter.

  ```json
	{
	    "Roles": [ "Role4" ],
	    "SupportedActions": [
	      {
		"Request": "*",
		"RequestSubType": "*"
	      }
	    ]
	 }
   ```
 * Define Role2, Role3 should have access to Employee Read requests. 

  ```json
	{
	    "Roles": [ "Role2", "Role3" ],
	    "SupportedActions": [
	      {
		"Request": "EmployeeRead"
	      }
	    ]
	 }
   ```
 * Define Role4 should have access to Employee Read and write requests. 

  ```json
  
	{
	    "Roles": [ "Role4" ],
	    "SupportedActions": [
	      {
		"Request": "EmployeeRead"
	      },
	      {
		"Request": "EmployeeWrite"
	      }
	    ]
	 }
   ```
 * Define all roles should have access to Product Read requests. 
 
  ```json

	{
	    "Roles": [ "*" ], 
	    "SupportedActions": [
	      {
		"Request": "ProductRead"
	      }
	    ]
	 }
   ```
   
   * Define Role6 is allowed to read only employee data belong to Employer1, but can read and write employee data for Employer2

  ```json
	{
	    "Roles": [ "Role6" ],
	    "SupportedActions": [
	      {
		       "Request": "EmployeeRead",
           "RequestSubType": "Employer1"
	      },
        {
		       "Request": "EmployeeRead",
           "RequestSubType": "Employer2"
	      },
        {
		       "Request": "EmployeeWrite",
           "RequestSubType": "Employer2"
	      }
	    ]
	 }
   ```
   
   * Define Role 4 is allowed to access both read and write of Emmployee records if belongs to region 1, if belongs to region 2 only read access of Emmployee records.
   
   ```json
   [{   
     "Group": "Region 1",
     "RoleConfigurations": 
     [
        {
	   "Roles": ["Role 4"],
	   "SupportedActions": [
	     "Request" : "Employee",
	     "RequestSubType" : "*"
	   ]
	}
     ]},
     {
     "Group": "Region 2",
     "RoleConfigurations": 
     [
        {
	   "Roles": ["Role 4"],
	   "SupportedActions": [
	     "Request" : "Employee",
	     "RequestSubType" : "Read"
	   ]
	}
     ]}     
   ]
   
   ```
   
   
