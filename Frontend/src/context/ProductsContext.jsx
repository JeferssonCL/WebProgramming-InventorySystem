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

    const handleDecreaseQuantity = (id) => {
        setProducts((prevProducts) => prevProducts.map(item => {
            if (item.id === id) {
              return { ...item, quantity: item.quantity > 1 ? item.quantity - 1 : 0 };
            }
            return item;}))
      };
    
      const handleIncreaseQuantity = (id) => {
        setProducts((prevProducts) => prevProducts.map(item => {
            if (item.id === id) {
              return { ...item, quantity: item.quantity + 1 };
            }
            return item;}))
      };

    return (
        <ProductsContext.Provider value={{ products, removeProductById, addProduct, handleDecreaseQuantity, handleIncreaseQuantity }}>
            {children}
        </ProductsContext.Provider>
    );
};
