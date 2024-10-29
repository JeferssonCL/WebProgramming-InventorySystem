import React, { createContext, useEffect, useState } from 'react';

export const ProductsContext = createContext();

export const ProductsProvider = ({ children }) => {
    const [products, setProducts] = useState(() => {
        const savedProducts = localStorage.getItem('products');
        return savedProducts ? JSON.parse(savedProducts) : [];
    });

    const [selectedAttributes, setSelectedAttributes] = useState({});

    const handleAttributeChange = (attributeName, value) => {
        setSelectedAttributes(prev => ({
            ...prev,
            [attributeName]: value
        }));
    };

    useEffect(() => {
        localStorage.setItem('products', JSON.stringify(products));
    }, [products]);

    const addProduct = (newProduct) => {
        const productToStore = {
            id: newProduct.id,
            name: newProduct.name,
            price: newProduct.price,
            image: newProduct.images,
            quantity: 1,
            stock: newProduct.stock,
            discountPercentage: newProduct.discountPercentage,
            priceWithDiscount: newProduct.priceWithDiscount
        };

        const productExists = products.find(item => item.id === productToStore.id);
        if (!productExists) {
            if (productToStore.stock <= 0) {
                return;
            }
            setProducts((prevProducts) => [...prevProducts, productToStore]);
        }
    };

    const removeProductById = (id) => {
        setProducts((prevProducts) => 
            prevProducts.filter(item => item.id !== id)
        );
    };

    const handleDecreaseQuantity = (id) => {
        setProducts((prevProducts) =>
            prevProducts.map(item => {
                if (item.id === id) {
                    return { ...item, quantity: item.quantity > 1 ? item.quantity - 1 : 1 };
                }
                return item;
            })
        );
    };

    const handleIncreaseQuantity = (id) => {
        setProducts((prevProducts) =>
            prevProducts.map(item => {
                if (item.id === id && item.quantity < item.stock) {
                    return { ...item, quantity: item.quantity + 1 };
                }
                return item;
            })
        );
    };

    const getTotalAmount = () => {
        return products.reduce((total, item) => {
            const itemPrice = item.priceWithDiscount || item.price;
            return total + (itemPrice * item.quantity);
        }, 0);
    };

    return (
        <ProductsContext.Provider value={{
            products,
            removeProductById,
            addProduct,
            handleDecreaseQuantity,
            handleIncreaseQuantity,
            selectedAttributes,
            handleAttributeChange,
            getTotalAmount
        }}>
            {children}
        </ProductsContext.Provider>
    );
};
