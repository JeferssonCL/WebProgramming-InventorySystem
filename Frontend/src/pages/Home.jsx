import { useState } from "react"
import { ProductCard } from "../components/ProductCard"

export function Home() {

    const [productList, setProductList] = useState([])

    return (

        <div className="products-section">
            <ProductCard id="123456" name="Product example" price={10} brand="Folladores" image="https://cdn.shopify.com/s/files/1/0070/7032/files/product-label-design.jpg?v=1680902906" />
        </div>
    )
}