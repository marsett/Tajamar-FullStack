<template>
  <!-- <CochesComponent /> -->
  <!-- <CustomersComponent /> -->
  <!-- <EmpleadosDetalle /> -->
  <MenuComponent />
  <router-view></router-view>
</template>

<script>
import MenuComponent from "./components/MenuComponent.vue";
// import EmpleadosDetalle from './components/EmpleadosDetalle.vue'
// import CochesComponent from './components/CochesComponent.vue';
// import CustomersComponent from './components/CustomersComponent.vue';
export default {
  name: "App",
  components: {
    // CochesComponent
    // CustomersComponent
    // EmpleadosDetalle
    MenuComponent,
  },
};
</script>

<style>
/* #app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
} */
</style>
