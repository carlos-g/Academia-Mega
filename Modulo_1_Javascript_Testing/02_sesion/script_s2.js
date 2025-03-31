let intentos = 0;
let claveCorrecta = 'abcd';
let claveIngresada;

while (intentos < 3) {
    claveIngresada = prompt("Ingrese la Clave");

    if (claveIngresada === claveCorrecta) {
        console.log('Acceso Correcto');
        break;
    } else {
        console.log('Clave incorrecta, trate de nuevo');
    }
    intentos++
}

if (intentos ===  3) {
    console.log('Has excedido tus intentos');
}