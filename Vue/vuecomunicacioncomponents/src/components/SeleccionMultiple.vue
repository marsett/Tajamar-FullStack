<template>
  <div>
    <h1>Selección múltiple</h1>
    <form v-on:submit.prevent="pintarDetalles()">
      <select multiple size="3" v-model="selectNombres">
        <option v-for="persona in nombres" :key="persona" :value="persona">
          {{ persona.nombre }}
        </option>
      </select>
      <br />
      <button>Pintar detalles</button>
    </form>
    <div v-if="seleccionados.length > 0">
      <div v-for="persona in seleccionados" :key="persona.nombre">
        <h1>{{ persona.nombre }}</h1>
        <h3>{{ persona.profesion }}</h3>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "SeleccionMultiple",
  methods: {
    pintarDetalles() {
      this.seleccionados = this.selectNombres;
    },
  },
  data() {
    return {
      nombres: [
        {
          nombre: "Mario",
          profesion: "Programador",
        },
        {
          nombre: "Kaños",
          profesion: "Rapero",
        },
        {
          nombre: "Pvlicarpo318",
          profesion: "Rapero",
        },
      ],
      seleccionados: [],
      selectNombres: [],
    };
  },
};
</script>

<style>
</style>