<template>
  <div>
    <h1>INICIO COCHES</h1>
    <img src="./../assets/images/loading.gif" v-if="status == false" />
    <table v-else class="table table-bordered">
      <thead>
        <tr>
          <th>Id coche</th>
          <th>Marca</th>
          <th>Modelo</th>
          <th>Conductor</th>
          <th>Imagen</th>
          <th></th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="coche in coches" :key="coche">
          <td>{{ coche.idCoche }}</td>
          <td>{{ coche.marca }}</td>
          <td>{{ coche.modelo }}</td>
          <td>{{ coche.conductor }}</td>
          <td>
            <img :src="coche.imagen" style="width: 250px; height: 250px"/>
          </td>
          <td>
            <router-link
              class="btn btn-warning"
              :to="
                '/detalles/' +
                coche.idCoche +
                '/' +
                coche.marca +
                '/' +
                coche.modelo +
                '/' +
                coche.conductor +
                '/' +
                encodeURIComponent(coche.imagen)
              "
              >Detalles</router-link
            >
            <router-link
              class="btn btn-info"
              :to="'/editar/' + coche.idCoche"
              >Editar</router-link
            >

            <router-link
              class="btn btn-danger"
              :to="'/eliminar/' + coche.idCoche"
              >Eliminar</router-link
            >
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import ServiceCoches from "./../services/ServiceCoches";
const service = new ServiceCoches();
export default {
  name: "InicioCoches",
  mounted() {
    service.getCoches().then((result) => {
        this.coches = result;
        this.status = true;
    });
  },
  data() {
    return {
      coches: [],
      status: false,
    };
  },
};
</script>

<script>
</script>