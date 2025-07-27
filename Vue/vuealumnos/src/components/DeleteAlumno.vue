<template>
  <div>
    <MenuComponent />
    <h1>Delete alumno</h1>
  </div>
</template>

<script>
import MenuComponent from "./MenuComponent.vue";
import ServiceAlumnos from "./../services/ServiceAlumnos";
const service = new ServiceAlumnos();
export default {
  name: "DeleteAlumno",
  components: {
    MenuComponent
  },
  mounted() {
    let id = this.$route.params.id;
    service.deleteAlumno(id).then((result) => {
      console.log(result);
      this.$router.push("/alumnostoken");
    });
  },
};
</script>

<style>
</style>