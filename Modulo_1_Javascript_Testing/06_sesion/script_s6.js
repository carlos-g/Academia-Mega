const usuario = {
    nombre: "Luis",
    edad: 18,
    ciudad: "Paris"
}

const usuarioJson = JSON.stringify(usuario);
console.log("JSON en texto:", usuarioJson);

const usuarioObjeto = JSON.parse(usuarioJson);
console.log("JSON  en objeto:", usuarioObjeto.nombre);

localStorage.setItem("usuario", usuarioJson);

const datosGuardados = localStorage.getItem("usuario");
const datosObjeto = JSON.parse(datosGuardados);
console.log(datosObjeto);

localStorage.removeItem("usuario");
