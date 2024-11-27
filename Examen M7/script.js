function moverTarea(tarea) {
    const hechasList = document.getElementById("hechas-list");
    tarea.removeAttribute("onclick"); // Evitar mover de vuelta
    hechasList.appendChild(tarea); // Mover a la lista de hechas
    tarea.style.backgroundColor = "#28a745"; // Cambiar color a verde
  }
  