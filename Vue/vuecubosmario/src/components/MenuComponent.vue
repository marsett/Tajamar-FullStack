<template>
  <nav class="navbar navbar-expand-sm navbar-dark bg-dark" aria-label="Third navbar example">
    <div class="container-fluid">
      <img src="@/assets/images/peterporker.8f99499b.png" style="width: 60px; height: 60px" />

      <button
        class="navbar-toggler"
        type="button"
        data-bs-toggle="collapse"
        data-bs-target="#navbarsExample03"
        aria-controls="navbarsExample03"
        aria-expanded="false"
        aria-label="Toggle navigation"
      >
        <span class="navbar-toggler-icon"></span>
      </button>

      <div class="collapse navbar-collapse" id="navbarsExample03">
        <ul class="navbar-nav me-auto mb-2 mb-sm-0">
          <li class="nav-item">
            <router-link class="nav-link" to="/">Cubos</router-link>
          </li>
          
          <li class="nav-item dropdown">
            <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown" aria-expanded="false">Marcas</a>
            <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
              <li v-for="marca in marcas" :key="marca">
                <router-link class="dropdown-item" :to="'/cubos/' + marca">{{ marca }}</router-link>
              </li>
            </ul>
          </li>

          <li class="nav-item dropdown">
            <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown" aria-expanded="false">Seguridad</a>
            <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
              <li>
                <router-link class="dropdown-item" to="/login">Iniciar Sesión</router-link>
              </li>
              <li>
                <button class="dropdown-item" @click="cerrarSesion">Cerrar Sesión</button>
              </li>
            </ul>
          </li>

          <li v-if="isLoggedIn" class="nav-item dropdown">
            <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown" aria-expanded="false">Usuario</a>
            <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
              <li><router-link class="dropdown-item" to="/perfil">Perfil</router-link></li>
              <li><router-link class="dropdown-item" to="/compras">Compras</router-link></li>
              <li><router-link class="dropdown-item" to="/pedido">Pedido</router-link></li>
            </ul>
          </li>
        </ul>
      </div>
    </div>
  </nav>
</template>

<script>
import ServiceCubos from "./../services/ServiceCubos";
const service = new ServiceCubos();
export default {
  name: "MenuComponent",
  data() {
    return {
        marcas: [],
        isLoggedIn: false
    }
  },
  mounted() {
    service.getMarcasCubos().then(result => {
        this.marcas = result;
    });
    this.checkLoginStatus();
  },
  methods: {
    checkLoginStatus() {
      this.isLoggedIn = service.checkIfLoggedIn();
    },
    cerrarSesion() {
      service.cerrarSesion();
      this.isLoggedIn = false;
      this.$router.push("/login");
    },
  },
};
</script>

<style>
.bg-custom {
  background-color: black !important;
}</style>