<template>
  <PersonajesComponent />
</template>

<script>
import PersonajesComponent from './components/PersonajesComponent.vue';

export default {
  name: 'App',
  components: {
    PersonajesComponent
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
