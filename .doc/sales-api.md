# Sales API Documentation

## Endpoints

### Create Sale

**POST** `/api/Sales`

#### Request Body:
```json
{
  "productId": "string",
  "quantity": 0,
  "price": 0.0,
  "customerId": "string"
}
```

#### Responses:
- **201 Created**: Sale created successfully
- **400 Bad Request**: Validation errors

---

### Get Sale by ID

**GET** `/api/Sales/{id}`

#### Path Parameters:
- `id` (Guid, required): Unique identifier of the sale

#### Responses:
- **200 OK**: Returns sale details
- **400 Bad Request**: Validation errors
- **404 Not Found**: Sale not found

---

### Get All Sales

**GET** `/api/Sales`

#### Query Parameters (Optional):
- `customerId` (string): Filter sales by customer ID
- `startDate` (string, format: `YYYY-MM-DD`): Start date filter
- `endDate` (string, format: `YYYY-MM-DD`): End date filter

#### Responses:
- **200 OK**: Returns list of sales
- **400 Bad Request**: Validation errors

---

### Update Sale

**PUT** `/api/Sales/{id}`

#### Path Parameters:
- `id` (Guid, required): Unique identifier of the sale

#### Request Body:
```json
{
  "quantity": 0,
  "price": 0.0
}
```

#### Responses:
- **200 OK**: Sale updated successfully
- **400 Bad Request**: Validation errors
- **404 Not Found**: Sale not found

---

### Delete Sale

**DELETE** `/api/Sales/{id}`

#### Path Parameters:
- `id` (Guid, required): Unique identifier of the sale

#### Responses:
- **200 OK**: Sale deleted successfully
- **400 Bad Request**: Validation errors
- **404 Not Found**: Sale not found

---

<br/>
<div style="display: flex; justify-content: space-between;">
  <a href="./auth-api.md">Previous: Authentication API</a>
  <a href="./project-structure.md">Next: Project Structure</a>
</div>