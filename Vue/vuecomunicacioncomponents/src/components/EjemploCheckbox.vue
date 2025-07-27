<template>
  <div>
    <h1>Ejemplo Checkbox</h1>
    <button @click="nuevoNumero()">Generar Checkbox</button><br /><br />
    <span v-for="num in numeros" :key="num">
      <input
        type="checkbox"
        :value="num"
        @change="mostrarSuma(num, $event.target.checked)"
      />
      {{ num }}
    </span>
    <h1 style="color: blue">La suma seleccionada es {{ operacion }}</h1>
  </div>
</template>

<script>
export default {
  name: "EjemploCheckbox",
  methods: {
    nuevoNumero() {
      var numero = parseInt(Math.random() * 100) + 1;
      this.numeros.push(numero);
    },
    mostrarSuma(numero, isChecked) {
      if (isChecked) {
        this.operacion += numero;
      } else {
        this.operacion -= numero;
      }
    },
  },
  data() {
    return {
      numeros: [3, 7, 9],
      operacion: 0,
    };
  },
};
</script>

<style></style>