import React, { createContext, useState, useEffect } from 'react';

export const ProductsContext = createContext();

export const ProductsProvider = ({ children }) => {
    const [products, setProducts] = useState(() => {
        const savedProducts = localStorage.getItem('products');
        return savedProducts ? JSON.parse(savedProducts) : [];
    });

    useEffect(() => {
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
            setProducts((prevProducts) => [...prevProducts, productToStore]);
        }
    };

    const removeProductById = (id) => {
        setProducts((prevProducts) => prevProducts.filter((item, _) => item.id !== id));
    };

    return (
        <ProductsContext.Provider value={{ products, removeProductById, addProduct }}>
            {children}
        </ProductsContext.Provider>
    );
};
