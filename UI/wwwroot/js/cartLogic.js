var quantity = 1;
var basePrice = 0;
function updateTotalPrice(basePrice) {
    var totalPrice = basePrice * quantity;
    var totalPriceElement = document.getElementById("totalPrice");
    if (totalPriceElement) {
        totalPriceElement.textContent = totalPrice.toFixed(2);
    }
}
document.addEventListener("DOMContentLoaded", function () {
    var quantityInput = document.getElementById("quantityInput");
    var addToCartButton = document.getElementById("addToCart");
    if (quantityInput && addToCartButton) {
        quantityInput.addEventListener("input", function () {
            quantity = parseInt(quantityInput.value);
            updateTotalPrice(basePrice);
        });
        addToCartButton.addEventListener("click", function () {
            var productName = document.getElementById('gameTitle').textContent;
            var image = document.getElementById('gameImage').getAttribute('src');
            var productData = {
                name: productName,
                quantity: quantity,
                price: basePrice,
                image: image,
            };
            var cart = JSON.parse(localStorage.getItem('cart')) || [];
            cart.push(productData);
            localStorage.setItem('cart', JSON.stringify(cart));
            alert("Added " + quantity + " items of " + productName + " to the cart.");
        });
    }
    // Getting the base price on page load
    var priceElement = document.getElementById("price");
    if (priceElement) {
        var priceText = priceElement.textContent;
        basePrice = parseFloat(priceText.split(' ').pop());
        updateTotalPrice(basePrice);
    }
});
//# sourceMappingURL=cartLogic.js.map