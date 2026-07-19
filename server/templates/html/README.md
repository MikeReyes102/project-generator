# New Project - HTML Starter

A minimal HTML, CSS, and JavaScript starter template designed to provide a clean foundation for building static websites and simple web projects.

This template includes a basic page structure, CSS foundation, and JavaScript initialization pattern so development can begin immediately.

---

## Features

- Semantic HTML5 structure
- Responsive viewport configuration
- SEO metadata placeholders
- Global CSS reset and variables
- Custom stylesheet for project-specific styling
- Basic JavaScript initialization pattern
- Organized file structure

---

## Project Structure

```text
project-name/
├── index.html
│   Main application entry point.
│
├── global.css
│   Foundation styles including:
│   - CSS variables
│   - Browser reset
│   - Base typography
│   - Accessibility-focused defaults
│
├── styles.css
│   Project-specific styling.
│   Customize layout, components, and visual design here.
│
├── script.js
│   JavaScript functionality and application initialization.
│
└── README.md

```

---

## Getting Started

### 1. Clone or copy the project

Place the project files in your desired development location.

### 2. Update project information

Update the placeholders in `index.html`:

- Project
- Author
- Created
- Description

Also update:

- Page title
- SEO description
- Author metadata

### 3. Customize styling

Use `global.css` for:

- Variables
- Reset rules
- Global styles

Use `styles.css` for:

- Layout
- Components
- Page-specific styling

### 4. Add functionality

Add JavaScript functionality in `script.js`.

The template includes an initialization function:

```js
function initializeApp() {
  console.log("Application initialized.");
}
```

Use this function as the starting point for project logic.

---

## Browser Support

This template is designed to work with modern browsers including:

- Google Chrome
- Mozilla Firefox
- Microsoft Edge
- Safari

---

## Notes

This starter is intentionally lightweight.

It does not include:

- External libraries
- Frameworks
- Build tools
- Package dependencies

Add additional tools and dependencies as needed based on project requirements.

---

## Why This Starter Stays Simple

### No installation section

There is nothing to install. Someone should be able to open `index.html` and start.

### No framework language

This keeps it useful for:

- Personal sites
- Prototypes
- School projects
- Static pages
- Quick experiments

### The CSS relationship is documented

This is one of the most useful parts of the starter:

```text
global.css -> foundation
styles.css -> customization
```

---
