<template>
  <div>
    <MenuComponent />
    <div>
      <h1>Alumnos por curso</h1>
      <router-link to="/" class="btn btn-danger" @click="cerrarSesion">
        Volver a inicio de sesión
      </router-link>
      <form v-on:submit.prevent="getAlumnosPorCurso()">
        <label>Introduce el curso para ver sus alumnos</label>
        <input type="text" v-model="id" class="form-control" />
        <button class="btn btn-dark">Filtrar curso</button>
      </form>
      <div v-if="alumnos.length > 0">
        <table class="table table-striped">
          <thead>
            <tr>
              <th>Id Alumno</th>
              <th>Nombre</th>
              <th>Apellidos</th>
              <th>Imagen</th>
              <th>Activo</th>
              <th>Id Curso</th>
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
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script>
import MenuComponent from "./MenuComponent.vue";
import ServiceAlumnos from "./../services/ServiceAlumnos";
const service = new ServiceAlumnos();
export default {
  name: "FiltrarCurso",
  components: {
    MenuComponent,
  },
  methods: {
    getAlumnosPorCurso() {
      service.getAlumnosPorCurso(this.id).then((result) => {
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
      id: "",
    };
  },
};
</script>