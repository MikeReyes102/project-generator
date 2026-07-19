document
    .getElementById("generateBtn")
    .addEventListener("click", onGenerate);

async function onGenerate() {

    const project = {
        name: document.getElementById("projectName").value,
        template: document.getElementById("template").value
    };

    try {

        const result = await generateProject(project);

        displayResponse(result);

    } catch (error) {

        displayResponse({
            success: false,
            message: error.message
        });

    }

}