import Header from './Component/Header'
import Footer from './Component/Footer'
import './App.css'
import LibraryDashboard from './Component/Library/LibraryDashboard'
import { Route, Routes } from 'react-router-dom'
import NotFound from './NotFound'
import { DataProvider } from './DataContext'

function App() {
  return (
    <DataProvider>
      <Header/>
      <Routes>
        <Route path="/" element={<LibraryDashboard />} />
        <Route path="*" element={<NotFound />}/>
      </Routes>
      <Footer/>
    </DataProvider>
  )
}

export default App
