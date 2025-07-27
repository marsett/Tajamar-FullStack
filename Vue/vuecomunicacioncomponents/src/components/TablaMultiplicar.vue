<template>
  <div>
    <h1>Tabla Multiplicar {{ this.$route.params.numero }}</h1>
    <button @click="redirectToHome()">Go to Home</button>
    <table border="1">
      <thead>
        <tr>
          <th>Operación</th>
          <th>Resultado</th>
        </tr>
      </thead>
      <tbody v-html="html"></tbody>
    </table>
  </div>
</template>

<script>
export default {
  name: "TablaMultiplicar",
  methods: {
    generarTabla(numero) {
      this.html = "";
      for (let i = 0; i <= 10; i++) {
        this.operacion = numero + "*" + i;
        this.resultado = numero * i;
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
    redirectToHome() {
      this.$router.push("/");
    },
  },
  watch: {
    "$route.params.numero"(nextVal, oldVal) {
      if (nextVal != oldVal) {
        this.mensaje = "Esto ha cambiado!!!" + this.$route.params.numero;
        console.log(this.mensaje);
        let valor = parseInt(this.$route.params.numero);
        this.generarTabla(valor);
      }
    },
  },
  data() {
    return {
      mensaje: "",
      html: "",
      operacion: "",
      resultado: 0,
    };
  },
  mounted() {
    console.log("Número recibido: " + this.$route.params.numero);
    let paramNumero = this.$route.params.numero;
    if (paramNumero == "") {
      this.mensaje = "Sin parámetros en Routing";
      console.log(this.mensaje);
    } else {
      this.mensaje = "Parámetro recibido: " + paramNumero;
      console.log(this.mensaje);
      let valor = parseInt(this.$route.params.numero);
      this.generarTabla(valor);
    }
  },
};
</script>

<style></style>