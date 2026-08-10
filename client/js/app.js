async function loadTemplates() {

    const templateSelect = document.getElementById("template");

    try {

        const data = await getTemplates();

        templateSelect.innerHTML = "";

        data.templates.forEach(template => {

            const option = document.createElement("option");

            option.value = template.id;
            option.textContent = template.name;

            templateSelect.appendChild(option);

        });

    } catch (error) {

        displayResponse({
            success: false,
            message: error.message
        });

    }

}


async function onGenerate() {

    const project = {
        name: document.getElementById("projectName").value,
        template: document.getElementById("template").value,
        outputPath: document.getElementById("outputPath").value.trim()
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


document
    .getElementById("generateBtn")
    .addEventListener("click", onGenerate);


loadTemplates();