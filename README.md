# JobFinder

Website tuyển dụng xây dựng bằng ASP.NET Core MVC, Entity Framework Core và SQLite. Giao diện và dữ liệu mẫu đều dùng tiếng Việt.

## Thông tin sinh viên thực hiện

- Họ tên: Kiều Đức Anh
- MSSV: 170124533
- Lớp: DK24TTC5

## 1. Giới thiệu

JobFinder là website tuyển dụng được xây dựng nhằm cung cấp một cổng tra cứu việc làm và quản trị dữ liệu tuyển dụng theo hướng gọn nhẹ, dễ triển khai. Hệ thống được phát triển trên nền tảng ASP.NET Core MVC, sử dụng Entity Framework Core để làm việc với dữ liệu và SQLite để lưu trữ cục bộ, phù hợp với các mô hình demo, đồ án, môi trường nội bộ hoặc triển khai quy mô nhỏ và vừa.

## 2. Mục tiêu

- Đối với người dùng: Hỗ trợ tìm kiếm việc làm nhanh chóng, xem danh sách và chi tiết tuyển dụng với giao diện trực quan, dễ sử dụng.
- Đối với quản trị: Cho phép đăng nhập quản trị, khởi tạo lại dữ liệu mẫu và quản lý trạng thái hệ thống phục vụ demo hoặc vận hành.
- Về kỹ thuật: Áp dụng mô hình MVC để tổ chức mã nguồn rõ ràng, dễ bảo trì, đồng thời khai thác SQLite như một giải pháp cơ sở dữ liệu nhẹ, dễ đóng gói và triển khai.

## 3. Công nghệ sử dụng

- Ngôn ngữ: C#
- Framework: ASP.NET Core MVC
- ORM: Entity Framework Core
- Cơ sở dữ liệu: SQLite
- Giao diện: Razor View, HTML, CSS, JavaScript
- Triển khai: Docker, Render

## 4. Các tính năng chính

- Xác thực người dùng với đăng nhập, đăng xuất và phân quyền theo vai trò.
- Hiển thị danh sách việc làm tại trang chủ và hỗ trợ tìm kiếm theo từ khóa.
- Xem chi tiết công việc với các thông tin như mô tả, yêu cầu và công ty tuyển dụng.
- Khởi tạo dữ liệu mẫu tiếng Việt để phục vụ demo và kiểm thử.
- Tài khoản `Admin` có thể kích hoạt cơ chế làm mới và nạp lại dữ liệu mẫu khi đăng nhập.
- Hỗ trợ đóng gói và deploy bằng Docker lên môi trường Render.

## 5. Cấu trúc thư mục dự án

- `JobFinder/Controllers`: Chứa các controller xử lý request và điều phối luồng.
- `JobFinder/Models`: Chứa các model biểu diễn dữ liệu nghiệp vụ.
- `JobFinder/ViewModels`: Chứa các view model phục vụ hiển thị và nhập liệu.
- `JobFinder/Views`: Chứa các giao diện Razor View.
- `JobFinder/Data`: Chứa `DbContext`, logic khởi tạo dữ liệu và file SQLite.
- `JobFinder/wwwroot`: Chứa tài nguyên tĩnh như CSS, JavaScript, hình ảnh.
- `JobFinder/Program.cs`: Điểm khởi chạy và cấu hình ứng dụng.
- `JobFinder/appsettings.json`: Cấu hình ứng dụng và chuỗi kết nối.

## Yêu cầu môi trường

- .NET 6 SDK

## Cách chạy

1. Mở terminal tại thư mục gốc dự án.
2. Chạy:

```bash
dotnet restore
dotnet run --project JobFinder/JobFinder.csproj
```

3. Mở trình duyệt tại địa chỉ được in ra từ `dotnet run`.

## Tài khoản mẫu

- Admin: `admin` / `Admin@123`
- Người dùng: `ungvien` / `User@123`

## Ghi chú

- SQLite dùng file `JobFinder/Data/JobFinder.db`.
- Dữ liệu mẫu được khởi tạo khi ứng dụng khởi động nếu database trống.
- Khi đăng nhập bằng tài khoản Admin, hệ thống sẽ reset và nạp lại dữ liệu mẫu theo yêu cầu đề bài.

## Deploy lên Render bằng Docker

Repo đã có sẵn:

- `Dockerfile`
- `.dockerignore`
- `render.yaml`

### Cách deploy

1. Push code lên GitHub.
2. Trên Render, tạo service mới từ repo hoặc dùng Blueprint với `render.yaml`.
3. Nếu dùng Blueprint, Render sẽ tự đọc:
   - Dockerfile tại thư mục gốc
   - biến môi trường `ASPNETCORE_ENVIRONMENT=Production`
   - chuỗi kết nối SQLite `ConnectionStrings__DefaultConnection=Data Source=/app/Data/JobFinder.db`
   - persistent disk mount tại `/app/Data`

### Lưu ý quan trọng

- Nếu không mount persistent disk, file SQLite sẽ mất sau mỗi lần redeploy/restart container.
- Ứng dụng đã cấu hình nhận cổng động từ biến `PORT` của Render.
