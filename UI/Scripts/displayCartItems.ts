interface ProductData {
    name: string;
    quantity: number;
    price: number;
    image: string;
}

document.addEventListener("DOMContentLoaded", function () {
    const cartData: ProductData[] = JSON.parse(localStorage.getItem('cart')) || [];
    const cartItemsContainer = document.getElementById('cartItems');

    if (cartData.length > 0) {
        // Creating a container with Bootstrap
        const container = document.createElement('div');
        container.classList.add('row', 'row-cols-2', 'g-4');

        cartData.forEach(function (product, index) {
            const col = document.createElement('div');
            col.classList.add('col');

            const card = document.createElement('div');
            card.classList.add('card', 'h-100');

            if (product.image) {
                const img = document.createElement('img');
                img.src = product.image;
                img.alt = product.name;
                img.classList.add('card-img-top', 'img-fluid');
                card.appendChild(img);
            }

            const cardBody = document.createElement('div');
            cardBody.classList.add('card-body');

            const infoDiv = document.createElement('div');
            infoDiv.classList.add('cart-item-info');
            infoDiv.textContent = `Name: ${product.name}, Quantity: ${product.quantity}, Price: ${product.price}`;
            cardBody.appendChild(infoDiv);

            // Adding a delete button
            const removeButton = document.createElement('button');
            removeButton.textContent = 'Remove';
            removeButton.classList.add('btn', 'btn-danger');
            removeButton.addEventListener('click', function () {
                const newQuantity = parseInt(prompt('Enter the quantity to remove:', '1'));

                if (!isNaN(newQuantity) && newQuantity > 0 && newQuantity <= product.quantity) {
                    product.quantity -= newQuantity;
                    if (product.quantity === 0) {
                        cartData.splice(index, 1); // Remove item from array if quantity is zero
                    }
                    localStorage.setItem('cart', JSON.stringify(cartData)); // Updating Local Storage
                    refreshCartItems(); // Refreshing the display on the page
                } else {
                    alert('Invalid quantity entered.');
                }
            });
            cardBody.appendChild(removeButton);

            card.appendChild(cardBody);
            col.appendChild(card);
            container.appendChild(col);
        });

        if (cartItemsContainer) {
            cartItemsContainer.appendChild(container);
        }
    } else {
        const emptyCartMessage = document.createElement('p');
        emptyCartMessage.textContent = "Cart is empty.";

        if (cartItemsContainer) {
            cartItemsContainer.appendChild(emptyCartMessage);
        }
    }
});

function refreshCartItems() {
    const cartItemsContainer = document.getElementById('cartItems');
    if (cartItemsContainer) {
        cartItemsContainer.innerHTML = ''; // Cleaning the container

        const cartData: ProductData[] = JSON.parse(localStorage.getItem('cart')) || [];

        // Create a container with Bootstrap
        const container = document.createElement('div');
        container.classList.add('row', 'row-cols-2', 'g-4');

        cartData.forEach(function (product, index) {
            const col = document.createElement('div');
            col.classList.add('col');

            const card = document.createElement('div');
            card.classList.add('card', 'h-100');

            if (product.image) {
                const img = document.createElement('img');
                img.src = product.image;
                img.alt = product.name;
                img.classList.add('card-img-top', 'img-fluid');
                card.appendChild(img);
            }

            const cardBody = document.createElement('div');
            cardBody.classList.add('card-body');

            const infoDiv = document.createElement('div');
            infoDiv.classList.add('cart-item-info');
            infoDiv.textContent = `Name: ${product.name}, Quantity: ${product.quantity}, Price: ${product.price}`;
            cardBody.appendChild(infoDiv);

            // Adding a delete button
            const removeButton = document.createElement('button');
            removeButton.textContent = 'Remove';
            removeButton.classList.add('btn', 'btn-danger');
            removeButton.addEventListener('click', function () {
                const newQuantity = parseInt(prompt('Enter the quantity to remove:', '1'));

                if (!isNaN(newQuantity) && newQuantity > 0 && newQuantity <= product.quantity) {
                    product.quantity -= newQuantity;
                    if (product.quantity === 0) {
                        cartData.splice(index, 1); // Remove item from array if quantity is zero
                    }
                    localStorage.setItem('cart', JSON.stringify(cartData)); // Updating Local Storage
                    refreshCartItems(); // Refreshing the display on the page
                } else {
                    alert('Invalid quantity entered.');
                }
            });
            cardBody.appendChild(removeButton);

            card.appendChild(cardBody);
            col.appendChild(card);
            container.appendChild(col);
        });

        if (cartItemsContainer) {
            cartItemsContainer.appendChild(container);
        }
    }
};