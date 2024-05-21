import { BrowserRouter, Navigate, Route, Routes } from 'react-router-dom'
// import './App.css'
import { Index } from './screens/dashboard';

function App() {

  return (
    <>
      <BrowserRouter basename="/">
        {/* Body Wrapper */}
        <div className="page-wrapper" id="main-wrapper" data-layout="vertical" data-navbarbg="skin6" data-sidebartype="full"
          data-sidebar-position="fixed" data-header-position="fixed">
          <Routes>
            <Route path="/" element={<Navigate to="/home" />} />
            <Route path="home" element={<Index />} />
          </Routes>

        </div>
      </BrowserRouter>
    </>
  )
}

export default App;
