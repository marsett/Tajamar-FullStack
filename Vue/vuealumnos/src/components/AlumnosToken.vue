<template>
  <div>
    <MenuComponent />
    <div>
      <h1>Alumnos</h1>
      <router-link to="/" class="btn btn-danger" @click="cerrarSesion">
        Volver a inicio de sesión
      </router-link>
      <table class="table table-striped">
        <thead>
          <tr>
            <th>Id Alumno</th>
            <th>Nombre</th>
            <th>Apellidos</th>
            <th>Imagen</th>
            <th>Activo</th>
            <th>Id Curso</th>
            <th>Acciones</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="alumno of alumnos" :key="alumno">
            <td>{{ alumno.idAlumno }}</td>
            <td>{{ alumno.nombre }}</td>
            <td>{{ alumno.apellidos }}</td>
            <td>
              <img :src="alumno.imagen" style="width: 150px; height: 150px" />
            </td>
            <td>{{ alumno.activo }}</td>
            <td>{{ alumno.idCurso }}</td>
            <td>
              <router-link
                class="btn btn-info"
                :to="'/updatealumno/' + alumno.idAlumno"
                >Edit</router-link
              >
              <router-link
                class="btn btn-danger"
                :to="'/deletealumno/' + alumno.idAlumno"
                >Delete</router-link
              >
              <router-link
                class="btn btn-info"
                :to="'/updatestate/' + alumno.idAlumno + '/' + alumno.activo "
                >Edit state</router-link
              >
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
import MenuComponent from "./MenuComponent.vue";
import ServiceAlumnos from "./../services/ServiceAlumnos";
const service = new ServiceAlumnos();
export default {
  name: "AlumnosToken",
  components: {
    MenuComponent,
  },
  methods: {
    getAlumnosToken() {
      service.getAlumnosToken().then((result) => {
        this.alumnos = result;
      });
    },
    cerrarSesion() {
      service.cerrarSesion();
    },
  },
  data() {
    return {
      alumnos: [],
    };
  },
  mounted() {
    this.getAlumnosToken();
  },
  watch: {
    "$route.path": function () {
      this.getAlumnosToken();
    },
  },
};
</script>