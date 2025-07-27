<template>
  <div>
    <ul id="menu">
      <li><router-link to="/">Home</router-link> |</li>
      <li v-for="num in numeros" :key="num">
        <router-link :to="'/tabla/' + num">Tabla {{ num }}</router-link> |
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  name: "MenuTablaMultiplicar",
  methods: {
    nuevoNumero() {
      for (let i = 0; i < 5; i++) {
        var numero = parseInt(Math.random() * 100) + 1;
        this.numeros.push(numero);
      }
    },
  },
  mounted() {
    this.nuevoNumero();
  },
  data() {
    return {
      numeros: [],
    };
  },
};
</script>

<style>
ul#menu li {
  display: inline;
}
</style>
