const fs = require("fs/promises");
const path = require("path");

async function getTemplates() {

    const templatesPath = path.join(
        __dirname,
        "..",
        "templates"
    );

    const entries = await fs.readdir(
        templatesPath,
        {
            withFileTypes: true
        }
    );

    const templates = entries
        .filter(entry => entry.isDirectory())
        .map(entry => ({
            id: entry.name,
            name: formatTemplateName(entry.name)
        }));

    return {
        success: true,
        templates
    };

}

function formatTemplateName(name) {

    return name
        .split("-")
        .map(word =>
            word.charAt(0).toUpperCase() +
            word.slice(1)
        )
        .join(" ");

}

async function generate(project) {

    const templatePath = path.join(
        __dirname,
        "..",
        "templates",
        project.template
    );


    const defaultOutput = path.join(
        __dirname,
        "..",
        "..",
        "output"
    );


    const baseOutput = project.outputPath || defaultOutput;


    const outputPath = path.join(
        baseOutput,
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
    generate,
    getTemplates
};