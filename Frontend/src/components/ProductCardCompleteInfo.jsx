import React from "react";

const ProductCardCompleteInfo = ({ product, onDelete }) => {
    console.log(product.img);
    return (
        <div className="flex justify-between p-6 border rounded-lg">
            <img
                src={product.image[0].url}
                alt={product.name}
                width="124"
                height="124"
            />
            <div className="flex flex-row items-center">
                <div className="p-6 text-right">
                    <h4 className="font-bold ">{product.name}</h4>
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
