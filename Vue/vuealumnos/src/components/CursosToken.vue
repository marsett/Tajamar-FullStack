<template>
  <div>
    <MenuComponent />
    <div>
      <h1>Cursos</h1>
      <router-link to="/" class="btn btn-danger" @click="cerrarSesion">
        Volver a inicio de sesión
      </router-link>
      <div>
        <ul>
          <li v-for="curso in cursos" :key="curso">{{ curso }}</li>
        </ul>
      </div>
    </div>
  </div>
</template>

<script>
import MenuComponent from "./MenuComponent.vue";
import ServiceAlumnos from "./../services/ServiceAlumnos";
const service = new ServiceAlumnos();
export default {
  name: "CursosToken",
  components: {
    MenuComponent,
  },
  methods: {
    getCursosToken() {
      service.getCursosToken().then((result) => {
        this.cursos = result;
      });
    },
    cerrarSesion() {
      service.cerrarSesion();
    },
  },
  data() {
    return {
      cursos: [],
    };
  },
  mounted() {
    this.getCursosToken();
  },
  watch: {
    "$route.path": function () {
      this.getCursosToken();
    },
  },
};
</script>