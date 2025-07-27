<template>
  <div>
    <h1>Servicio Api Coches</h1>
    <div v-for="car in coches" :key="car">
        <h2 style='color: blue'>
            {{car.marca}} {{car.modelo}}
        </h2>
        <p>Conductor: {{car.conductor}}</p>
        <img :src="car.imagen" style="width: 150px; height: 150px"/>
    </div>
  </div>
</template>

<script>
import ServiceCoches from './../services/ServiceCoches';
const service = new ServiceCoches();
// Si necesitamos variables declaradas para utilizarlas en todos los métodos
// (mounted, created, methods) la declaramos aquí

export default {
  name: "CochesComponent",
  data() {
    return {
        coches: []
    }
  },
  mounted() {
    // Las variables declaradas por encima de export default no utilizan
    // la palabra this
    // Una promesa no es un método, es un objeto
    service.getCoches.then(result => {
      this.coches = result;
    })
  }
};
</script>

<style></style>