/*
    ============================================================================
    Project:
    Author:
    Created:
    Description:
    ============================================================================
*/


import { createRoot } from "react-dom/client";

import App from "./App";

import "./styles/global.css";
import "./styles/styles.css";



/*
    ============================================================================
    Application Entry Point
    ============================================================================
*/

createRoot(document.getElementById("root")).render(

    <App />

);