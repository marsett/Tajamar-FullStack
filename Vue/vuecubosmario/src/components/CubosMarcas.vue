<template>
  <div class="container mt-5">
    <h1>Cubos de la marca <span style="color: red">{{ this.$route.params.marca }}</span></h1>
    <div class="row row-cols-1 row-cols-sm-2 row-cols-md-3 row-cols-lg-4 g-4">
      <div class="col" v-for="cubo of cubos" :key="cubo">
        <div class="card" style="width: 18rem">
          <img
            :src="cubo.imagen"
            class="card-img-top"
            alt="Imagen del producto"
          />
          <div class="card-body">
            <h5 class="card-title">{{ cubo.nombre }}</h5>
            <p class="card-text">{{ cubo.precio }} €</p>
            <router-link class="btn btn-primary" :to="'/detalles/' + cubo.idCubo"
              >Detalles</router-link
            >
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import ServiceCubos from "./../services/ServiceCubos";
const service = new ServiceCubos();
export default {
  name: "CubosMarcas",
  methods: {
    getCubosMarcas() {
      let marca = this.$route.params.marca;
      service.getCubosMarcas(marca).then((result) => {
        this.cubos = result;
      });
    },
  },
  data() {
    return {
      cubos: [],
    };
  },
  mounted() {
    this.getCubosMarcas();
  },
  watch: {
    "$route.params.marca"(nextVal, oldVal) {
      if (nextVal != oldVal) {
        this.getCubosMarcas();
      }
    },
  },
};
</script>

<style></style>