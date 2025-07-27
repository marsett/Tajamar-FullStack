export class Producto {
    // Para que las propiedades sean accesibles, necesitamos
    // que sean public
    // public nombre: string;
    // public imagen: string;
    // public precio: number;

    // Tendremos un constructor para recibir los datos
    // constructor(name: string, image: string, price: number) {
    //     this.nombre = name;
    //     this.imagen = image;
    //     this.precio = price;
    // }

    constructor(
        public nombre: string,
        public imagen: string,
        public precio: number,
    ) { }
}