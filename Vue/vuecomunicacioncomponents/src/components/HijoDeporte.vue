<template>
  <div>
    <li style="color: red">
      {{ nombredeporte }}
      <button @click="seleccionarFavorito()">Seleccionar favorito</button>
    </li>
  </div>
</template>

<script>
export default {
  name: "HijoDeporte",
  props: ["nombredeporte"],
  methods: {
    seleccionarFavorito() {
      console.log("Soy el hijo");
      // Debemos realizar la llamada al padre
      // Dicha llamada se hace mediante strint "nombreMetodoParent"
      // Para enviar información, se realiza con comas por cada parámetro
      // que tengamos en la recepción
      this.$emit("seleccionarFavoritoParent", this.nombredeporte);
    },
  },
  mounted() {
    console.log(this.nombredeporte);
  },
};
</script>

<style>
</style>