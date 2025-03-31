
// Crear una función que devuelva otra función  que multiplica

function multiplicador(factor) {
    return function(numero) {
       return numero * factor;
    }
 }
 
 const duplicar = multiplicador(2);
 const triplicar = multiplicador(3);
 
 console.log('iniciamos');
 console.log(duplicar(6));
 console.log(triplicar(6));
 console.log('finaliza');
 
 