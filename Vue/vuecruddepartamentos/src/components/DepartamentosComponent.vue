<template>
  <div>
    <h1>Departamentos Component</h1>
    <img src="./../assets/images/loading.gif" v-if="status == false" />
    <table v-else class="table table-bordered">
      <thead>
        <tr>
          <th>Id departamento</th>
          <th>Nombre</th>
          <th>Localidad</th>
          <th></th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="dept in departamentos" :key="dept">
          <td>{{ dept.idDepartamento }}</td>
          <td>{{ dept.nombre }}</td>
          <td>{{ dept.localidad }}</td>
          <td>
            <router-link
              class="btn btn-warning"
              :to="
                '/details/' +
                dept.idDepartamento +
                '/' +
                dept.nombre +
                '/' +
                dept.localidad
              "
              >Details</router-link
            >
            <router-link
              class="btn btn-info"
              :to="'/update/' + dept.idDepartamento"
              >Edit</router-link
            >

            <router-link
              class="btn btn-danger"
              :to="'/delete/' + dept.idDepartamento"
              >Delete</router-link
            >
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import ServiceDepartamentos from "./../services/ServiceDepartamentos";
const service = new ServiceDepartamentos();

export default {
  name: "DepartamentosComponent",
  mounted() {
    service.getDepartamentos().then((result) => {
      this.status = true;
      this.departamentos = result;
    });
  },
  data() {
    return {
      departamentos: [],
      status: false,
    };
  },
};
</script>

<style>
</style>