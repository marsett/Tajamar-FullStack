<template>
  <div>
    <MenuComponent />
    <div>
      <h1>Subordinados Empleado</h1>
      <router-link to="/" class="btn btn-danger" @click="cerrarSesion">
        Volver a inicio de sesión
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
          <tr v-for="empleado of empleados" :key="empleado">
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
    getSubordinados() {
      service.getSubordinados().then((result) => {
        this.empleados = result;
      });
    },
    cerrarSesion() {
      service.cerrarSesion();
    }
  },
  data() {
    return {
      empleados: [],
    };
  },
  mounted() {
    this.getSubordinados();
  },
  watch: {
    '$route.path': function () {
      this.getSubordinados();
    }
  },
};
</script>

<style></style>