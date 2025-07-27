<template>
  <div>
    <label>Introduzca número</label><br />
    <input type="number" v-model="numero" />
    <h2 :style="{ color: colorConmutado }">
      Resultado Conmutado: {{ parImparConmutado }}
    </h2>
    <button @click="getParImpar()">Resultado Botón</button>
    <h2 :style="{ color: colorBoton }" v-html="resultado"></h2>
    <h2 v-if="numero % 2 == 0" style="color: green">
      Resultado Directivas: Es PAR
    </h2>
    <h2 v-else style="color: blue">Resultado Directivas: Es IMPAR</h2>
  </div>
</template>

<script>
export default {
  name: "NumeroParImpar",
  computed: {
    parImparConmutado() {
      if (this.numero % 2 == 0) {
        return "Es PAR";
      } else {
        return "Es IMPAR";
      }
    },
    colorConmutado() {
      if (this.numero % 2 == 0) {
        return "green";
      } else {
        return "blue";
      }
    },
  },
  methods: {
    getParImpar() {
      this.resultado = "";
      if (this.numero % 2 == 0) {
        return (
          (this.resultado = "Resultado Botón: Es PAR"),
          (this.colorBoton = "green")
        );
      } else {
        return (
          (this.resultado = "Resultado Botón: Es IMPAR"),
          (this.colorBoton = "blue")
        );
      }
    },
  },
  data() {
    return {
      numero: 0,
      resultado: "",
      colorBoton: "",
    };
  },
};
</script>

<style>
</style>