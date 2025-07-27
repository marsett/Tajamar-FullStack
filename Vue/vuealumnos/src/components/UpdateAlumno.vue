<template>
  <div>
    <MenuComponent />
    <div>
      <h1 style="color: blue">Editar Alumno</h1>
      <form
      v-if="alumno"
        v-on:submit.prevent="updateAlumno()"
        style="width: 500px; margin: 0 auto"
      >
        <input type="hidden" v-model="alumno.idAlumno" class="form-control" />
        <label>Nombre:</label>
        <input type="text" v-model="alumno.nombre" class="form-control" />
        <label>Apellidos:</label>
        <input type="text" v-model="alumno.apellidos" class="form-control" />
        <label>Imagen:</label>
        <input type="text" v-model="alumno.imagen" class="form-control" />
        <label>Activo:</label>
        <input type="text" v-model="alumno.activo" class="form-control" />
        <label>Id Curso:</label>
        <input type="text" v-model="alumno.idCurso" class="form-control" />
        <button class="btn btn-success">Actualizar Alumno</button>
      </form>
    </div>
  </div>
</template>

<script>
import MenuComponent from "./MenuComponent.vue";
import ServiceAlumnos from "./../services/ServiceAlumnos";
const service = new ServiceAlumnos();
export default {
  name: "UpdateAlumno",
  components: {
    MenuComponent
  },
  methods: {
    updateAlumno() {
      service.updateAlumno(this.alumno).then((result) => {
        console.log(result);
        this.$router.push("/alumnostoken");
      });
    },
  },
  mounted() {
    let id = this.$route.params.id;
    service.getFiltrarAlumno(id).then((result) => {
      this.alumno = result;
    });
  },
  data() {
    return {
        alumno: null
    }
  }
};
</script>

<style></style>