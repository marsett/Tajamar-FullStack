<template>
  <div>
    <MenuComponent />
    <div>
      <h1>Alumno</h1>
      <router-link to="/" class="btn btn-danger" @click="cerrarSesion">
        Volver a inicio de sesión
      </router-link>
      <form v-on:submit.prevent="getFiltrarAlumno()">
        <label>Introduce el id del alumno</label>
        <input type="text" v-model="id" class="form-control" />
        <button class="btn btn-dark">Filtrar alumno</button>
      </form>
      <div v-if="alumno">
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
            <tr>
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
  name: "FindAlumno",
  components: {
    MenuComponent,
  },
  methods: {
    getFiltrarAlumno() {
      service.getFiltrarAlumno(this.id).then((result) => {
        this.alumno = result;
      });
    },
    cerrarSesion() {
      service.cerrarSesion();
    },
  },
  data() {
    return {
      alumno: null,
      id: "",
    };
  },
};
</script>