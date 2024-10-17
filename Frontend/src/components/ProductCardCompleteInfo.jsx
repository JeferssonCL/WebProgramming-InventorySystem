import React, {useContext} from "react";
import {ProductsContext} from "../context/ProductsContext.jsx";

const ProductCardCompleteInfo = ({ product, onDelete }) => {
    console.log(product.img);
    const { handleIncreaseQuantity, handleDecreaseQuantity } = useContext(ProductsContext);

    return (
        <div className="flex justify-between p-6 border rounded-lg">
            <img
                src={product.image[0].url}
                alt={product.name}
                width="124"
                height="124"
            />
            <div className="flex flex-row items-center">
                <div className="flex flex-col p-6 text-right items-end">
                    <h4 className="font-bold ">{product.name}</h4>
                    <div className="flex flex-row h-fit justify-between w-20">
                      <button
                          className="border border-violet-600 pr-2 pl-2 pt-0.5 pb-0.5 rounded-md"
                          onClick={() => handleIncreaseQuantity(product.id)}
                      >+</button>
                      <label className="font-bold text-lg">{product.quantity}</label>
                      <button
                          className="border border-violet-600 pr-2 pl-2 pt-0.5 pb-0.5 rounded-md"
                          onClick={() => handleDecreaseQuantity(product.id)}
                      >-</button>
                    </div>
                    <p className="text-gray-600">
                        ${product.price.toFixed(2)} x {product.quantity}
                    </p>
                    <b>Subtotal: ${product.price * product.quantity}</b>
                </div>
                <img
                    src="https://cdn-icons-png.flaticon.com/512/3405/3405244.png"
                    alt="Delete icon"
                    width="24"
                    height="24"
                    onClick={onDelete}
                />
            </div>
        </div>
    );
};

export default ProductCardCompleteInfo;
