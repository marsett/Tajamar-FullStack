<template>
  <div>
    <label>Tabla Multiplicar</label>
    <button @click="generarTablaBoton()">Generar Tabla Botón</button>
    <input type="number" v-model="numero" />
    <!-- Tabla generada usando el botón -->
    <table border="1">
      <thead>
        <tr>
          <th>Operación</th>
          <th>Resultado</th>
        </tr>
      </thead>
      <tbody v-html="html"></tbody>
    </table>
    <!-- Tabla generada usando directivas -->
    <table border="1">
      <thead>
        <tr>
          <th>Operación</th>
          <th>Resultado</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="num in 11" :key="num">
          <td style="text-align: center; color: red">
            {{ numero + "*" + (num - 1) }}
          </td>
          <td style="text-align: center; color: green">
            {{ numero * (num - 1) }}
          </td>
        </tr>
      </tbody>
    </table>
    <!-- Tabla generada usando filtros -->
    <table border="1">
      <thead>
        <tr>
          <th>Operación</th>
          <th>Resultado</th>
        </tr>
      </thead>
      <tbody>
        <!-- <tr
          v-for="(operacion, index) in $filters.getOperacion(numero)"
          :key="index"
        >
          <td style="text-align: center; color: blue">{{ operacion }}</td>
          <td style="text-align: center; color: purple">
            {{ $filters.getMultiplicacion(numero)[index] }}
          </td>
        </tr> -->
        <tr v-for="contador in 11" :key="contador">
            <td style="text-align: center; color: blue">{{$filters.getOperacion(numero, (contador - 1))}}</td>
            <td style="text-align: center; color: purple">{{$filters.getMultiplicacion(numero, (contador - 1))}}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
export default {
  name: "TablaMultiplicar",
  methods: {
    generarTablaBoton() {
      this.html = "";
      for (let i = 0; i <= 10; i++) {
        this.operacion = this.numero + "*" + i;
        this.resultado = this.numero * i;
        this.html += "<tr>";
        this.html +=
          "<td style='text-align: center; color: orange;'>" +
          this.operacion +
          "</td>";
        this.html +=
          "<td style='text-align: center; color: black;'>" +
          this.resultado +
          "</td>";
        this.html += "</tr>";
      }
    },
  },
  data() {
    return {
      html: "",
      numero: 0,
      operacion: "",
      resultado: 0,
    };
  },
};
</script>

<style></style>