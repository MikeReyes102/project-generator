const fs = require("fs/promises");
const path = require("path");

async function generate(project) {

    const templatePath = path.join(
        __dirname,
        "..",
        "templates",
        project.template
    );

    const outputPath = path.join(
        __dirname,
        "..",
        "..",
        "output",
        project.name
    );


    await fs.cp(
        templatePath,
        outputPath,
        {
            recursive: true
        }
    );


    return {
        success: true,
        projectName: project.name,
        location: outputPath
    };

}


module.exports = {
    generate
};