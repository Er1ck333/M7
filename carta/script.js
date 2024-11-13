// script.js
async function loadMenu() {
    // Ruta de acceso al archivo XML en GitHub
    const response = await fetch('https://raw.githubusercontent.com/Er1ck333/M7/main/carta%20xml/data.xml');
    const xmlText = await response.text();

    // Parsear el XML
    const parser = new DOMParser();
    const xmlDoc = parser.parseFromString(xmlText, "text/xml");

    // Obtener el elemento raíz de la carta
    const carta = xmlDoc.getElementsByTagName("CARTA")[0];
    const menuDiv = document.getElementById("menu");

    // Recorrer cada grupo de platos (por ejemplo, Entrantes, Principales, etc.)
    Array.from(carta.getElementsByTagName("GRUPO")).forEach(grupo => {
        // Crear un contenedor para cada grupo
        const grupoDiv = document.createElement("div");
        grupoDiv.classList.add("GRUPO");

        // Obtener y agregar el nombre del grupo (Ej. Entrantes)
        const nombreGrupo = grupo.getElementsByTagName("NOMBRE")[0].textContent;
        const nombreDiv = document.createElement("div");
        nombreDiv.classList.add("NOM");
        nombreDiv.textContent = nombreGrupo;
        grupoDiv.appendChild(nombreDiv);

        // Recorrer cada plato dentro del grupo
        Array.from(grupo.getElementsByTagName("PLATO")).forEach(plato => {
            // Crear contenedor para cada plato
            const platDiv = document.createElement("div");
            platDiv.classList.add("PLAT");

            // Obtener nombre, descripción y precio del plato
            const nombrePlato = plato.getElementsByTagName("NOMBRE")[0].textContent;
            const descripcionPlato = plato.getElementsByTagName("DESCRIPCION")[0].textContent;
            const precioPlato = plato.getElementsByTagName("PRECIO")[0].textContent;

            // Crear y agregar los elementos HTML correspondientes
            const nombrePlatoDiv = document.createElement("div");
            nombrePlatoDiv.classList.add("NOM");
            nombrePlatoDiv.textContent = nombrePlato;

            const descripcionDiv = document.createElement("div");
            descripcionDiv.classList.add("DESCRIPCION");
            descripcionDiv.textContent = descripcionPlato;

            const precioDiv = document.createElement("div");
            precioDiv.classList.add("PRECIO");
            precioDiv.textContent = `${precioPlato} €`;

            // Añadir el contenido del plato al contenedor de plato y luego al grupo
            platDiv.append(nombrePlatoDiv, descripcionDiv, precioDiv);
            grupoDiv.appendChild(platDiv);
        });

        // Añadir el grupo al menú principal
        menuDiv.appendChild(grupoDiv);
    });
}

// Llamada a la función para cargar el menú
loadMenu();
