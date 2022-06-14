/**
 * Este script es para poder actualizar el numero de elementos que se encuentran en el carrito
 * al momento de cargar la pagina.
 *
 * La actualizacion del carrito cuando un producto se agrega se encuentra en home.js
 */
(() => {
    document.addEventListener('DOMContentLoaded', (e) => {
        let Carrito = document.getElementById('carrito');
        let total = localStorage.getItem('checkout')
            ? JSON.parse(localStorage.getItem('checkout')).length
            : 0;

        Carrito.innerHTML = `
      <span class="text-info h6 fw-bold">${total}
      <i class="bi bi-cart pe-none"></i> | Comprar
      </span>
    `;
    });
})();
