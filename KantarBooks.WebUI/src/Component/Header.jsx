import { Link } from "react-router-dom";

const Header = () => {
  return (
    <div>
      <nav>
        <Link to="/">Home</Link> | <Link to="/about">404 - Not Found</Link>
      </nav>
    </div>
  )
}

export default Header;