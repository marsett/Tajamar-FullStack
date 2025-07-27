<template>
  <div>
    <h1>Mi primera App de Vue, qué ilusión!!</h1>
    <h2>Su nombre es {{ nombre }}</h2>
    <h2>El número es {{ numero }}</h2>
    <img src="./../assets/images/tucan.jpg"/>
  </div>
</template>

<script>
// Esto es código js (especial)
// Cada component que creemos siempre debemos
// exportarlo con un name
export default {
  name: "HolaMundo",
  data() {
    // Aquí debemos declarar las variables para el dibujo
    // Las variables son declaradas con formato JSON dentro
    // de un return
    return {
      nombre: "Alumno",
      numero: 14,
      miArray: [],
      objeto: {},
    };
  },
};
</script>

<style>
h1 {
  color: blue;
}
@import './../assets/css/estilos.css';
</style>