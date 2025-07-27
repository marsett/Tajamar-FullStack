<template>
  <div>
    <h1 style="color: blue">Home Component</h1>
    <h2 style="color: red">{{ mensaje }}</h2>
  </div>
</template>

<script>
import ServiceEjemplo from "./../services/ServiceEjemplo";
// Para poder utilizar el servicio, necesitamos una constante
// instanciada con la clase del servicio necesario
const service = new ServiceEjemplo();
export default {
  name: "HomeComponent",
  mounted() {
    this.mensaje = service.getSaludo("Alumno");
  },
  data() {
    return {
      mensaje: "",
    };
  },
};
</script>

<style>
</style>
