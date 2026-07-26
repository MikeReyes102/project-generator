# React Starter

A minimal React starter template built with Vite.

This template provides a clean foundation for building React applications with a lightweight project structure, modern tooling, and an organized styling approach.

---

## Features

- React 19 support
- Vite development environment
- Component-based architecture
- Global CSS foundation
- Custom application styling
- Hot module replacement during development
- Production build support

---

## Project Structure

```text
react-starter/

├── src/
│
│   ├── App.jsx
│   │   Main application component.
│   │
│   ├── main.jsx
│   │   React application entry point.
│   │
│   └── styles/
│       │
│       ├── global.css
│       │   Foundation styles including:
│       │   - CSS variables
│       │   - Reset styles
│       │   - Base defaults
│       │
│       └── styles.css
│           Application-specific styling.
│
├── index.html
│   HTML entry point and React mount location.
│
├── package.json
│   Project configuration and dependencies.
│
├── vite.config.js
│   Vite configuration.
│
├── .gitignore
│   Files excluded from source control.
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

### 2. Start Development Server

```bash
npm run dev
```

The application will start using Vite's development server.

---

### 3. Create Production Build

```bash
npm run build
```

This creates an optimized production build inside the `dist` directory.

---

### 4. Preview Production Build

```bash
npm run preview
```

---

## Application Structure

The React application starts in:

```text
src/main.jsx
```

This file mounts the React application to:

```html
<div id="root"></div>
```

The main application component is located at:

```text
src/App.jsx
```

Use this file as the starting point for building your application.

---

## Styling

This template separates foundational styling from application styling.

### global.css

Used for:

- CSS variables
- Browser resets
- Typography defaults
- Base element styling

### styles.css

Used for:

- Layout
- Components
- Application-specific designs

---

## Notes

This starter is intentionally lightweight.

It does not include:

- React Router
- State management libraries
- UI frameworks
- Testing frameworks
- API integrations

Add additional packages and tooling as your project requires.

---
