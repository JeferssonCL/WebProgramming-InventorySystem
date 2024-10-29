import React, { useContext } from "react";
import { ProductsContext } from "../context/ProductsContext.jsx";
import { FaRegTrashAlt, FaTag } from "react-icons/fa";

const _ComboBoxVariants = ({ attributesMap = {}, productId }) => {
    const { handleAttributeChange } = useContext(ProductsContext);

    // Si no hay attributesMap o está vacío, no renderizamos nada
    if (!attributesMap || Object.keys(attributesMap).length === 0) {
        return null;
    }

    return (
        <form>
            {Object.keys(attributesMap).map(key => (
                <div className="bg-transparent flex flex-row justify-between space-x-3" key={key}>
                    <label>{key}: </label>
                    <select
                        className="bg-white" 
                        name={key}
                        onChange={(e) => handleAttributeChange(key+'-'+productId, e.target.value)}
                    >
                        <option value="">Select {key}</option>
                        {attributesMap[key]?.map(variant => (
                            <option 
                                key={key+variant.attributes[0].value} 
                                value={variant.attributes[0].value}
                            >
                                {variant.attributes[0].value}
                            </option>
                        ))}
                    </select>
                </div>
            ))}
        </form>
    );
};

const ProductCardCompleteInfo = ({ product, onDelete }) => {
    const { selectedAttributes, handleIncreaseQuantity, handleDecreaseQuantity } = useContext(ProductsContext);
    
    // Validamos que product tenga todas las propiedades necesarias
    if (!product || !product.image || !product.image[0]) {
        return null;
    }

    const priceWithDiscount = product.discountPercentage 
        ? product.price * (1 - product.discountPercentage / 100)
        : product.price;

    const subtotalWithDiscount = priceWithDiscount * product.quantity;

    return (
        <div className="flex justify-between p-6 border rounded-lg">
            <img
                src={product.image[0].url}
                alt={product.name}
                width="124"
                height="124"
                className="object-cover"
            />
            <div className="flex flex-row items-center">
                <div className="flex flex-col p-6 text-right items-end">
                    <h4 className="font-bold">{product.name}</h4>
                    
                    {/* Solo renderizamos _ComboBoxVariants si product.attributesMap existe */}
                    {product.attributesMap && (
                        <_ComboBoxVariants 
                            attributesMap={product.attributesMap} 
                            productId={product.id}
                        />
                    )}
                    
                    <div className="flex flex-row h-fit justify-between w-20">
                        <button
                            className="border border-violet-600 pr-2 pl-2 pt-0.5 pb-0.5 rounded-md hover:bg-violet-100"
                            onClick={() => handleIncreaseQuantity(product.id)}
                        >
                            +
                        </button>
                        <label className="font-bold text-lg">
                            {product.quantity}
                        </label>
                        <button
                            className="border border-violet-600 pr-2 pl-2 pt-0.5 pb-0.5 rounded-md hover:bg-violet-100"
                            onClick={() => handleDecreaseQuantity(product.id)}
                        >
                            -
                        </button>
                    </div>

                    {product.discountPercentage ? (
                        <div className="flex flex-col items-end">
                            <p className="text-gray-600 line-through">
                                ${product.price.toFixed(2)} x {product.quantity}
                            </p>
                            <div className="flex items-center text-red-500 text-sm font-bold">
                                <FaTag className="mr-1" />
                                {product.discountPercentage}% OFF
                            </div>
                            <p className="text-gray-600">
                                ${priceWithDiscount.toFixed(2)} x {product.quantity}
                            </p>
                            <b>Subtotal: ${subtotalWithDiscount.toFixed(2)}</b>
                        </div>
                    ) : (
                        <div className="flex flex-col items-end">
                            <p className="text-gray-600">
                                ${product.price.toFixed(2)} x {product.quantity}
                            </p>
                            <b>Subtotal: ${(product.price * product.quantity).toFixed(2)}</b>
                        </div>
                    )}
                </div>
                
                <button
                    className="p-2 hover:bg-gray-100 rounded-full"
                    onClick={onDelete}
                >
                    <FaRegTrashAlt className="w-6 h-6 text-gray-600" />
                </button>
            </div>
        </div>
    );
};

export default ProductCardCompleteInfo;
