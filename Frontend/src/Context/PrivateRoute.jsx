import { Navigate, useLocation } from 'react-router-dom';
import { useAuth } from './AuthContext';

export const PrivateRoute = ({ children, allowedRoutes = [] }) => {
  const { user } = useAuth();
  const location = useLocation();
  
  const publicRoutes = ['/', '/login', '/signup', '/product'];
  
  const isPublicRoute = publicRoutes.some(route => 
    location.pathname === route || 
    (route === '/product' && location.pathname.startsWith('/product/'))
  );

  if (!user && !isPublicRoute) {
    return <Navigate to="/login" state={{ from: location }} replace />;
  }

  if (allowedRoutes.length > 0 && user) {
    const hasAccess = allowedRoutes.some(route => 
      location.pathname.startsWith(route)
    );

    if (!hasAccess) {
      return <Navigate to="/" replace />;
    }
  }
  
  return children;
};
