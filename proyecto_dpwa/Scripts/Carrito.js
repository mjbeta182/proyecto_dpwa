(() => {
  // construyendo la logica una vez el dom haya cargado completamente
  document.addEventListener('DOMContentLoaded', (e) => {
    let TBody = document.getElementById('checkoutBody');
    const BtnBorrarCarrito = document.getElementById('btnBorrarCarrito');
    let Entrega = document.getElementById('entrega');

    // Actualizando el total
    actualizarTotal();

    // build the checkout
    buildCheckout(TBody);

    TBody.addEventListener('click', (e) => {
      // If the click was over the trash button
      if (e.target.dataset['action'] === 'delete') {
        removeProduct(e);
      }
    });

    TBody.addEventListener('change', (e) => {
      if (e.target.dataset['action'] === 'quantity') {
        updateProduct(e, TBody); // This should re render the layout.
      }
    });

    BtnBorrarCarrito.addEventListener('click', () => {
      localStorage.setItem('checkout', JSON.stringify([]));

      actualizarTotal();
      buildCheckout(TBody);
    });

    Entrega.addEventListener('change', (e) => {
      actualizarTotal();
    });
  });

  /**
   * @returns {void}
   */
  function buildCheckout(TBody) {
    let products = JSON.parse(localStorage.getItem('checkout'));

    let htmlContent = products.map((product) => {
      let imageUrl = `https://reyesmarq.github.io/proyecto_dpw/images/${product.imageUrl}.PNG`;
      return `
        <tr class="align-middle">
          <th scope="row" class="p-4">
            <img src="${imageUrl}" alt="" width="100">
          </th>
          <td class="p-4">${product.description}</td>
          <td class="text-center p-4">
            <input type="number" class="form-control" style="width: 100px" value="${
              product.quantity
            }" min="1" max="10" data-action="quantity" data-product-id=${
        product.id
      }>
          </td>
          <td class="text-center p-4">$${product.price}</td>
          <td class="text-center p-4">$${Number(
            product.price * product.quantity
          ).toFixed(2)}</td>
          <td class="text-center p-4">
            <button class="btn btn-sm btn-danger">Eliminar</button>
          </td>
        </tr>
      `;
    });

    TBody.innerHTML = htmlContent;
  }

  function removeProduct(e) {
    let productId = e.target.dataset['productId'];

    if (!productId) return;

    // Seleccionando los productos que ya estan en el localstorage
    let products = Array.from(JSON.parse(localStorage.getItem('checkout')));

    // Seleccionar todos los productos excepto el que vamos a eliminar, para dejarlo fuera del arreglo
    products = products.filter((product) => product.id != productId);

    // Guardamos la nueva informacion del arreglo
    localStorage.setItem('checkout', JSON.stringify(products));

    // calculando el total
    actualizarTotal();

    // Contruimos nuevamente el layout
    buildCheckout();
  }

  function updateProduct(e, TBody) {
    let quantity = e.target.value;
    let productId = e.target.dataset['productId'];

    // getting the local state of the products
    let products = Array.from(JSON.parse(localStorage.getItem('checkout')));

    // getting the index of the products we are about to change
    let product = products.find((product) => product.id == productId);
    let productIndex = products.findIndex((product) => product.id == productId);

    // Updating the data
    products.splice(productIndex, 1, { ...product, quantity });

    // updateing the local storage with the new products object
    localStorage.setItem('checkout', JSON.stringify(products));

    // Actualizando el total
    actualizarTotal();

    // re- render the html
    buildCheckout(TBody);
  }

  function actualizarTotal() {
    let Subtotal = document.getElementById('subtotal');
    let Envio = document.getElementById('envio');
    let Total = document.getElementById('total');
    let productos = JSON.parse(localStorage.getItem('checkout'));
    let entrega = document.getElementById('entrega').value;
    let envio = entrega == 'domicilio' ? 10 : 0;
    let total;
    let subTotal = productos.reduce((total, product) => {
      let { quantity, price } = product;
      let accumulative = Number(quantity) * Number(price);

      return total + accumulative;
    }, 0);

    Subtotal.innerHTML = `$${subTotal.toFixed(2)}`;

    total = subTotal * 1.13;

    if (entrega == 'domicilio') {
      total = subTotal * 1.13 + 10;
    }

    Envio.innerHTML = `$${envio.toFixed(2)}`;
    Total.innerHTML = `$${total.toFixed(2)}`;
  }
})();
