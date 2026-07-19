const express = require("express");
const generateHandler = require("../handlers/generateHandler");

const router = express.Router();

router.post("/", generateHandler);

module.exports = router;