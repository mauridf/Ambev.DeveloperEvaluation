[Back to README](../README.md)


### Authentication

#### POST /auth/login
- Description: Authenticate a user
- Request Body:
  ```json
  {
    "username": "string",
    "password": "string"
  }
  ```
- Responses: 
* 200 OK (User authenticated successfully)
  ```json
  {
    "success": true,
	  "message": "User authenticated successfully",
	  "data": {
		"token": "string"
	  }
  }
  ```
* 400 Bad Request (Validation errors)
  ```json
  {
    "errors": [
		{
		  "property": "string",
		  "message": "Validation error message"
		}
	  ]
  }
  ```
* 401 Unauthorized (Invalid credentials)
  ```json
  {
    "success": false,
	"message": "Invalid credentials"
  }
  ```
<br/>
<div style="display: flex; justify-content: space-between;">
  <a href="./users-api.md">Previous: Users API</a>
  <a href="./project-structure.md">Next: Project Structure</a>
</div>
