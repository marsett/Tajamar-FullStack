<template>
  <div>
    <h1>Tus compras</h1>
    <table class="table table-striped">
      <thead>
        <tr>
          <th>Núm. Pedido</th>
          <th>ID Cubo</th>
          <th>Fecha</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="compra in compras" :key="compra">
          <td>{{ compra.idPedido }}</td>
          <td>{{ compra.idCubo }}</td>
          <td>{{ compra.fechaPedido}}</td>
        </tr>
      </tbody>
    </table>
    <router-link class="btn btn-primary" :to="'/perfil'">Volver al perfil</router-link>
    <router-link class="btn btn-primary" :to="'/pedido'">Realizar pedido</router-link>
  </div>
</template>

<script>
import ServiceCubos from "./../services/ServiceCubos";
const service = new ServiceCubos();
export default {
  name: "ComprasLogin",
  methods: {
    getCompras() {
      service.getCompras().then((result) => {
        this.compras = result;
      });
    },
  },
  data() {
    return {
      compras: [],
    };
  },
  mounted() {
    this.getCompras();
  },
  watch: {
    "$route.path": function () {
      this.getCompras();
    },
  },
};
</script>

<style></style>