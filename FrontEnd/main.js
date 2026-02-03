window.addEventListener('DOMContentLoaded', (event) => {
    getVisitCount();
});

const functionApi = 'https://api-resume-marcos-v1.azurewebsites.net/api/getresumecounter?code=UMXTMJEFDe9GFyqxrOEAANEq17o5HQObDl1O4eEWx0vYAzFuYNghkw%3D%3D'; // Tu API Local
const productionApi = ''; // Aquí pondremos la URL de la nube luego

const getVisitCount = () => {
    let count = 30; // Valor por defecto si falla

    fetch(functionApi)
        .then(response => {
            return response.json()
        })
        .then(response => {
            console.log("¡Llamada a la API exitosa!");
            count = response.count;
            document.getElementById("counter").innerText = count;
        })
        .catch(function (error) {
            console.log(error);
        });
    return count;
}