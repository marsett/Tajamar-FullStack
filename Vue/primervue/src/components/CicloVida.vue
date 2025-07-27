<template>
  <div>
    <h1>Ciclo de Vida</h1>
    <button @click="cambiarSaludo()">Cambiar saludo</button>
    <h2 style="color: blue">{{ saludo }}</h2>
  </div>
</template>

<script>
export default {
  name: "CicloVida",
  data() {
    return {
      saludo: "Hoy es lunes...",
    };
  },
  methods: {
    // En esta zona incluiremos nuestros métodos personalizados
    cambiarSaludo() {
      // Se utiliza la palabra clave this para llamar a las variables
      // de data()
      this.saludo = "Y mañana martes...";
    },
  },
  mounted() {
    console.log("Component Montado");
  },
  unmounted() {
    console.log("Component Destruido");
  },
  updated() {
    console.log("Component Modificado");
  },
  created() {
    console.log("Component Creado");
  },
};
</script>

<style>
</style>