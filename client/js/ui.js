function displayResponse(data) {
    document.getElementById("response").textContent =
        JSON.stringify(data, null, 4);
}