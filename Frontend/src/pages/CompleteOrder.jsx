import { loadStripe } from "@stripe/stripe-js";
import ProductCardCompleteInfo from "../components/ProductCardCompleteInfo";
import { useContext } from "react";
import { ProductsContext } from "../context/ProductsContext";

function CompleteOrder() {
    const { products, removeProductById } = useContext(ProductsContext);

    const shoppingCartDtoList = products.map(item => ({
        id: item.id,
        name: item.name,
        price: item.price,
        imageUrl: item.image.length > 0 ? item.image[0].url : '',
        quantity: item.quantity,
        discountPercentage: item.discountPercentage || 0,
        priceWithDiscount: item.discountPercentage 
            ? item.price * (1 - item.discountPercentage / 100)
            : item.price
    }));

    const onSubmitCart = async () => {
        const stripe = await loadStripe("pk_test_51Q81UpP3WBhplXYwggVU8aKSusfUgfjKqFPz6amcMmjkcnJSJVOL22DHfqQiyou6mtPlbTpOtehXhG0wFRFIo47l00rb1JJ1Qc");
        const response = await fetch('http://localhost:5163/api/Checkout/submit-cart', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(shoppingCartDtoList)
        });

        if (!response.ok) {
            const errorMessage = await response.text();
            console.error("Error from API:", errorMessage);
            return;
        }

        const session = await response.json();
        const result = stripe.redirectToCheckout({
            sessionId: session.id
        });
        if (result.error) {
            console.log(result.error);
        }
    };

    const calculateTotalAmount = (products) => {
        if (!Array.isArray(products)) {
            console.error("The products parameter is not an array", products);
            return 0;
        }

        return products.reduce((total, product) => {
            const priceToUse = product.discountPercentage 
                ? product.price * (1 - product.discountPercentage / 100)
                : product.price;
            return total + (priceToUse * product.quantity);
        }, 0);
    };

    const totalAmount = calculateTotalAmount(products);

    return (
        <div className="m-6 flex flex-row justify-between space-x-6 bg-white text-black p-6 border rounded-lg">
            <div className="w-full">
                <h3 className="font-bold text-2xl">Shopping Cart</h3>
                <h4 className="font-bold text-lg">Order Details</h4>
                <div>
                    {products.map((item) => (
                        <ProductCardCompleteInfo
                            key={item.id}
                            product={item}
                            onDelete={() => removeProductById(item.id)}
                        />
                    ))}
                </div>
                <h3 className="pt-4 font-bold text-lg justify-self-end">
                    Total: ${totalAmount.toFixed(2)}
                </h3>
                <div className="justify-self-end mt-2">
                    <button
                        className="justify-self-end rounded-md bg-violet-500 text-white pr-5 pl-5 pt-2 pb-2"
                        onClick={onSubmitCart}
                    >
                        Go to Checkout
                    </button>
                </div>
            </div>
        </div>
    );
}

export default CompleteOrder;
