import { useState, useEffect, useContext } from "react";
import { ProductCard } from "../components/ProductCard";
import { ProductsContext } from "../context/ProductsContext";
import axios from 'axios';
import '../styles/pages/home.css';
import PropTypes from "prop-types";

export function Home() {
  const [productList, setProductList] = useState([]);

  const { addProduct } = useContext(ProductsContext);

  useEffect(() => {
    const apiUrl = "http://localhost:5163/api/product?page=1&limit=20";

    const fetchProducts = async () => {
      const response = await axios.get(apiUrl);
      setProductList(response.data.data);
    };

    fetchProducts();
  }, []);

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
              onAddToCart={() => addProduct(product)}
            />
          ))
        )
      }
    </div>
  );
}

Home.propTypes = {
}