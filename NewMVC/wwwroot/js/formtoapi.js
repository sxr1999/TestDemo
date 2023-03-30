document.getElementById("myForm").addEventListener("submit", submitForm);

function submitForm(event) {
    event.preventDefault();
    var formData = new FormData(event.target);

    fetch("http://localhost:5239/api/Forms/submit-form", {
        mode: "cors",
        method: "POST",
        body: formData
    })
        .then(response => {
            if (!response.ok) {
                throw new Error("HTTP error" + respsonse.status);
            }
            return response.json();
        })
        .then(data => {
            console.log("Success:", data);
            //   getFormData();
        })
        .catch(error => {
            console.error("Error:", error);
        });
}
