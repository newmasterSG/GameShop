let quantity = 1;
let basePrice = 0;

interface ProductData {
    name: string;
    quantity: number;
    price: number;
    image: string;
    id: number;
}

function updateTotalPrice(basePrice: number) {
    const totalPrice = basePrice * quantity;
    const totalPriceElement = document.getElementById("totalPrice");
    if (totalPriceElement) {
        totalPriceElement.textContent = totalPrice.toFixed(2);
    }
}

document.addEventListener("DOMContentLoaded", function () {
    const quantityInput = document.getElementById("quantityInput") as HTMLInputElement;
    const addToCartButton = document.getElementById("addToCart") as HTMLButtonElement;

    if (quantityInput && addToCartButton) {
        quantityInput.addEventListener("input", function () {
            quantity = parseInt(quantityInput.value);
            updateTotalPrice(basePrice);
        });

        addToCartButton.addEventListener("click", function () {
            const productName = document.getElementById('gameTitle').textContent;
            const image = document.getElementById('gameImage').getAttribute('src');
            const gameModal = document.getElementById('gameModal');
            const gameId = parseInt(gameModal.getAttribute('data-gameid'));

            const productData: ProductData = {
                name: productName,
                quantity: quantity,
                price: basePrice,
                image: image,
                id: gameId,
            };


            let cart: ProductData[] = JSON.parse(localStorage.getItem('cart')) || [];
            cart.push(productData);
            localStorage.setItem('cart', JSON.stringify(cart));

            alert("Added " + quantity + " items of " + productName + " to the cart.");
        });
    }

    // Getting the base price on page load
    const priceElement = document.getElementById("price");
    if (priceElement) {
        const priceText = priceElement.textContent;
        basePrice = parseFloat(priceText.split(' ').pop());
        updateTotalPrice(basePrice);
    }
});