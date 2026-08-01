const express = require("express");
const cors = require("cors");

const generateRoute = require("./routes/generate");
const templateRoute = require("./routes/templates");

const app = express();

app.use(cors());
app.use(express.json());

app.use("/generate", generateRoute);
app.use("/templates", templateRoute);

const PORT = 3001;

app.listen(PORT, () => {
    console.log(`🚀 Server running on port ${PORT}`);
});