<template>
  <div>
    <h1 style="color: blue">Cómics Component</h1>
    <form v-on:submit.prevent="createComic()">
      <label>Título</label>
      <input type="text" v-model="comicForm.titulo" />
      <label>Descripción</label>
      <input type="text" v-model="comicForm.descripcion" />
      <label>Imagen</label>
      <input type="text" v-model="comicForm.imagen" />
      <label>Año</label>
      <input type="text" v-model="comicForm.year" />
      <button>Crear cómic</button>
    </form>
    <div v-if="comicFavorito" class="verde">
      <h2 style="color: blue">{{ comicFavorito.titulo }}</h2>
      <h2 style="color: yellow">{{ comicFavorito.descripcion }}</h2>
    </div>
    <div id="comics" v-for="(comic, index) in comics" :key="comic">
      <ComicComponent
        :comic="comic" :index="index"
        v-on:seleccionarFavorito="seleccionarFavorito"
        v-on:deleteComic="deleteComic"
      />
    </div>
  </div>
</template>

<script>
import ComicComponent from "./ComicComponent.vue";
export default {
  name: "ComicsComponent",
  components: {
    ComicComponent,
  },
  methods: {
    createComic() {
      this.comics.push(this.comicForm);
    },
    seleccionarFavorito(comic) {
      console.log(comic.titulo);
      this.comicFavorito = comic;
    },
    deleteComic(index) {
      this.comics.splice(index, 1);
    },
  },
  data() {
    return {
      comicFavorito: null,
      comicForm: {
        titulo: "",
        imagen: "",
        descripcion: "",
        year: 0,
      },
      comics: [
        {
          titulo: "Spiderman",
          imagen:
            "https://3.bp.blogspot.com/-i70Zu_LAHwI/T290xxduu-I/AAAAAAAALq8/8bXDrdvW50o/s1600/spiderman1.jpg",
          descripcion: "Hombre araña",
          year: 1997,
        },
        {
          titulo: "Wolverine",
          imagen:
            "https://images-na.ssl-images-amazon.com/images/I/51c1Q1IdUBL._SX259_BO1,204,203,200_.jpg",
          descripcion: "Lobezno",
          year: 2003,
        },
        {
          titulo: "Guardianes de la Galaxia",
          imagen:
            "https://es.web.img2.acsta.net/pictures/22/07/29/15/46/3512027.jpg",
          descripcion: "Yo soy Groot",
          year: 2006,
        },
        {
          titulo: "Avengers",
          imagen:
            "https://d26lpennugtm8s.cloudfront.net/stores/057/977/products/ma_avengers_01_01-891178138c020318f315132687055371-640-0.jpg",
          descripcion: "Los Vengadores",
          year: 1993,
        },
        {
          titulo: "Spawn",
          imagen:
            "https://i.pinimg.com/originals/e1/d8/ff/e1d8ff4aeab5e567798635008fe98ee1.png",
          descripcion: "Al Simmons",
          year: 2000,
        },
        {
          titulo: "Batman",
          imagen:
            "https://www.comicverso.com/wp-content/uploads/2020/06/The-Killing-Joke-657x1024.jpg",
          descripcion: "Murcielago",
          year: 2001,
        },
      ],
    };
  },
};
</script>

<style></style>