document.getElementById("myForm").addEventListener("submit", submitForm);

function submitForm(event) {
    event.preventDefault();
    var formData = new FormData(event.target);

    // Convert the FormData object to a JSON object
    var json = {};
    formData.forEach((value, key) => json[key] = value);

    let checkbox = document.querySelectorAll('input[type=checkbox]');
    let index = 0;
    var array = [];

    for (let i = 0; i < checkbox.length; i++)
    {
        if (checkbox[i].checked == true) {
            array.push(checkbox[i].value);
            index++
        }
    }
    json[`SelectedCheckboxes`] = array;

    fetch("https://localhost:7183/Home/Test", {
       /* mode: "cors",*/
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(json)  

    })
        .then(response => {
            if (!response.ok) {
                throw new Error("HTTP error" + response.status);
            }
            return response.json();
        })
        .then(data => {
            console.log("Success:", data);
        })
        .catch(error => {
            console.error("Error:", error);
        });
}
