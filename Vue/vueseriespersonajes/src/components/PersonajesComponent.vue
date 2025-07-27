<template>
  <div>
    <h1>Personajes Component</h1>
    <router-link class="btn btn-danger" :to="'/series/' + this.$route.params.idSerie">Volver a serie</router-link>
    <table class="table table-warning">
      <thead>
        <tr>
          <th>Id Personaje</th>
          <th>Nombre</th>
          <th>Imagen</th>
          <th>Id Serie</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="detalle in personajes" :key="detalle">
          <td>{{ detalle.idPersonaje }}</td>
          <td>{{ detalle.nombre }}</td>
          <td>
            <img :src="detalle.imagen" style="width: 300px; height: 300px" />
          </td>
          <td>{{ detalle.idSerie }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import ServicePersonajes from "./../services/ServicePersonajes";
const service = new ServicePersonajes();
export default {
  name: "PersonajesComponent",
  methods: {
    cargarPersonajes() {
      let id = this.$route.params.idSerie;
      service.cargarPersonajes(id).then((result) => {
        this.personajes = result;
        console.log(this.personajes);
      });
    },
  },
  data() {
    return {
      personajes: [],
    };
  },
  mounted() {
    this.cargarPersonajes();
  },
  watch: {
    "$route.params.idSerie"(nextVal, oldVal) {
      if (nextVal != oldVal) {
        this.cargarPersonajes();
      }
    },
  },
};
</script>

<style>
</style>