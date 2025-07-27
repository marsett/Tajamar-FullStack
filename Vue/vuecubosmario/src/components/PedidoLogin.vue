<template>
  <div>
    <h1>Realizar pedido</h1>
    <p>Elige un cubo</p>
    <select class="form-control" v-model="idSeleccionado">
      <option v-for="cubo in cubos" :key="cubo" :value="cubo.idCubo">
        {{ cubo.nombre }}
      </option>
    </select>
    <button
      class="btn btn-primary"
      @click="insertPedido()"
      >Comprar cubo</button
    >
  </div>
</template>

<script>
import ServiceCubos from "./../services/ServiceCubos";
const service = new ServiceCubos();
export default {
  name: "PedidoLogin",
  methods: {
    insertPedido() {
      if (this.idSeleccionado) {
        service.insertPedido(this.idSeleccionado).then((result) => {
          console.log("Result: " + result);
          this.$router.push('/compras');
        });
      }
    },
    getCubos() {
      service.getCubos().then((result) => {
        this.cubos = result;
      });
    },
  },
  data() {
    return {
      perfil: {},
      cubos: [],
      idSeleccionado: 1,
    };
  },
  mounted() {
    this.getCubos();
  },
  watch: {
    "$route.path": function () {
      this.getCubos();
    },
  },
};
</script>

<style></style>