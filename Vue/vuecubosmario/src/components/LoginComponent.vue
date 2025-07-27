<template>
  <div class="container mt-5">
    <div class="row justify-content-center">
      <div class="col-md-6 col-lg-4">
        <div class="card shadow-sm">
          <div class="card-body">
            <h3 class="card-title text-center mb-4">Iniciar Sesión</h3>
            <form v-on:submit.prevent="iniciarSesion()">
              <div class="mb-3">
                <label for="usuario" class="form-label">Email</label>
                <input type="text" v-model="login.email" class="form-control" />
              </div>
              <div class="mb-3">
                <label for="password" class="form-label">Contraseña</label>
                <input
                  type="password"
                  v-model="login.password"
                  class="form-control"
                />
              </div>
              <div class="d-grid gap-2">
                <button class="btn btn-success">Iniciar Sesión</button>
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import ServiceCubos from "./../services/ServiceCubos";
const service = new ServiceCubos();
export default {
  name: "LoginComponent",
  methods: {
    iniciarSesion() {
      service.postAuth(this.login).then((result) => {
        console.log("Valor: " + result.data.response);
        service.setToken(result.data.response);
        console.log("Token guardado");
        this.$router.push("/perfil");
      });
    },
  },
  data() {
    return {
      login: {
        email: "",
        password: "",
      },
    };
  },
};
</script>

<style></style>