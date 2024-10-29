import { useContext, useEffect, useState } from "react";
import { useParams } from "react-router";
import { ProductsContext } from "../context/ProductsContext";
import { ProductCardWithinId } from "../components/ProductCardWithinId";
import '../styles/components/combo-details.css'

export function ComboDetail() {
  const { id } = useParams();
  const [combo, setCombo] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  const { addProduct } = useContext(ProductsContext);

  useEffect(() => {
    const fetchComboById = async () => {
      try {
        const response = await fetch(`http://localhost:5163/api/Combo/${id}`);

        if (!response.ok) {
          throw new Error("Failed to fetch product details");
        }

        const data = await response.json();
        console.log(data);
        setCombo(data);
        setLoading(false);
      } catch (error) {
        setError(error.message);
        setLoading(false);
      }
    };

    fetchComboById();
  }, [id]);

  if (loading) return <p>Loading product details...</p>;
  if (error) return <p>Error: {error}</p>;

  return (
    <div className="combo-detail-page">
      <div className="combo-info-section">
        <img src={combo.comboImageDto.url} alt={combo.comboImageDto.altText} className="combo-image" />
        <div className="info-section">
          <h2 className="combo-detail-name">{combo.name}</h2>
          <p className="combo-detail-description">{combo.description}</p>
          <div className="combo-detail-price">
            <p className="currency-price">$us</p>
            <p className="price">{combo.price}</p>
          </div>
          <button className="add-to-cart" onClick={() => addProduct(combo)}>
            Add to cart
          </button>
        </div>
      </div>
      <div className="combo-products">
            {combo.products.map((product, index) => (
              <ProductCardWithinId
                key={index}
                name={product.name}
                price={product.price}
                brand={product.brand}
              />
            ))}
          </div>
    </div>
  );
}
