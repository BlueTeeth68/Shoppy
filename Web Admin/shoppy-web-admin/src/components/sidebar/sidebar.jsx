import logo from "../../assets/images/logos/dark-logo.svg";

export function Sidebar() {

    return (
        <aside className="left-sidebar">
            {/* <!-- Sidebar scroll--> */}
            <div>
                <div className="brand-logo d-flex align-items-center justify-content-between">
                    <a href="./index.html" className="text-nowrap logo-img">
                        <img src={logo} width="180" alt="" />
                    </a>
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
                            <a className="sidebar-link active" href="./index.html" aria-expanded="false">
                                <span>
                                    <i className="ti ti-layout-dashboard"></i>
                                </span>
                                <span className="hide-menu">Dashboard</span>
                            </a>
                        </li>
                        <li className="nav-small-cap">
                            <i className="ti ti-dots nav-small-cap-icon fs-4"></i>
                            <span className="hide-menu">MANAGEMENT</span>
                        </li>
                        <li className="sidebar-item">
                            <a className="sidebar-link" href="./ui-buttons.html" aria-expanded="false">
                                <span>
                                    <i className="ti ti-article"></i>
                                </span>
                                <span className="hide-menu">User</span>
                            </a>
                        </li>
                        <li className="sidebar-item">
                            <a className="sidebar-link" href="./ui-buttons.html" aria-expanded="false">
                                <span>
                                    <i className="ti ti-article"></i>
                                </span>
                                <span className="hide-menu">Category</span>
                            </a>
                        </li>
                        <li className="sidebar-item">
                            <a className="sidebar-link" href="./ui-buttons.html" aria-expanded="false">
                                <span>
                                    <i className="ti ti-article"></i>
                                </span>
                                <span className="hide-menu">Book</span>
                            </a>
                        </li>
                    </ul>
                    
                </nav>
                {/* <!-- End Sidebar navigation --> */}
            </div>
            {/* <!-- End Sidebar scroll--> */}
        </aside>
    );
}