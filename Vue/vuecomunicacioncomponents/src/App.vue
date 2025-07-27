<template>
  <!-- <div>
    <PadreDeportes />
    <PadreNumeros />
    <ComicsComponent />
    <SeleccionMultiple />
    <EjemploCheckbox />
  </div> -->
  <div>
    <!-- <MenuComponent /> -->
    <MenuTablaMultiplicar />
    <hr />
    <router-view></router-view>
    <hr />
  </div>
</template>

<script>
// import SeleccionMultiple from './components/SeleccionMultiple.vue';
// import ComicsComponent from './components/ComicsComponent.vue';
// import PadreDeportes from "./components/PadreDeportes.vue";
// import PadreNumeros from "./components/PadreNumeros.vue";
// import EjemploCheckbox from './components/EjemploCheckbox.vue';
// import MenuComponent from "./components/MenuComponent.vue";
import MenuTablaMultiplicar from './components/MenuTablaMultiplicar.vue';

export default {
  name: "App",
  components: {
    // PadreDeportes,
    // PadreNumeros
    // ComicsComponent
    // SeleccionMultiple
    // EjemploCheckbox
    // MenuComponent
    MenuTablaMultiplicar
  },
};
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
