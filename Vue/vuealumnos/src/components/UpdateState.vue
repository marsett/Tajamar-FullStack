<template>
  <div>
    <MenuComponent />
    <h1>Editar estado alumno</h1>
  </div>
</template>

<script>
import MenuComponent from "./MenuComponent.vue";
import ServiceAlumnos from "./../services/ServiceAlumnos";
const service = new ServiceAlumnos();
export default {
  name: "UpdateState",
  components: {
    MenuComponent
  },
  mounted() {
    let id = this.$route.params.id;
    let state = this.$route.params.state;
    service.updateState(id, state).then((result) => {
      console.log("Update del result " + result);
      this.$router.push("/alumnostoken");
    });
  },
};
</script>

<style>
</style>