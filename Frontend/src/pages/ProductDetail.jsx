import { useContext, useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import "../styles/pages/productDetail.css";
import { Images } from "../components/ProductDetails/Images";
import { ProductsContext } from "../context/ProductsContext";

export function ProductDetail() {
  const { id } = useParams();
  const [product, setProduct] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  const { addProduct } = useContext(ProductsContext)

  useEffect(() => {
    const fetchProductById = async () => {
      try {
        const response = await fetch(`http://localhost:5163/api/Product/${id}`);

        if (!response.ok) {
          throw new Error("Failed to fetch product details");
        }

        const data = await response.json();
        setProduct(data);
        setLoading(false);
      } catch (error) {
        setError(error.message);
        setLoading(false);
      }
    };

    fetchProductById();
  }, [id]);

  if (loading) return <p>Loading product details...</p>;
  if (error) return <p>Error: {error}</p>;

  return (
    <div className="product-detail-page">
      <div className="product-info-section">
        <Images images={product.images} />
        <div className="info-section">
          <h2 className="product-detail-name">{product.name}</h2>
          <p className="product-detail-description">{product.description}</p>
          <div className="product-detail-price">
            <p className="currency-price">$us</p>
            <p className="price">{product.price}</p>
          </div>
          <table className="more-info-table">
            <tbody>
            <tr>
              <td className="name-info">Alcohol percentage</td>
              <td>{product.alcoholPercentage} %</td>
            </tr>
            <tr>
              <td className="name-info">Brand</td>
              <td>{product.brand}</td>
            </tr>
            <tr>
              <td className="name-info">Volume</td>
              <td>{product.volume} ml</td>
            </tr>
            </tbody>
          </table>
          <button className="add-to-cart" onClick={() => addProduct(product)}>Add to cart</button>
        </div>
      </div>
    </div>
  );
}
