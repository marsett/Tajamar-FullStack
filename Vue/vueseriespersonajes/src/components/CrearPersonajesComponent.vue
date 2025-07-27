<template>
  <div>
    <h1 style="color: blue">Nuevo Personaje</h1>
    <form
      v-on:submit.prevent="crearPersonaje()"
      style="width: 500px; margin: 0 auto"
    >
      <input
        type="hidden"
        v-model="personaje.idPersonaje"
        class="form-control"
      />
      <label>Nombre:</label>
      <input type="text" v-model="personaje.nombre" class="form-control" />
      <label>Imagen:</label>
      <input type="text" v-model="personaje.imagen" class="form-control" />
      <label>Serie:</label>
      <select class="form-control" v-model="personaje.idSerie">
        <option v-for="serie in series" :key="serie" :value="serie.idSerie">
          {{ serie.nombre }}
        </option>
      </select>
      <button class="btn btn-success">Insertar Personaje</button>
    </form>
  </div>
</template>

<script>
import ServicePersonajes from "./../services/ServicePersonajes";
import ServiceSeries from "./../services/ServiceSeries";
const service = new ServicePersonajes();
const serviceSeries = new ServiceSeries();
export default {
  name: "CrearPersonajesComponent",
  methods: {
    crearPersonaje() {
      service.crearPersonaje(this.personaje).then((result) => {
        this.mensaje = "Personaje insertado correctamente " + result;
        this.$router.push("/personajes/" + this.personaje.idSerie);
      });
    },
  },
  data() {
    return {
      mensaje: "",
      personaje: {
        idPersonaje: 0,
        nombre: "",
        imagen: "",
        idSerie: 0,
      },
      series: [],
    };
  },
  mounted() {
    serviceSeries.getSeries().then((result) => {
      this.series = result;
    });
  },
};
</script>

<style>
</style>