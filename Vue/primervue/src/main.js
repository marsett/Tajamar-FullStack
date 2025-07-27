import { createApp } from 'vue'
import App from './App.vue'
import router from './Router'

// Comenzamos separando nuestra creación de aplicación en una variable
var app = createApp(App);
app.config.globalProperties.$filters = {
    // Creamos dos métodos que recibirán parámetros y devolverán un código
    mayuscula(dato) {
        return dato.toUpperCase();
    },
    getNumeroDoble(numero) {
        return numero * 2;
    }
}

app.use(router).mount('#app')
