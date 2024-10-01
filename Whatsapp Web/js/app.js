// Seleccionamos el input y la zona de chat
const inputMensaje = document.getElementById('inputMensaje');
const zonaChat = document.getElementById('chat');

// Agregamos un listener para detectar cuando se presiona la tecla "Enter"
inputMensaje.addEventListener('keypress', function(event) {
    if (event.key === 'Enter' && inputMensaje.value.trim() !== '') {
        
        event.preventDefault();
        
        // Creamos un nuevo div para el mensaje
        const nuevoMensaje = document.createElement('div');
        nuevoMensaje.classList.add('mensaje_verde');
        nuevoMensaje.textContent = inputMensaje.value; // Añadimos el texto del input
        
        // Agregamos el nuevo mensaje a la zona de chat
        zonaChat.prepend(nuevoMensaje); // Añade el mensaje al inicio para que los más nuevos estén abajo
        // Limpiamos el input después de enviar el mensaje
        if (inputMensaje.value === 'hola'){
            const mensajeErick = document.createElement('div');
            mensajeErick.classList.add('mensaje_erick');
            mensajeErick.textContent = "Hola, ¿Que tal?";
            zonaChat.prepend(mensajeErick);
        }
        inputMensaje.value = '';
        
        zonaChat.scrollTop = zonaChat.scrollHeight;
    }
});
