<template>
  <div>
    <MenuComponent />
    <div>
      <h1 style="color: blue">Nuevo Alumno</h1>
      <form
        v-on:submit.prevent="insertAlumno()"
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
        <button class="btn btn-success">Insertar Alumno</button>
      </form>
    </div>
  </div>
</template>

<script>
import MenuComponent from "./MenuComponent.vue";
import ServiceAlumnos from "./../services/ServiceAlumnos";
const service = new ServiceAlumnos();
export default {
  name: "InsertAlumno",
  components: {
    MenuComponent
  },
  methods: {
    insertAlumno() {
      service.insertAlumno(this.alumno).then((result) => {
        console.log("Alumno insertado correctamente " + result);
        this.$router.push("/alumnostoken");
      });
    },
  },
  data() {
    return {
        alumno: {
            idAlumno: 0,
            nombre: "",
            apellidos: "",
            imagen: "",
            activo: 0,
            idCurso: 0
        }
    }
  }
};
</script>

<style></style>