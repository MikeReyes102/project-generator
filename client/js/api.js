async function generateProject(project) {
    const response = await fetch(`${CONFIG.API_URL}/generate`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(project)
    });

    const data = await response.json();

    if (!response.ok) {
        throw new Error(data.message || "An unexpected error occurred.");
    }

    return data;
}