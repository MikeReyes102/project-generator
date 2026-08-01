const generator = require("../services/generator");

const templateHandler = async (req, res) => {

    try {

        const result = await generator.getTemplates();

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

module.exports = templateHandler;