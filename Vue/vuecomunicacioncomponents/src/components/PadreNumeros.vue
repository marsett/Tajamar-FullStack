<template>
  <div>
    <h1 style="color: black">Números Padre</h1>
    <h2 style="color: red">La suma es: {{ suma }}</h2>
    <button @click="nuevoNumero()">Nuevo Número</button>
    <span v-for="num in numeros" :key="num">
      <HijoNumero :numero="num" v-on:mostrarSuma="mostrarSuma" />
    </span>
  </div>
</template>

<script>
import HijoNumero from "./HijoNumero.vue";
export default {
  name: "PadreNumeros",
  methods: {
    nuevoNumero() {
      var numero = parseInt(Math.random() * 100) + 1;
      this.numeros.push(numero);
    },
    mostrarSuma(numero) {
      this.suma += numero;
    },
  },
  components: {
    HijoNumero,
  },
  data() {
    return {
      numeros: [3, 7, 9],
      suma: 0,
    };
  },
};
</script>

<style></style>