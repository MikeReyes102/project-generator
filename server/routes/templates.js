const express = require("express");
const templateHandler = require("../handlers/templateHandler");

const router = express.Router();

router.get("/", templateHandler);

module.exports = router;