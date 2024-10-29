import {useContext} from "react";
import {ProductsContext} from "../Context/ProductsContext.jsx";

const AddToCartButton = ({product, isProduct}) => {
    const { addProduct } = useContext(ProductsContext);
    const ComboToProductDTO = (combo) => {
        console.log('AA: ' + combo.comboImageDto.altText);
        return {
            id: combo.id,
            name: combo.name,
            price: combo.priceWithDiscount,
            image: combo.comboImageDto,
            quantity: 1,
            stock : 100
        }
    }

    const ProductShoppingCartDTO = (product) => {
        return {
            id: product.id,
            name: product.name,
            price: product.priceWithDiscount,
            image: product.images[0] ?? [],
            quantity: 1,
            stock : 100
        }
    }

    return (
        <div
            className="bg-[#7790ED] rounded-s pl-3 pr-3 pt-1 pb-1 text-center text-white cursor-pointer"
            onClick={() => {
                console.log(isProduct);
                addProduct(isProduct ? ProductShoppingCartDTO(product) : ComboToProductDTO(product))
            }}
        >
            Add to Card
        </div>
    )
}

export default AddToCartButton;
