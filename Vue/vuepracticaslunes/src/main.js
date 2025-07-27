import { createApp } from 'vue'
import App from './App.vue'
import router from './Router'

var app = createApp(App);
app.config.globalProperties.$filters = {
    getDibujo(numero) {
        if (numero % 2 == 0) {
            return "<h3 style='color: green'>Par: " + numero + "</h3>";
        } else {
            return "<h3 style='color: red'>Impar: " + numero + "</h3>";
        }
    },
    // getOperacion(numero){
    //     var operacion = "";
    //     var aux = []
    //     for (let i = 0; i <= 10; i++) {
    //         operacion = numero + "*" + i;
    //         aux.push(operacion);
    //     }
    //     return aux;
    // },
    // getMultiplicacion(numero){
    //     var resultado = "";
    //     var aux = []
    //     for (let i = 0; i <= 10; i++) {
    //         resultado = numero * i;
    //         aux.push(resultado);
    //     }
    //     return aux;
    // }
    getOperacion(numero, multi){
        return numero + "*" + multi;
    },
    getMultiplicacion(numero, multi){
        return numero * multi;
    }
}

app.use(router).mount('#app')
