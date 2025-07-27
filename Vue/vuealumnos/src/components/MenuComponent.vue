<template>
  <nav
    class="navbar navbar-expand-sm navbar-dark bg-dark"
    aria-label="Third navbar example"
  >
    <div class="container-fluid">
      <a class="navbar-brand" href="#">EMPLEADO</a>
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
            <router-link to="/alumnostoken" class="nav-link"
              >Alumnos</router-link
            >
          </li>
          <li class="nav-item">
            <router-link to="/cursostoken" class="nav-link">Cursos</router-link>
          </li>
          <li class="nav-item">
            <router-link to="/filtrarcursos" class="nav-link">Filtrar Cursos</router-link>
          </li>
          <li class="nav-item">
            <router-link to="/findalumno" class="nav-link">Filtrar Alumno</router-link>
          </li>
          <li class="nav-item">
            <router-link to="/insertalumno" class="nav-link">Crear Alumno</router-link>
          </li>
          <li class="nav-item dropdown">
            <a
              class="nav-link dropdown-toggle"
              href="#"
              data-bs-toggle="dropdown"
              aria-expanded="false"
              >Actions</a
            >
            <ul class="dropdown-menu"></ul>
          </li>
        </ul>
      </div>
    </div>
  </nav>
</template>

<script>
export default {
  name: "MenuComponent",
};
</script>

<style></style>