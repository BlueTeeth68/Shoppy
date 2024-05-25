import { BrowserRouter, Navigate, Route, Routes } from 'react-router-dom'
// import './App.css'
import { Dashboard } from './screens/dashboard';
import { Login } from './screens/auth/login';
import "react-toastify/ReactToastify.css";
import PrivateRoute from './components/auth/PrivateRoute';

function App() {

  return (
    <>
      <BrowserRouter basename="/">
        {/* Body Wrapper */}
        <div className="page-wrapper" id="main-wrapper" data-layout="vertical" data-navbarbg="skin6" data-sidebartype="full"
          data-sidebar-position="fixed" data-header-position="fixed">
          <Routes>
            <Route path="/" element={<Navigate to="/home" />} />
            <Route path="home" element={<PrivateRoute page="dashboard" element={<Dashboard />} />} />

            {/* Authentication */}
            <Route path="/auth" element={<PrivateRoute page="login" component={<Login />} />}>
              <Route index element={<Navigate to="login" replace />} />
              <Route path='login' element={<PrivateRoute page="login" component={<Login />} />} />
            </Route>

            <Route path='*' element={<Login />}/>

          </Routes>

        </div>
      </BrowserRouter>
    </>
  )
}

export default App;
