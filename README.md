# JobFinder

Website tuyển dụng xây dựng bằng ASP.NET Core MVC, Entity Framework Core và SQLite. Giao diện và dữ liệu mẫu đều dùng tiếng Việt.

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
