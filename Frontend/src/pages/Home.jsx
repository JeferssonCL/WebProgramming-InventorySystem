import { useState, useEffect } from "react";
import { ProductCard } from "../components/ProductCard";
import axios from 'axios';
import '../styles/pages/home.css';

export function Home() {
    const [productList, setProductList] = useState([]);
    const [cart, setCart] = useState([]);

    useEffect(() => {
        const apiUrl = "http://localhost:5163/api/product?page=1&limit=20";

        const fetchProducts = async () => {
            try {
                const response = await axios.get(apiUrl);
                setProductList(response.data.data);
            } catch (error) {
                console.error("Error fetching products:", error);
            }
        };

        fetchProducts();
    }, []);

    const handleAddToCart = (product) => {
        const productToStore = {
            id: product.id,
            name: product.name,
            price: product.price,
            image: product.image,
        };

        const productExists = cart.find(item => item.id === productToStore.id);
        if (!productExists) {
            const updatedCart = [...cart, productToStore];
            setCart(updatedCart);
            localStorage.setItem('cart', JSON.stringify(updatedCart));
        } else {
            console.log("The product is already in the cart");
        }
    };

    return (
        <div className="products-section">
            {
                productList.length === 0 ? (
                    <p>No products available at the moment :c</p>
                ) : (
                    productList.map(product => (
                        <ProductCard
                            key={product.id}
                            id={product.id}
                            name={product.name}
                            brand={product.brand}
                            price={product.price}
                            image={product.images[0].url}
                            onAddToCart={() => handleAddToCart(product)}
                        />
                    ))
                )
            }
        </div>
    );
}
