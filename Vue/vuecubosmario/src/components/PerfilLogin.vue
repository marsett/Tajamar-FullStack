<template>
  <div>
    <h1>Mi perfil ({{ perfil.nombre }})</h1>
    <table class="table table-striped">
      <thead>
        <tr>
          <th>Nombre</th>
          <th>Email</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>{{ perfil.nombre }}</td>
          <td>{{ perfil.email }}</td>
        </tr>
      </tbody>
    </table>
    <router-link class="btn btn-primary" :to="'/compras'">Mostrar compras</router-link>
  </div>
</template>

<script>
import ServiceCubos from "./../services/ServiceCubos";
const service = new ServiceCubos();
export default {
  name: "PerfilLogin",
  methods: {
    getPerfilUsuario() {
      service.getPerfilUsuario().then((result) => {
        this.perfil = result;
      });
    },
  },
  data() {
    return {
      perfil: {},
    };
  },
  mounted() {
    this.getPerfilUsuario();
  },
  watch: {
    "$route.path": function () {
      this.getPerfilUsuario();
    },
  },
};
</script>

<style></style>