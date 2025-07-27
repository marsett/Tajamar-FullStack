<template>
  <div>
    <ul id="menu">
      <li><router-link to="/">Home</router-link> |</li>
      <li><router-link to="/deportes/14">Deportes</router-link> |</li>
      <li><router-link to="/ejemplo">Ejemplo Checkbox</router-link> |</li>
      <li>
        <router-link to="/numerodoble">Número Doble sin parámetro</router-link>
        |
      </li>
      <li v-for="num in numeros" :key="num">
        <router-link :to="'/numerodoble/' + num"
          >Número Doble {{ num }}</router-link
        >
        |
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  name: "MenuComponent",
  data() {
    return {
      numeros: [3, 7, 9],
    };
  },
};
</script>

<style>
ul#menu li {
  display: inline;
}
</style>
