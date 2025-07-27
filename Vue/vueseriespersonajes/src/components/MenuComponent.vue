<template>
  <div>
    <nav
      class="navbar navbar-expand-sm navbar-dark bg-dark bg-custom"
      aria-label="Third navbar example"
    >
      <div class="container-fluid">
        <a class="navbar-brand" href="#">
          <img
            src="https://appseries.azurewebsites.net/static/media/logo1.1408c71b2c87ca1fb473.png"
            style="width: 80px"
          />
        </a>

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
              <router-link class="nav-link active" aria-current="page" to="/"
                >Home</router-link
              >
            </li>

            <li class="nav-item">
              <router-link class="nav-link" to="/crear">Nuevo personaje</router-link>
            </li>

            <li class="nav-item">
              <router-link class="nav-link" to="/editar">Modificar personajes</router-link>
            </li>

            <li class="nav-item dropdown">
              <a
                class="nav-link dropdown-toggle"
                href="#"
                data-bs-toggle="dropdown"
                aria-expanded="false"
                >Series</a
              >

              <ul class="dropdown-menu">
                <li v-for="serie in series" :key="serie.idSerie" :value="serie.idSerie">
                  <router-link
                    class="dropdown-item"
                    :to="'/series/' + serie.idSerie"
                  >
                    {{ serie.nombre }}
                  </router-link>
                </li>
              </ul>
            </li>
          </ul>

          <!-- <form role="search">
            <input
              class="form-control"
              type="search"
              placeholder="Search"
              aria-label="Search"
            />
          </form> -->
        </div>
      </div>
    </nav>
  </div>
</template>

<script>
import ServiceSeries from './../services/ServiceSeries';
const service = new ServiceSeries();

export default {
  name: "MenuComponent",
  data() {
    return {
      series: [],
    };
  },
  mounted() {
    service.getSeries().then(result => {
        this.series = result;
    })
  },
};
</script>

<style>
.bg-custom {
  background-color: rgba(13, 110, 253, 1) !important;
}
</style>