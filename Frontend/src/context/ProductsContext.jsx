import React, { createContext, useState, useEffect } from 'react';

export const ProductsContext = createContext();

export const ProductsProvider = ({ children }) => {
    const [products, setProducts] = useState(() => {
        const savedProducts = localStorage.getItem('products');
        console.log("Initial load from localStorage:", savedProducts);
        return savedProducts ? JSON.parse(savedProducts) : [];
    });

    // This will trigger whenever `products` changes
    useEffect(() => {
        console.log("Products updated:", products);
        localStorage.setItem('products', JSON.stringify(products));
    }, [products]);

    const addProduct = (newProduct) => {
        const productToStore = {
            id: newProduct.id,
            name: newProduct.name,
            price: newProduct.price,
            image: newProduct.images,
            quantity: 1
        };
        const productExists = products.find(item => item.id === productToStore.id);
        if (!productExists) {
            setProducts((prevProducts) => {
                console.log("Adding new product:", productToStore);
                return [...prevProducts, productToStore];
            });
        }
    };

    const removeProductById = (id) => {
        setProducts((prevProducts) => {
            const updatedProducts = prevProducts.filter(item => item.id !== id);
            console.log("Removed product with id:", id);
            return updatedProducts;
        });
    };

    const handleDecreaseQuantity = (id) => {
        console.log("Decrease");
        setProducts((prevProducts) =>
            prevProducts
                .map(item => {
                    if (item.id === id) {
                        console.log(`Decreasing quantity for product id ${id}`);
                        return { ...item, quantity: item.quantity > 1 ? item.quantity - 1 : 1 };
                    }
                    return item;
                })
        );
    };

    const handleIncreaseQuantity = (id) => {
        console.log("Increase" + id);
        setProducts((prevProducts) =>
            prevProducts.map(item => {
                if (item.id === id) {
                    console.log(`Increasing quantity for product id ${id}`);
                    return { ...item, quantity: item.quantity + 1 };
                }
                return item;
            })
        );
    };

    return (
        <ProductsContext.Provider value={{ products, removeProductById, addProduct, handleDecreaseQuantity, handleIncreaseQuantity }}>
            {children}
        </ProductsContext.Provider>
    );
};
