import { useNavigate } from "react-router-dom";
import defaultAvatar from "../../assets/images/profile/user-1.jpg";

export function Header() {

    const navigate = useNavigate();

    const userString = localStorage.getItem("user");
    let user;

    try {
        user = JSON.parse(userString ?? "");
    } catch (error) {
        user = undefined;
    }

    const handleLogout = () => {
        localStorage.clear();
        navigate("/auth/login");
    }


    return (
        <header className="app-header">
            <nav className="navbar navbar-expand-lg navbar-light">
                <div className="navbar-collapse justify-content-end px-0" id="navbarNav">
                    <ul className="navbar-nav flex-row ms-auto align-items-center justify-content-end">
                        <a>{user?.fullName ?? "User name"}</a>
                        <li className="nav-item dropdown">

                            {/* <a className="nav-link nav-icon-hover" href="javascript:void(0)" id="drop2" data-bs-toggle="dropdown"
                                aria-expanded="false">
                                <img src={user?.pictureUrl ?? defaultAvatar} alt="" width="35" height="35" className="rounded-circle" />
                            </a>
                            <div className="dropdown-menu dropdown-menu-end dropdown-menu-animate-up" aria-labelledby="drop2">
                                <div className="message-body">
                                    <a href="javascript:void(0)" className="d-flex align-items-center gap-2 dropdown-item">
                                        <i className="ti ti-user fs-6"></i>
                                        <p className="mb-0 fs-3">My Profile</p>
                                    </a>
                                    <a href="javascript:void(0)" className="d-flex align-items-center gap-2 dropdown-item">
                                        <i className="ti ti-mail fs-6"></i>
                                        <p className="mb-0 fs-3">My Account</p>
                                    </a>
                                    <a href="javascript:void(0)" className="d-flex align-items-center gap-2 dropdown-item">
                                        <i className="ti ti-list-check fs-6"></i>
                                        <p className="mb-0 fs-3">My Task</p>
                                    </a>
                                    <div className="w-100 px-2">
                                        <button type="button" onClick={handleLogout} className="btn btn-outline-primary w-100 mt-2 d-block">Logout</button>
                                    </div>
                                </div>
                            </div> */}

                            <a className="nav-link nav-icon-hover" id="drop2" data-bs-toggle="dropdown"
                                aria-expanded="false">
                                <img src={user?.pictureUrl ?? defaultAvatar} alt="" width="35" height="35" className="rounded-circle" />
                            </a>
                            <div className="dropdown-menu dropdown-menu-end dropdown-menu-animate-up" aria-labelledby="drop2">
                                <div className="message-body">
                                    <a href="#" className="d-flex align-items-center gap-2 dropdown-item">
                                        <i className="ti ti-user fs-6"></i>
                                        <p className="mb-0 fs-3">My Profile</p>
                                    </a>
                                    <a href="#" className="d-flex align-items-center gap-2 dropdown-item">
                                        <i className="ti ti-mail fs-6"></i>
                                        <p className="mb-0 fs-3">My Account</p>
                                    </a>
                                    <a href="#" className="d-flex align-items-center gap-2 dropdown-item">
                                        <i className="ti ti-list-check fs-6"></i>
                                        <p className="mb-0 fs-3">My Task</p>
                                    </a>
                                    <div className="w-100 px-2">
                                        <button type="button" onClick={handleLogout} className="btn btn-outline-primary w-100 mt-2 d-block">Logout</button>
                                    </div>
                                </div>
                            </div>
                        </li>
                    </ul>
                </div>
            </nav>
        </header>
    )
}