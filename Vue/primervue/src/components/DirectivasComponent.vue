<template>
  <div>
    <h1>Ejemplo directivas VUE</h1>
    <h1>
      <!-- El símbolo dólar nos permite acceder a elementos
        dentro de Vue -->
      {{ $data }}
    </h1>
    <label>Introduzca número</label>
    <input type="number" v-model="numero" />
    <h2 v-if="numero > 0" style="color: green">Positivo</h2>
    <h2 v-else-if="numero < 0" style="color: red">Negativo</h2>
    <h2 v-else style="color: blue">Cero</h2>
    <ul v-if="series.length > 0">
        <li v-for="serie in series" :key="serie">
            {{serie}}
        </li>
    </ul>
  </div>
</template>

<script>
export default {
  name: "DirectivasComponent",
  data() {
    return {
      series: ["Futurama", "Suits", "The Boys", "Stranger Things"],
      numero: 0,
      nombre: "Alumno",
      edad: 25,
    };
  },
};
</script>

<style>
</style>