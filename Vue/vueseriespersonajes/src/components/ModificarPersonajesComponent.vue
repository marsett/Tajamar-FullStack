<template>
  <div>
    <h1 style="color: blue">Personaje y series</h1>
    <label>Seleccione una serie:</label>
    <select class="form-control" @change="mostrarSerieSeleccionada">
      <option v-for="serie in series" :key="serie" :value="serie.idSerie">
        {{ serie.nombre }}
      </option>
    </select>
    <label>Seleccione un personaje:</label>
    <select class="form-control" @change="mostrarPersonajeSeleccionado">
      <option
        v-for="personaje in personajes"
        :key="personaje"
        :value="personaje.idPersonaje"
      >
        {{ personaje.nombre }}
      </option>
    </select>
    <button class="btn btn-success mt-3" @click="guardarCambios">
      Guardar Cambios
    </button>

    <div v-if="serieSeleccionada" class="mt-3">
      <h2>{{ serieSeleccionada.nombre }}</h2>
      <img
        :src="serieSeleccionada.imagen"
        style="width: 200px; height: 200px"
      />
    </div>

    <div v-if="personajeSeleccionado" class="mt-3">
      <h2>{{ personajeSeleccionado.nombre }}</h2>
      <img
        :src="personajeSeleccionado.imagen"
        style="width: 200px; height: 200px"
      />
    </div>
  </div>
</template>

<script>
import ServicePersonajes from "./../services/ServicePersonajes";
import ServiceSeries from "./../services/ServiceSeries";
const service = new ServicePersonajes();
const serviceSeries = new ServiceSeries();
export default {
  name: "ModificarPersonajesComponent",
  data() {
    return {
      series: [],
      personajes: [],
      serieSeleccionada: null,
      personajeSeleccionado: null,
    };
  },
  mounted() {
    service.getPersonajes().then((result) => {
      this.personajes = result;
    });
    serviceSeries.getSeries().then((result) => {
      this.series = result;
    });
  },
  methods: {
    mostrarSerieSeleccionada(event) {
      const idSerie = event.target.value;
      this.serieSeleccionada = this.series.find(
        (serie) => serie.idSerie == idSerie
      );
    },
    mostrarPersonajeSeleccionado(event) {
      const idPersonaje = event.target.value;
      this.personajeSeleccionado = this.personajes.find(
        (personaje) => personaje.idPersonaje == idPersonaje
      );
    },
    guardarCambios() {
      if (this.serieSeleccionada && this.personajeSeleccionado) {
        this.personajeSeleccionado.idSerie = this.serieSeleccionada.idSerie;

        service
          .actualizarPersonaje(
            this.personajeSeleccionado,
            this.serieSeleccionada
          )
          .then(() => {
            console.log("Personaje movido a la nueva serie.");
            this.$router.push(
              "/personajes/" + this.personajeSeleccionado.idSerie
            );
          });
      }
    },
  },
};
</script>

<style>
</style>