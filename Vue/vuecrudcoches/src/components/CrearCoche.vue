<template>
  <div>
    <h1>CREAR COCHE</h1>
    <h2 style="color: blue">{{ mensaje }}</h2>
    <form v-on:submit.prevent="crearCoche()" style="width: 500px; margin: 0 auto">
      <label>Id coche</label>
      <input
        type="number"
        v-model="coche.idCoche"
        class="form-control"
      />
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
      <button class="btn btn-info">Crear Coche</button>
    </form>
  </div>
</template>

<script>
import ServiceCoches from "@/services/ServiceCoches";
const service = new ServiceCoches();

export default {
  name: "CrearCoche",
  methods: {
    crearCoche() {
      service.crearCoche(this.coche).then((result) => {
        this.mensaje = "Coche insertado " + result;
        this.$router.push("/");
      });
    },
  },
  data() {
    return {
      mensaje: "",
      coche: {
        idCoche: 0,
        marca: "",
        modelo: "",
        conductor: "",
        imagen: ""
      },
    };
  },
};
</script>