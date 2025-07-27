<template>
  <div>
    <h1>Detalles Coche</h1>
    <router-link to="/">Volver a Inicio</router-link>
    <ul class="list-group">
      <li class="list-group-item">Id: {{ $route.params.id }}</li>
      <li class="list-group-item">Marca: {{ $route.params.marca }}</li>
      <li class="list-group-item">Modelo: {{ $route.params.modelo }}</li>
      <li class="list-group-item">Conductor: {{ $route.params.conductor }}</li>
      <li class="list-group-item">
        <img :src="$route.params.imagen"/></li>
    </ul>
  </div>
</template>

<script>
export default {
  name: "DetallesCoche",
};
</script>