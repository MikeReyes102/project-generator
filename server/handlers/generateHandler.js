const generator = require("../services/generator");

const generateHandler = async (req, res) => {

    const { name, template } = req.body;

    if (!name?.trim()) {
        return res.status(400).json({
            success: false,
            message: "Project name is required."
        });
    }

    if (!template) {
        return res.status(400).json({
            success: false,
            message: "Project template is required."
        });
    }

    try {

        const result = await generator.generate(req.body);

        res.status(200).json(result);

    }
    catch (error) {

        console.error(error);

        res.status(500).json({
            success: false,
            message: error.message
        });

    }

};

module.exports = generateHandler;