
# HỆ THỐNG UPLOAD VÀ PHÁT VIDEO
Lớp lý thuyết môn lập trình mạng căn bản NT106.P13

GVHD: Lê Minh Khánh Hội

Nhóm 16

Thành viên :
 1. 23521564 - Trần Lê Uyên Thy - [moeruuu](https://github.com/moeruuu) - **Nhóm trưởng** 
 2. 23520407 - Lê Nguyễn Phương Giang - [imzang](https://github.com/imzang)
 3. 23520222 - Nguyễn Xuân Đan - [dan02045](https://github.com/dan02045)
 4. 23520718 - Huỳnh Quốc Khánh - [khsnhelovorld](https://github.com/khsnhelovorld)

## Mô tả
Ứng dụng dùng để hiện thực đồ án ***Hệ thống upload và phát video*** được xây dựng theo mô hình client-server. Sản phẩm được áp dụng các kiến thức đã học trong môn Lập trình mạng căn bản bao gồm: giao tiếp API, sockets, điều khiển đa luồng, bảo mật dữ liệu, ... Điểm nổi bật của ứng dụng là giao diện thân thiện, dễ nhìn và tính năng xem coop cho phép nhiều user cùng xem video với nhau. 

Server folder: API_Server

Client folder: UITFLIX

Link database: 

    mongodb+srv://tester:10dltm@clusteruyenthy.wttnb.mongodb.net/

***Chú ý quan trọng:** Ứng dụng được xây dựng bằng Winform ở mức scale 125%. Để tránh việc các form ứng dụng có thể bị thay đổi tỉ lệ so với sản phẩm của nhóm, nên chỉnh setting về mức scale 125% trước khi build chương trình.*
### Hướng dẫn kết nối database MongoDB
 1. Tải MongoDB Compass: [Link download](https://www.mongodb.com/try/download/compass)
 2. Chạy file MongoDB Compass đã tải. Tạo tài khoản và đăng nhập
 3. Tại giao diện chính của MongoDB Compass:
	 - Windows: Bấm vào dấu cộng ở phần **CONNECTIONS** để tạo kết nối mới
	 -	macOS: *(Trực tiếp có phần **New Connection*)**
 4.  Copy link database ở trên và pass vào ô URI. Nhấn **Save & Connect**
 <img src="https://i.imgur.com/0wqSniY.png" width="800" />

*Lưu ý: Sau khi tạo kết nối thành công, khi chạy chương trình ở những lần sau không cần kết nối đến database thêm nữa.*

## Tổng quan về ứng dụng
### Kiến trúc hệ thống
<img src="https://i.imgur.com/tBPSnvm.png" width="900" />

### Các tính năng chính của ứng dụng
*Lưu ý: Chạy web api server trước khi chạy client winform!*

Client được chia làm 2 đối tượng chính:
 - User (Người dùng thông thường) có thể thực hiện các tác vụ cơ bản như upload, tải và xem video.
 
<img src="https://i.imgur.com/nzqQETk.png" width="700" />

 - Admin (Quản trị viên) có thể quản lý các dịch vụ liên quan đến user và các video được đăng tải.

<img src="https://i.imgur.com/avTrXLk.png" width="700" />

### Các công nghệ được sử dụng
 1. IDE: Visual Studio 2022
 2. Ngôn ngữ code: C#
 3. Framework: Window Forms, .NET Core
 4. COM: AxWindowsMediaPlayer
 5. Thư viện: SingalR, Newtonsoft Json
 6. Network stack: Websocket (TCP), RESTful API HTTP request, SMTP
 7. Database: MongoDB
 8. Version control: Github
