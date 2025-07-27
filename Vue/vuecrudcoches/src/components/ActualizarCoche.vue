<template>
  <div>
    <h1>ACTUALIZAR COCHE</h1>
    <form
      v-if="coche"
      v-on:submit.prevent="actualizarCoche()"
      style="width: 500px; margin: 0 auto"
    >
      <input type="hidden" v-model="coche.idCoche" />
      <label>Marca</label>
      <input type="text" v-model="coche.marca" class="form-control" />
      <label>Modelo</label>
      <input
        type="text"
        v-model="coche.modelo"
        class="form-control"
      />
      <label>Conductor</label>
      <input type="text" v-model="coche.conductor" class="form-control" />
      <label>Imagen</label>
      <input type="text" v-model="coche.imagen" class="form-control" />
      <button class="btn btn-warning">Actualizar</button>
    </form>
  </div>
</template>

<script>
import ServiceCoches from "@/services/ServiceCoches";
const service = new ServiceCoches();
export default {
  name: "ActualizarCoche",
  methods: {
    actualizarCoche() {
      service.actualizarCoche(this.coche).then(() => {
        this.$router.push("/");
      });
    },
  },
  mounted() {
    let id = this.$route.params.id;
    service.encontrarCoche(id).then((result) => {
      this.coche = result;
    });
  },
  data() {
    return {
      coche: null,
    };
  },
};
</script>