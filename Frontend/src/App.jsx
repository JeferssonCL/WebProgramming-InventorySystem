import { useEffect, useState } from 'react';
import { BrowserRouter as Router, Route, Routes, useNavigate, useParams } from 'react-router-dom';
import './App.css';

function ProductList({ onProductClick, page, totalPages, products, handleNextPage, handlePrevPage }) {
  return (
    <>
      <div className="product-grid">
        {products.map((product) => (
          <div
            className="product-card"
            key={product.id}
            onClick={() => onProductClick(product.id)} // Navegar al producto seleccionado
          >
            <img
              src={product.images?.[0]?.url || 'https://via.placeholder.com/150'}
              alt={product.name}
              className="product-image"
            />
            <div className="product-info">
              <h2>{product.name}</h2>
              <p>{product.description}</p>
              <p className="product-price">Price: ${product.price}</p>
            </div>
          </div>
        ))}
      </div>

      <div className="pagination">
        <button onClick={handlePrevPage} disabled={page === 1}>
          Previous
        </button>
        <span>
          Page {page} of {totalPages}
        </span>
        <button onClick={handleNextPage} disabled={page === totalPages}>
          Next
        </button>
      </div>
    </>
  );
}

function ProductDetail() {
  const { id } = useParams(); // Obtener el ID del producto desde la URL
  const [product, setProduct] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const navigate = useNavigate(); // Navegar de vuelta al catálogo

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

    fetchProductById();
  }, [id]);

  if (loading) return <p>Loading product details...</p>;
  if (error) return <p>Error: {error}</p>;

  return (
    <div className="product-detail">
      <button onClick={() => navigate('/')}>Back to Catalog</button>
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

function App() {
  const [products, setProducts] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [page, setPage] = useState(1);
  const [totalPages, setTotalPages] = useState(1);
  const limit = 10;

  const fetchProducts = async (currentPage) => {
    try {
      setLoading(true);
      const response = await fetch(
        `http://localhost:5163/api/product?page=${currentPage}&limit=${limit}`
      );

      if (!response.ok) {
        throw new Error('Failed to fetch products');
      }

      const data = await response.json();
      setProducts(data.data);
      setTotalPages(data.totalPages);
      setLoading(false);
    } catch (error) {
      setError(error.message);
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchProducts(page);
  }, [page]);

  const handleNextPage = () => {
    if (page < totalPages) setPage((prev) => prev + 1);
  };

  const handlePrevPage = () => {
    if (page > 1) setPage((prev) => prev - 1);
  };

  const navigate = useNavigate(); // Navegar a la vista de detalles del producto

  const handleProductClick = (id) => {
    navigate(`/product/${id}`); // Cambiar la URL al producto seleccionado
  };

  if (loading) return <p>Loading products...</p>;
  if (error) return <p>Error: {error}</p>;

  return (
    <div className="container">
      <h1>Product Catalog</h1>
      <Routes>
        <Route
          path="/"
          element={
            <ProductList
              onProductClick={handleProductClick}
              page={page}
              totalPages={totalPages}
              products={products}
              handleNextPage={handleNextPage}
              handlePrevPage={handlePrevPage}
            />
          }
        />
        <Route path="/product/:id" element={<ProductDetail />} />
      </Routes>
    </div>
  );
}

export default function RootApp() {
  return (
    <Router>
      <App />
    </Router>
  );
}
