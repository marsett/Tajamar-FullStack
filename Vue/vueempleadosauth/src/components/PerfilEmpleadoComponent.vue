<template>
  <div>
    <MenuComponent />
    <div>
      <h1>Perfil Empleado</h1>
      <router-link to="/" class="btn btn-danger" @click="cerrarSesion">
        Cerrar Sesión
      </router-link>
      <table class="table table-striped">
        <thead>
          <tr>
            <th>Id Empleado</th>
            <th>Apellido</th>
            <th>Oficio</th>
            <th>Salario</th>
            <th>Director</th>
          </tr>
        </thead>
        <tbody>
          <tr v-if="empleado">
            <td>{{ empleado.idEmpleado }}</td>
            <td>{{ empleado.apellido }}</td>
            <td>{{ empleado.oficio }}</td>
            <td>{{ empleado.salario }}</td>
            <td>{{ empleado.director }}</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
import MenuComponent from "./MenuComponent.vue";
import ServiceEmpleados from "./../services/ServiceEmpleados";
const service = new ServiceEmpleados();
export default {
  name: "PerfilEmpleadoComponent",
  components: {
    MenuComponent,
  },
  methods: {
    getPerfilEmpleado() {
      service.getPerfilEmpleado().then((result) => {
        this.empleado = result;
      });
    },
    cerrarSesion() {
      service.cerrarSesion();
    }
  },
  data() {
    return {
      empleado: {},
    };
  },
  mounted() {
    this.getPerfilEmpleado();
  },
  watch: {
    '$route.path': function () {
      this.getPerfilEmpleado();
    }
  },
};
</script>

<style></style>