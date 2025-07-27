<template>
  <div>
    <h1>BORRAR COCHE</h1>
  </div>
</template>

<script>
import ServiceCoches from "@/services/ServiceCoches";
const service = new ServiceCoches();
export default {
  name: "BorrarCoche",
  mounted() {
    let id = this.$route.params.id;
    service.borrarCoche(id).then(() => {
      this.$router.push("/");
    });
  },
};
</script>

<style>
</style>