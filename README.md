# Project Generator

A lightweight Node.js project generator that creates new starter projects from reusable templates. The app includes a browser-based interface for generating projects and a REST API for integrating the generator into other tools or workflows.

## Overview

Project Generator lets you:

- choose a project template
- enter a project name
- optionally specify an output directory
- generate a project in a consistent, reusable structure
- discover templates dynamically from the server template directory

The project is built with a simple server-client architecture and is designed to be easy to extend with additional template types.

## Features

- Template-based project generation
- Automatic template discovery from the server template directory
- Browser UI for generating new projects
- Configurable output location
- Default fallback output directory when no location is provided
- REST API for template discovery and project generation
- Template validation for supported project types
- Cross-platform path support
- Lightweight architecture for quick customization

## Tech Stack

### Backend
- Node.js
- Express
- CORS

### Frontend
- HTML
- CSS
- JavaScript

### Template Types
- HTML
- Node.js
- React + Vite

## Project Structure

```text
project-generator/
├── client/
│   ├── config/
│   ├── js/
│   │   ├── api.js
│   │   ├── app.js
│   │   └── ui.js
│   ├── index.html
│   ├── package.json
│   └── styles.css
├── server/
│   ├── handlers/
│   ├── routes/
│   ├── services/
│   ├── templates/
│   │   ├── html/
│   │   ├── node/
│   │   └── react/
│   ├── package.json
│   ├── server.js
│   └── package-lock.json
├── output/
├── API.md
├── package.json
├── README.md
└── .gitignore
```

## Getting Started

### Prerequisites

- Node.js 18+
- npm

### Install dependencies

From the project root, install the shared tooling dependencies:

```bash
npm install
```

Then install the server and client dependencies:

```bash
npm install --prefix server
npm install --prefix client
```

### Run the app

Start the backend and frontend together:

```bash
npm run dev
```

This runs:

- the Express API on port 3001
- the client with a local static server

### Access the application

- API: http://localhost:3001
- Client UI: http://localhost:5500

## Usage

1. Open the client in your browser.
2. Enter a project name.
3. Choose a template.
4. Optionally provide an output path.
5. Click Generate Project.

If no output path is supplied, the generator creates the project in the default `output/` directory.

Example:

```text
output/
└── MyProject/
```

If you provide a parent directory such as:

```text
/home/username/projects
```

and generate a project named `MyProject`, the result will be:

```text
/home/username/projects/MyProject
```

## API

The project exposes a REST API for template lookup and project generation.

### Available endpoints

- `GET /templates`
- `POST /generate`

For request and response details, examples, and validation behavior, see [API.md](API.md).

## Template System

Templates live in the server template directory:

```text
server/templates/
```

The generator automatically discovers folders in this location and makes them available to the app. To add a new template:

1. create a new folder under `server/templates/`
2. add the starter files for that template
3. restart the server

The new template will automatically appear in the UI and API output.

## Development Notes

The backend follows a simple route → handler → service flow:

```text
Client
  ↓
REST API
  ↓
Routes
  ↓
Handlers
  ↓
Generator Service
  ↓
Templates
```

This separation keeps the project easy to extend while supporting both browser and API-driven project generation.

## Current Status

This project is in active development and includes the core generator, template discovery, validation, configurable output paths, and a working web UI.

## Future Enhancements

Potential next steps include:

- downloadable project archives
- hosted or remote generation workflows
- additional templates
- richer template metadata
- CLI tooling
- expanded API integrations

## License

This project is currently distributed without a formal license file. If you plan to share or deploy it publicly, consider adding an appropriate open-source license.

## Contributing

Contributions are welcome. If you are improving the generator, adding templates, or refining the API, keep changes focused and maintain the existing project structure and conventions.
