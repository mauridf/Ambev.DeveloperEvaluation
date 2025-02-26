[Back to README](../README.md)

# Users API

## Create User

### POST /api/users
- **Description:** Creates a new user.

#### Request Body:
```json
{
  "username": "string",
  "email": "string",
  "password": "string"
}
```

#### Responses:
- **201 Created** (User created successfully)
  ```json
  {
    "success": true,
    "message": "User created successfully",
    "data": {
      "id": "guid",
      "username": "string",
      "email": "string"
    }
  }
  ```
- **400 Bad Request** (Validation errors)
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

---

## Get User by ID

### GET /api/users/{id}
- **Description:** Retrieves a user by their ID.

#### Path Parameters:
- `id` (GUID) - The unique identifier of the user.

#### Responses:
- **200 OK** (User retrieved successfully)
  ```json
  {
    "success": true,
    "message": "User retrieved successfully",
    "data": {
      "id": "guid",
      "username": "string",
      "email": "string"
    }
  }
  ```
- **400 Bad Request** (Validation errors)
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
- **404 Not Found** (User not found)
  ```json
  {
    "success": false,
    "message": "User not found"
  }
  ```

---

## Delete User

### DELETE /api/users/{id}
- **Description:** Deletes a user by their ID.

#### Path Parameters:
- `id` (GUID) - The unique identifier of the user to delete.

#### Responses:
- **200 OK** (User deleted successfully)
  ```json
  {
    "success": true,
    "message": "User deleted successfully"
  }
  ```
- **400 Bad Request** (Validation errors)
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
- **404 Not Found** (User not found)
  ```json
  {
    "success": false,
    "message": "User not found"
  }
  ```

---

<br/>
<div style="display: flex; justify-content: space-between;">
  <a href="./auth-api.md">Previous: Authentication API</a>
  <a href="./project-structure.md">Next: Project Structure</a>
</div>