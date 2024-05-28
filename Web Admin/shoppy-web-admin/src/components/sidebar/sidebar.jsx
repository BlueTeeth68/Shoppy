import { Link } from "react-router-dom";
import { Book, CreateNewFolder, PeopleAlt } from "@mui/icons-material";

export function Sidebar() {

    return (
        <aside className="left-sidebar">
            {/* <!-- Sidebar scroll--> */}
            <div>
                <div className="brand-logo d-flex align-items-center justify-content-between">
                    {/* <a href="./index.html" className="text-nowrap logo-img">
                        <img src={logo} width="180" alt="" />
                    </a> */}
                    <h1 className="text-nowrap logo-img text-center d-block py-3 w-100">
                        <p className="text-uppercase text-primary fw-bold mb-0">Shoppy</p>
                    </h1>
                    <div className="close-btn d-xl-none d-block sidebartoggler cursor-pointer" id="sidebarCollapse">
                        <i className="ti ti-x fs-8"></i>
                    </div>
                </div>
                {/* <!-- Sidebar navigation--> */}
                <nav className="sidebar-nav scroll-sidebar" data-simplebar="">
                    <ul id="sidebarnav">
                        <li className="nav-small-cap">
                            <i className="ti ti-dots nav-small-cap-icon fs-4"></i>
                            <span className="hide-menu">Home</span>
                        </li>
                        <li className="sidebar-item">
                            <Link to={"/home"} className="sidebar-link active" aria-expanded="false">
                                <span>
                                    <i className="ti ti-layout-dashboard"></i>
                                </span>
                                <span className="hide-menu">Dashboard</span>
                            </Link>
                        </li>
                        <li className="nav-small-cap">
                            <i className="ti ti-dots nav-small-cap-icon fs-4"></i>
                            <span className="hide-menu">MANAGEMENT</span>
                        </li>
                        <li className="sidebar-item">
                            <Link to={"/user"} className="sidebar-link" aria-expanded="false">
                                <PeopleAlt />
                                <span className="hide-menu">User</span>
                            </Link>
                        </li>
                        <li className="sidebar-item">
                            <Link to={"/category"} className="sidebar-link" aria-expanded="false">
                                <CreateNewFolder />
                                <span className="hide-menu">Category</span>
                            </Link>
                        </li>
                        <li className="sidebar-item">
                            <Link to={"/books"} className="sidebar-link" aria-expanded="false">
                                <Book />
                                <span className="hide-menu">Book</span>
                            </Link>
                        </li>
                    </ul>

                </nav>
                {/* <!-- End Sidebar navigation --> */}
            </div>
            {/* <!-- End Sidebar scroll--> */}
        </aside>
    );
}