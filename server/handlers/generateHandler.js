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

        const templateData = await generator.getTemplates();

        const templateExists = templateData.templates.some(
            item => item.id === template
        );


        if (!templateExists) {

            return res.status(400).json({
                success: false,
                message: `Template '${template}' does not exist.`
            });

        }


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