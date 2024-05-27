// lưu đường dẫn các trang chưa xác thực như login, register. Khi người dùng 
// đã đăng nhập thì không được truy cập lại các trang này
export const UnauthenticatedPages = [
    "login"
];

//Lưu đường dẫn các trang public. Mọi người dùng đều có thể truy cập 
//(cả đã đăng nhập và chưa đăng nhập)
export const PublicPages = [];

//Lưu đường dẫn các trang error
export const ErrorPages = ["not-found"];

//Lưu đường dẫn các trang mà admin được truy cập
export const AdminPages = ["home", "dashboard", "books"];
