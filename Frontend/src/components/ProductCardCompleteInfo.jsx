import React, {useContext} from "react";
import {ProductsContext} from "../context/ProductsContext.jsx";

const _ComboBoxVariants = ({attributesMap, productId}) => {
    const { handleAttributeChange } = useContext(ProductsContext);
    return (
        <form>
            {Object.keys(attributesMap).map(key => (
                <div className="bg-transparent flex flex-row justify-between space-x-3" key={key}>
                    <label>{key}: </label>
                    <select
                        className="bg-white" name={key}
                        onChange={(e) => handleAttributeChange(key+'-'+productId, e.target.value)}>
                        <option value="">Select {key}</option>
                        {attributesMap[key].map(variant => (
                            <option key={key+variant.attributes[0].value} value={variant.attributes[0].value}>
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
                    <_ComboBoxVariants attributesMap={product.attributesMap} productId={product.id}></_ComboBoxVariants>
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
