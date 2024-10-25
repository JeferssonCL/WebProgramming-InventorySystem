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
        const attributesMap = getAttributesMap(newProduct.variants);
        const variantName = Object.keys(attributesMap).map(key => {
                                        const firstValue = attributesMap[key][0];
                                        return `${key}: ${firstValue.attributes.value}`;
                                    }).join(', ');
        const productToStore = {
            id: newProduct.id,
            name: newProduct.name,
            price: newProduct.price,
            image: newProduct.images,
            variant: variantName,
            attributesMap: attributesMap,
            quantity: 1
        };
        const productExists = products.find(item => item.id === productToStore.id);
        if (!productExists) {
            setProducts((prevProducts) => {
                return [...prevProducts, productToStore];
            });
        }
    };

    const getAttributesMap = (variants) => {
        const attributesMap = {};

        variants.forEach(variant => {
            variant.attributes.forEach(attribute => {
                if (attributesMap[attribute.name]) {
                    if (!attributesMap[attribute.name].includes(variant)) {
                        attributesMap[attribute.name].push(variant);
                    }
                } else {
                    attributesMap[attribute.name] = [variant];
                }
            });
        });

        return attributesMap;
    }

    const getAttributesSet = (id, attributesMap) =>  {
        return Object.keys(attributesMap).map(key => {
            return selectedAttributes[key+'-'+id];
        }).join(',');
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
        <ProductsContext.Provider value={{
            products,
            removeProductById,
            addProduct,
            handleDecreaseQuantity,
            handleIncreaseQuantity,
            selectedAttributes,
            handleAttributeChange,
            getAttributesSet
        }}>
            {children}
        </ProductsContext.Provider>
    );
};
