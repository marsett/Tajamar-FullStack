<template>
  <div>
    <h1>Personajes Component</h1>
    <div v-for="personaje in personajes" :key="personaje">
            <PersonajeComponent :personaje="personaje" />
        </div>
    
  </div>
</template>

<script>
import PersonajeComponent from "./PersonajeComponent.vue";
export default {
  name: "PersonajesComponent",
  components: {
    PersonajeComponent,
  },
  data() {
    return {
      personajes: [
        {
          nombre: "Michael Myers",
          imagen:
            "https://upload.wikimedia.org/wikipedia/en/e/e9/MichaelMyers2018.jpg",
          pelicula: "Halloween",
        },
        {
          nombre: "Pennywise",
          imagen:
            "https://media.vogue.es/photos/5cc6fcdea6e1179f7253f451/master/w_1600%2Cc_limit/disfraces_halloween_inspirados_en_peliculas_terror_145567452.jpg",
          pelicula: "It",
        },
        {
          nombre: "Anabelle",
          imagen:
            "https://media.vogue.es/photos/670f863f0ad5ec9f27d6f5c1/master/w_1600%2Cc_limit/MCDANCO%2520EC028_H.jpg",
          pelicula: "The Conjuring",
        },
        {
          nombre: "Chucky",
          imagen: "https://i.ytimg.com/vi/3W4HzJHvVjc/maxresdefault.jpg",
          pelicula: "Chucky el muñeco diabólico",
        },
        {
          nombre: "Freddy Krueger",
          imagen:
            "https://upload.wikimedia.org/wikipedia/en/e/eb/Freddy_Krueger_%28Robert_Englund%29.jpg",
          pelicula: "Pesadilla en Elm Street",
        },
        {
          nombre: "Art el payaso",
          imagen:
            "https://es.gizmodo.com/app/uploads/2024/10/Diseno-sin-titulo-11-6.jpg",
          pelicula: "Terrifier",
        },
      ],
    };
  },
  methods: {},
};
</script>

<style></style>