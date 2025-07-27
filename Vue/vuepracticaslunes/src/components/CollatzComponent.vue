<template>
  <div>
    <label>Introduce número para la conjetura de Collatz</label><br />
    <input type="number" v-model="numero" />
    <button @click="getConjetura()">Mostrar conjetura</button>
    <div v-if="secuencia.length > 0">
      <span
        v-for="num in secuencia"
        :key="num"
        v-html="$filters.getDibujo(num)"
      ></span>
    </div>
  </div>
</template>

<script>
export default {
  name: "CollatzComponent",
  methods: {
    getConjetura() {
      var num = this.numero;
      this.secuencia = [];
      while (num !== 1) {
        if (num % 2 === 0) {
          num = num / 2;
        } else {
          num = num * 3 + 1;
        }
        this.secuencia.push(num);
      }
      return this.secuencia;
    },
  },
  data() {
    return {
      secuencia: [],
      numero: 0,
    };
  },
};
</script>
