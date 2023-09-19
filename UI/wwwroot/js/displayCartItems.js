document.addEventListener("DOMContentLoaded", function () {
    var cartData = JSON.parse(localStorage.getItem('cart')) || [];
    var cartItemsContainer = document.getElementById('cartItems');
    var payButton = document.getElementById('payButton');
    var totalPriceContainer = document.getElementById('totalPrice');
    if (cartData.length > 0) {
        var payButton_1 = document.createElement('button');
        payButton_1.textContent = 'Pay';
        payButton_1.classList.add('btn', 'btn-primary');
        // Creating a container with Bootstrap
        var container_1 = document.createElement('div');
        container_1.classList.add('row', 'row-cols-2', 'g-4');
        var totalSum_1 = 0;
        cartData.forEach(function (product, index) {
            var col = document.createElement('div');
            col.classList.add('col');
            var card = document.createElement('div');
            card.classList.add('card', 'h-100');
            if (product.image) {
                var img = document.createElement('img');
                img.src = product.image;
                img.alt = product.name;
                img.classList.add('card-img-top', 'img-fluid');
                card.appendChild(img);
            }
            var cardBody = document.createElement('div');
            cardBody.style.border = 'border-radius : 20px';
            cardBody.classList.add('card-body');
            cardBody.setAttribute('data-game-id', product.id.toString());
            var infoDiv = document.createElement('div');
            infoDiv.classList.add('cart-item-info');
            infoDiv.setAttribute('data-game-count', product.quantity.toString());
            infoDiv.textContent = "Name: ".concat(product.name, ", Quantity: ").concat(product.quantity, ", Price: ").concat(product.price);
            cardBody.appendChild(infoDiv);
            // Adding a delete button
            var removeButton = document.createElement('button');
            removeButton.textContent = 'Remove';
            removeButton.classList.add('btn', 'btn-danger');
            removeButton.addEventListener('click', function () {
                var newQuantity = parseInt(prompt('Enter the quantity to remove:', '1'));
                if (!isNaN(newQuantity) && newQuantity > 0 && newQuantity <= product.quantity) {
                    product.quantity -= newQuantity;
                    if (product.quantity === 0) {
                        cartData.splice(index, 1); // Remove item from array if quantity is zero
                    }
                    localStorage.setItem('cart', JSON.stringify(cartData)); // Updating Local Storage
                    refreshCartItems(); // Refreshing the display on the page
                }
                else {
                    alert('Invalid quantity entered.');
                }
            });
            cardBody.appendChild(removeButton);
            card.appendChild(cardBody);
            col.appendChild(card);
            container_1.appendChild(col);
            totalSum_1 += product.price * product.quantity;
        });
        if (totalPriceContainer) {
            totalPriceContainer.textContent = "Total Price: ".concat(totalSum_1.toFixed(2), " USD");
        }
        if (cartItemsContainer) {
            cartItemsContainer.appendChild(container_1);
        }
    }
    else {
        var emptyCartMessage = document.createElement('p');
        emptyCartMessage.textContent = "Cart is empty.";
        if (cartItemsContainer) {
            cartItemsContainer.appendChild(emptyCartMessage);
        }
    }
});
function refreshCartItems() {
    var cartItemsContainer = document.getElementById('cartItems');
    if (cartItemsContainer) {
        cartItemsContainer.innerHTML = ''; // Cleaning the container
        var cartData_1 = JSON.parse(localStorage.getItem('cart')) || [];
        // Create a container with Bootstrap
        var container_2 = document.createElement('div');
        container_2.classList.add('row', 'row-cols-2', 'g-4');
        cartData_1.forEach(function (product, index) {
            var col = document.createElement('div');
            col.classList.add('col');
            var card = document.createElement('div');
            card.classList.add('card', 'h-100');
            if (product.image) {
                var img = document.createElement('img');
                img.src = product.image;
                img.alt = product.name;
                img.classList.add('card-img-top', 'img-fluid');
                card.appendChild(img);
            }
            var cardBody = document.createElement('div');
            cardBody.classList.add('card-body');
            var infoDiv = document.createElement('div');
            infoDiv.classList.add('cart-item-info');
            infoDiv.textContent = "Name: ".concat(product.name, ", Quantity: ").concat(product.quantity, ", Price: ").concat(product.price);
            cardBody.appendChild(infoDiv);
            // Adding a delete button
            var removeButton = document.createElement('button');
            removeButton.textContent = 'Remove';
            removeButton.classList.add('btn', 'btn-danger');
            removeButton.addEventListener('click', function () {
                var newQuantity = parseInt(prompt('Enter the quantity to remove:', '1'));
                if (!isNaN(newQuantity) && newQuantity > 0 && newQuantity <= product.quantity) {
                    product.quantity -= newQuantity;
                    if (product.quantity === 0) {
                        cartData_1.splice(index, 1); // Remove item from array if quantity is zero
                    }
                    localStorage.setItem('cart', JSON.stringify(cartData_1)); // Updating Local Storage
                    refreshCartItems(); // Refreshing the display on the page
                }
                else {
                    alert('Invalid quantity entered.');
                }
            });
            cardBody.appendChild(removeButton);
            card.appendChild(cardBody);
            col.appendChild(card);
            container_2.appendChild(col);
        });
        if (cartItemsContainer) {
            cartItemsContainer.appendChild(container_2);
        }
    }
}
;
//# sourceMappingURL=displayCartItems.js.map