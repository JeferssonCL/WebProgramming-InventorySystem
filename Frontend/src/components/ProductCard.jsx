import React from "react";

const ProductCard = ({ product }) => {
    return (
        <div className="flex justify-between p-6 border rounded-lg">
            <img
                src={product.ImageUrl}
                alt={product.Name}
                width="124"
                height="124"
            />
            <div className="p-6 text-right">
                <h4 className="font-bold ">{product.Name}</h4>
                <p className="text-gray-600">
                    ${product.Price.toFixed(2)} x {product.Quantity}
                </p>
                <b>Subtotal = ${product.SubTotal}</b>
            </div>
        </div>
    );
};

export default ProductCard;
