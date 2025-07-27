<template>
  <div class="container mt-5">
    <div class="card w-100 mb-4">
      <div class="card-header text-center">
        <h1 class="mb-0" style="font-size: 2.5rem;">{{ cubo.nombre }}</h1>
      </div>

      <img
        :src="cubo.imagen"
        class="card-img-top" 
        alt="Imagen del producto" 
        style="max-height: 200px; object-fit: contain;"
      />

      <div class="card-body">
        <table class="table table-bordered">
          <tbody>
            <tr>
              <th>Marca</th>
              <td>{{ cubo.marca }}</td>
            </tr>
            <tr>
              <th>Modelo</th>
              <td>{{ cubo.modelo }}</td>
            </tr>
            <tr>
              <th>Precio</th>
              <td>{{ cubo.precio }} €</td>
            </tr>
            <tr>
              <th>Valoración</th>
              <td>{{ cubo.valoracion }}</td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>

    <router-link class="btn btn-warning mt-3" :to="'/'">Volver</router-link>

    <div class="mt-4">
    <h1 v-if="comentario.length === 0"  style="color: blue">Sin comentarios</h1>
      <table class="table table-bordered" v-else>
        <thead>
          <tr>
            <th>Usuario</th>
            <th>Comentarios</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="coment in comentario" :key="coment">
            <td>Usuario {{ coment.idUsuario }}</td>
            <td>{{ coment.comentario }}</td>
            
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>


<script>
import ServiceCubos from "./../services/ServiceCubos";
const service = new ServiceCubos();
export default {
  name: "DetallesCubo",
  methods: {
    getCubosMarcas() {
      let id = this.$route.params.id;
      service.getCuboPorId(id).then((result) => {
        this.cubo = result;
      });
    },
    getComentariosCubo() {
      let id = this.$route.params.id;
      service.getComentariosCubo(id).then((result) => {
        this.comentario = result;
        console.log("Comentario: " + this.comentario);
      });
    },
  },
  data() {
    return {
      cubo: {},
      comentario: [],
    };
  },
  mounted() {
    this.getCubosMarcas();
    this.getComentariosCubo();
  },
  watch: {
    "$route.params.id"(nextVal, oldVal) {
      if (nextVal != oldVal) {
        this.getCubosMarcas();
        this.getComentariosCubo();
      }
    },
  },
};
</script>

<style></style>