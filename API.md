# NDS Project Generator API

The NDS Project Generator exposes a REST API for discovering available project templates and generating new projects from those templates.

---

## Base URL

```text
http://localhost:3001
```

The default server port is `3001`.

---

# Endpoints

## GET `/templates`

Returns the project templates currently available to the generator.

### Request

```http
GET /templates
```

No request body is required.

### Response

**200 OK**

```json
{
    "success": true,
    "templates": [
        {
            "id": "html",
            "name": "Html"
        },
        {
            "id": "node",
            "name": "Node"
        },
        {
            "id": "react",
            "name": "React"
        }
    ]
}
```

The available templates are discovered automatically from the `server/templates` directory.

Adding a new template directory makes it available through this endpoint without requiring changes to the API.

---

# POST `/generate`

Generates a new project using one of the available templates.

### Request

```http
POST /generate
Content-Type: application/json
```

### Request Body

```json
{
    "name": "MyProject",
    "template": "react",
    "outputPath": "/home/user/projects"
}
```

### Parameters

| Parameter    | Required | Description                                          |
| ------------ | -------- | ---------------------------------------------------- |
| `name`       | Yes      | Name of the generated project                        |
| `template`   | Yes      | ID of an available project template                  |
| `outputPath` | No       | Parent directory where the project should be created |

### Output Location

If `outputPath` is provided, the project is created inside that directory.

```text
outputPath/
└── ProjectName/
```

If `outputPath` is omitted or empty, the generator uses the default `output` directory.

```text
output/
└── ProjectName/
```

The generator is responsible for appending the project name to the supplied output path.

---

## Successful Response

**200 OK**

```json
{
    "success": true,
    "projectName": "MyProject",
    "location": "/home/user/projects/MyProject"
}
```

---

# Error Responses

## Missing Project Name

**400 Bad Request**

```json
{
    "success": false,
    "message": "Project name is required."
}
```

---

## Missing Template

**400 Bad Request**

```json
{
    "success": false,
    "message": "Project template is required."
}
```

---

## Invalid Template

**400 Bad Request**

```json
{
    "success": false,
    "message": "Template 'banana' does not exist."
}
```

---

## Server Error

**500 Internal Server Error**

```json
{
    "success": false,
    "message": "Error message."
}
```

Server errors are logged by the backend while a simplified error response is returned to the client.

---

# Example Workflow

A client can use the API in two steps.

### 1. Discover available templates

```http
GET /templates
```

### 2. Generate a project

```http
POST /generate
Content-Type: application/json
```

```json
{
    "name": "MyReactProject",
    "template": "react"
}
```

The generated project will be placed in the default output directory.

---

# API Architecture

The API follows a simple route → handler → service structure.

```text
Request
   │
   ▼
Route
   │
   ▼
Handler
   │
   ▼
Generator Service
   │
   ├── Template Discovery
   └── Project Generation
```

The API is designed to be consumed by the included web client or by other applications and tools that can make HTTP requests.
