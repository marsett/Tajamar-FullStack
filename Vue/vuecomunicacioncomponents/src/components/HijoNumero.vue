<template>
  <div>
    <h1 style="color: blue">Número hijo: {{ numero }}</h1>
    <button @click="sumar()">Sumar {{ numero }}</button>
  </div>
</template>

<script>
export default {
  name: "HijoNumero",
  props: ["numero"],
  methods: {
    sumar() {
      this.$emit("mostrarSuma", this.numero);
    },
  },
};
</script>

<style></style>