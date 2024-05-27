import { BrowserRouter, Navigate, Route, Routes } from 'react-router-dom'
// import './App.css'
import { Login } from './screens/auth/login';
import "react-toastify/ReactToastify.css";
import PrivateRoute from './components/auth/PrivateRoute';
import { Dashboard } from './screens/dashboard';
import { Product } from './screens/product';

function App() {

  return (
    <>
      <BrowserRouter basename="/">
        {/* Body Wrapper */}
        <div className="page-wrapper" id="main-wrapper" data-layout="vertical" data-navbarbg="skin6" data-sidebartype="full"
          data-sidebar-position="fixed" data-header-position="fixed">
          <Routes>

            {/* Authentication */}
            <Route path="/auth" element={<PrivateRoute page="login" component={<Login />} />}>
              <Route index element={<Navigate to="login" replace />} />
              <Route path='login' element={<PrivateRoute page="login" component={<Login />} />} />
            </Route>

            {/* Admin pages */}
            <Route path="/" element={<Navigate to="/home" />} />
            <Route path="home" element={<PrivateRoute page="dashboard" component={<Dashboard />} />} />
            <Route path="books" element={<PrivateRoute page="books" component={<Product />} />} />

            <Route path='*' element={<Login />} />

          </Routes>

        </div>
      </BrowserRouter>
    </>
  )
}

export default App;
