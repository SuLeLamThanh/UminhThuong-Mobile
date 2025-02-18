# Hướng dẫn sử dụng dự án

## Mô tả dự án

Dự án này là một ứng dụng đa tầng sử dụng Docker Compose để quản lý các container cho cả backend và frontend. Backend được xây dựng bằng ASP.NET API với kiến trúc microservices, trong khi frontend được phát triển bằng Flutter cho Android, sử dụng Dart.

Yêu cầu

Trước khi bắt đầu, đảm bảo bạn đã cài đặt các công cụ sau:

Docker và Docker Compose.

.NET SDK (phiên bản tương thích với dự án).

Flutter SDK.

Một IDE hỗ trợ phát triển Flutter (Android Studio hoặc VS Code).


### Bước 1: Thiết lập backend trong Visual Studio Code

1. Cài đặt các thư viện phụ thuộc bằng lệnh:

```bash
dotnet restore
```

2. Kiểm tra file cấu hình `appsettings.json` để đảm bảo thông tin kết nối cơ sở dữ liệu chính xác.
3. Chạy từng service bằng lệnh để tạo database mẫu vào SQS Server.:

```bash
dotnet ef migrations add AddSeedData
dotnet ef database update

```
### Bước 2: Cài đặt và chạy Docker Compose

1. Chỉnh sửa file `docker-compose.yml` về tài khoản sa của SQL Server và các port.
2. Xây dựng và chạy toàn bộ ứng dụng bằng lệnh:

```bash
docker-compose up --build
```

### Bước 3: Chạy ứng dụng Flutter


1. Kết nối thiết bị Android hoặc khởi động trình giả lập.
2. Cài đặt phụ thuộc Flutter bằng lệnh:

```bash
flutter pub get
```

4. Chạy ứng dụng bằng lệnh:

```bash
flutter run
```

### Bước 4: Kiểm tra kết nối backend

Backend sẽ chạy trên các cổng được định nghĩa trong `docker-compose.yml`. Đảm bảo các dịch vụ backend sẵn sàng trước khi chạy frontend.



## Ghi chú

- Đảm bảo tất cả các biến môi trường được cấu hình chính xác trong `docker-compose.yml`.
- Sửa đổi các cổng hoặc thông tin đăng nhập nếu cần thiết.
- Khi triển khai lên môi trường sản xuất, cập nhật cấu hình bảo mật và tối ưu hoá hiệu năng.

## Xử lý sự cố

- **Lỗi kết nối cơ sở dữ liệu**: Đảm bảo SQL Server đang chạy và thông tin đăng nhập chính xác.
- **Flutter không chạy được**: Kiểm tra xem tất cả các phụ thuộc đã được cài đặt bằng `flutter pub get`.



