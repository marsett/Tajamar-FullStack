<template>
  <div>
    <h1>Servicio API Customers</h1>
    <form v-on:submit.prevent="verDetalles()">
      <label>ID Cliente</label>
      <input
        type="text"
        v-model="cajaCustomer"
      />
      <button>Ver Detalles</button>
    </form>
    <div v-if="detalleCustomer" class="customer-details">
      <h2>Detalles del Cliente</h2>
      <table class="details-table">
        <tbody>
          <tr>
            <th>Id</th>
            <td>{{ detalleCustomer.id }}</td>
          </tr>
          <tr>
            <th>Compañía</th>
            <td>{{ detalleCustomer.companyName }}</td>
          </tr>
          <tr>
            <th>Nombre</th>
            <td>{{ detalleCustomer.contactName }}</td>
          </tr>
          <tr>
            <th>Título</th>
            <td>{{ detalleCustomer.contactTitle }}</td>
          </tr>
          <tr>
            <th>Dirección</th>
            <td>{{ detalleCustomer.address }}</td>
          </tr>
          <tr>
            <th>Ciudad</th>
            <td>{{ detalleCustomer.city }}</td>
          </tr>
          <tr>
            <th>Código Postal</th>
            <td>{{ detalleCustomer.postalCode }}</td>
          </tr>
          <tr>
            <th>País</th>
            <td>{{ detalleCustomer.country }}</td>
          </tr>
          <tr>
            <th>Teléfono</th>
            <td>{{ detalleCustomer.phone }}</td>
          </tr>
          <tr>
            <th>Fax</th>
            <td>{{ detalleCustomer.fax }}</td>
          </tr>
        </tbody>
      </table>
    </div>

    <table v-if="customers.length > 0" class="customers-table">
      <thead>
        <tr>
          <th>Nombre</th>
          <th>Compañía</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="customer in customers" :key="customer.id">
          <td>{{ customer.contactName }}</td>
          <td>{{ customer.companyName }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import axios from "axios";
import Global from "./../Global";

export default {
  name: "CustomersComponent",
  data() {
    return {
      customers: [],
      detalleCustomer: null,
      cajaCustomer: "",
    };
  },
  methods: {
    verDetalles() {
      console.log(this.cajaCustomer);
      let requestId = "customers/" + this.cajaCustomer;
      let url = Global.urlApiCustomers + requestId;
      console.log(url);
      axios.get(url).then((response) => {
        console.log("Leyendo servicio id...");
        this.detalleCustomer = response.data.customer;
      });
    },
  },
  mounted() {
    let request = "customers";
    let url = Global.urlApiCustomers + request;
    axios.get(url).then((response) => {
      console.log("Leyendo servicio...");
      this.customers = response.data.results;
    });
  },
};
</script>

<style scoped>
h1 {
  font-size: 24px;
  margin-bottom: 15px;
}

input[type="text"] {
  padding: 8px;
  margin-right: 8px;
  font-size: 16px;
  border: 1px solid #ccc;
  border-radius: 5px;
}

button {
  padding: 8px 12px;
  font-size: 16px;
  border: none;
  background-color: #007bff;
  color: white;
  cursor: pointer;
  border-radius: 5px;
}

button:hover {
  background-color: #0056b3;
}

.customers-table,
.details-table {
  width: 100%;
  border-collapse: collapse;
  margin-top: 20px;
  box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
  border-radius: 5px;
  overflow: hidden;
}

.customers-table th,
.details-table th {
  background-color: #f8f9fa;
  color: #333;
  padding: 10px;
  text-align: left;
}

.customers-table td,
.details-table td {
  padding: 10px;
  text-align: left;
  border-bottom: 1px solid #ddd;
}

.customers-table tbody tr:nth-child(even) {
  background-color: #f9f9f9;
}

.details-table th {
  width: 30%;
  background-color: #e9ecef;
  font-weight: bold;
}

.details-table td {
  width: 70%;
}

.customers-table tbody tr:hover {
  background-color: #f1f1f1;
}
</style>
