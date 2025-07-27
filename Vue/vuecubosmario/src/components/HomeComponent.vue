<template>
  <div class="container mt-5">
    <h1>Bienvenido</h1>
    <hr />
    <div class="row row-cols-1 row-cols-sm-2 row-cols-md-3 row-cols-lg-4 g-4">
      <div class="col" v-for="cubo in cubos" :key="cubo.idCubo">
        <div class="card shadow-sm border-0 rounded-lg h-100">
          <img
            :src="cubo.imagen"
            class="card-img-top img-fluid rounded-top"
            alt="Imagen del producto"
            style="object-fit: cover; height: 200px;"
          />
          <div class="card-body d-flex flex-column">
            <h5 class="card-title text-primary mb-2">{{ cubo.nombre }}</h5>
            <p class="card-text text-muted mb-3">Precio: {{ cubo.precio }} &euro;</p>
            <router-link 
              class="btn btn-outline-primary mt-auto" 
              :to="'/detalles/' + cubo.idCubo"
            >
              Detalles
            </router-link>
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
  name: "HomeComponent",
  methods: {
    getCubos() {
      service.getCubos().then((result) => {
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
    this.getCubos();
  },
};
</script>

<style></style>