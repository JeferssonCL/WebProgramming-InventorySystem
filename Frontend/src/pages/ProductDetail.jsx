import { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import '../styles/pages/productDetail.css'

export function ProductDetail() {
  const { id } = useParams();
  const [product, setProduct] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchProductById = async () => {
      try {
        const response = await fetch(`http://localhost:5163/api/Product/${id}`);

        if (!response.ok) {
          throw new Error('Failed to fetch product details');
        }

        const data = await response.json();
        setProduct(data);
        setLoading(false);
      } catch (error) {
        setError(error.message);
        setLoading(false);
      }
    };


    console.log("ID: " + id)
    fetchProductById();
  }, [id]);

  if (loading) return <p>Loading product details...</p>;
  if (error) return <p>Error: {error}</p>;

  return (
    <div className="product-detail">
      <button onClick={() => navigate('/')} className='back-catalog-button'>Back to Catalog</button>
      <img
        src={product.images?.[0]?.url || 'https://via.placeholder.com/150'}
        alt={product.name}
        className="product-image"
      />
      <h2>{product.name}</h2>
      <p>{product.description}</p>
      <p className="product-price">Price: ${product.price}</p>
    </div>
  );
}