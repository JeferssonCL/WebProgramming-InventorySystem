import React, {createContext, useEffect, useState} from 'react';

export const ProductsContext = createContext();

export const ProductsProvider = ({ children }) => {
    const [products, setProducts] = useState(() => {
        const savedProducts = localStorage.getItem('products');
        return savedProducts ? JSON.parse(savedProducts) : [];
    });

    const [selectedAttributes, setSelectedAttributes] = useState({});

    const handleAttributeChange = (attributeName, value) => {
        const prevState = selectedAttributes;
        prevState[attributeName] = value
        setSelectedAttributes(prevState);
        console.log(prevState);
    };

    // This will trigger whenever `products` changes
    useEffect(() => {
        localStorage.setItem('products', JSON.stringify(products));
    }, [products]);

    const addProduct = (newProduct) => {
        const productToStore = {
            id: newProduct.id,
            name: newProduct.name,
            price: newProduct.price,
            image: newProduct.image,
            quantity: 1,
            stock : newProduct.stock
        };
        const productExists = products.find(item => item.id === productToStore.id);
        if (!productExists) {
            if (productToStore.stock <= 0) {
                return;
            }
            setProducts((prevProducts) => {
                return [...prevProducts, productToStore];
            });
        }
    };

    const removeProductById = (id) => {
        setProducts((prevProducts) => {
            return prevProducts.filter(item => item.id !== id);
        });
    };

    const handleDecreaseQuantity = (id) => {
        setProducts((prevProducts) =>
            prevProducts
                .map(item => {
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

    return (
        <ProductsContext.Provider value={{
            products,
            removeProductById,
            addProduct,
            handleDecreaseQuantity,
            handleIncreaseQuantity,
            selectedAttributes,
            handleAttributeChange,
        }}>
            {children}
        </ProductsContext.Provider>
    );
};
