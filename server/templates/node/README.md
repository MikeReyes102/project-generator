# Node Starter

A minimal Node.js starter template designed to provide a clean foundation for building command-line applications, utilities, and backend services.

This template includes a simple application entry point, a development workflow using Nodemon, and a lightweight project structure so development can begin immediately.

---

## Features

- Minimal project structure
- CommonJS module support
- Nodemon development workflow
- Application initialization pattern
- Organized and documented source code

---

## Project Structure

```text
node-starter/

├── src/
│   └── index.js
│       Application entry point.
│
├── package.json
│   Project configuration, scripts, and dependencies.
│
├── .gitignore
│   Files and folders excluded from source control.
│
└── README.md
    Project documentation.
```

---

## Getting Started

### 1. Install Dependencies

```bash
npm install
```

---

### 2. Start the Application

Development mode (recommended):

```bash
npm run dev
```

Production mode:

```bash
npm start
```

---

## Application Entry Point

The application begins in:

```text
src/index.js
```

The template includes an initialization function:

```javascript
function initializeApp() {

    console.log("Node starter initialized.");

}
```

Use this function as the starting point for your application logic.

---

## Notes

This starter is intentionally lightweight.

It does not include:

- Express
- Databases
- Testing frameworks
- Linters
- Environment configuration

Add additional packages and tooling as your project requires.

---
