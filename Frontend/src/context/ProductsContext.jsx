import React, {createContext, useEffect, useState} from 'react';

export const ProductsContext = createContext();

export const ProductsProvider = ({ children }) => {
    const [products, setProducts] = useState(() => {
        const savedProducts = localStorage.getItem('products');
        return savedProducts ? JSON.parse(savedProducts) : [];
    });

    // This will trigger whenever `products` changes
    useEffect(() => {
        localStorage.setItem('products', JSON.stringify(products));
    }, [products]);

    const addProduct = (newProduct) => {
        const variantName = searchBasicVariantCombination(newProduct.variants);
        const productToStore = {
            id: newProduct.id,
            name: newProduct.name,
            price: newProduct.price,
            image: newProduct.images,
            variant: variantName,
            quantity: 1
        };
        const productExists = products.find(item => item.id === productToStore.id);
        if (!productExists) {
            setProducts((prevProducts) => {
                return [...prevProducts, productToStore];
            });
        }
    };

    const searchBasicVariantCombination = (variants) => {
        const attributesMap = {};

        variants.forEach(variant => {
            variant.attributes.forEach(attribute => {
                if (attributesMap[attribute.name]) {
                    if (!attributesMap[attribute.name].includes(attribute.value)) {
                        attributesMap[attribute.name].push(attribute.value);
                    }
                } else {
                    attributesMap[attribute.name] = [attribute.value];
                }
            });
        });

        return Object.keys(attributesMap).map(key => {
            const firstValue = attributesMap[key][0];
            return `${key}: ${firstValue}`;
        }).join(', ');
    }

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
                if (item.id === id) {
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
