<template>
  <div>
    <h1>Serie Component</h1>
    <div class="card mb-3" style="max-width: 540px">
      <div class="card-body">
        <img
          :src="serie.imagen"
          class="card-img-top"
          style="width: 300px; height: 300px"
          alt="Imagen de la serie"
        />
        <h5 class="card-title">{{ serie.nombre }}</h5>
        <p class="card-text">IMDB: {{ serie.puntuacion }}</p>
        <p class="card-text">Año: {{ serie.anyo }}</p>
        <router-link class="btn btn-success" :to="'/personajes/' + serie.idSerie">Personajes</router-link>
      </div>
    </div>
  </div>
</template>

<script>
import ServiceSeries from "./../services/ServiceSeries";
const service = new ServiceSeries();
export default {
  name: "SerieComponent",
  methods: {
    cargarDetallesSerie() {
      let id = this.$route.params.idSerie;
      service.cargarDetallesSerie(id).then((result) => {
        this.serie = result;
        console.log(this.serie);
      });
    },
  },
  data() {
    return {
      serie: [],
    };
  },
  mounted() {
    this.cargarDetallesSerie();
  },
  watch: {
    "$route.params.idSerie"(nextVal, oldVal) {
      if (nextVal != oldVal) {
        this.cargarDetallesSerie();
      }
    },
  },
};
</script>

<style>
</style>