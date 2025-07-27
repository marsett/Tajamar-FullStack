<template>
    <div>
        <h2>{{personaje.nombre}}</h2>
        <img :src="personaje.imagen"/>
        <h3>{{personaje.pelicula}}</h3>
    </div>
</template>

<script>
export default {
    name: "PersonajeComponent",
    props: ["personaje"],
    data() {
        return {
            
        }
    },
    methods: {

    }
}
</script>

<style>
img {
    width: 300px;
    height: 300px;
}
</style>