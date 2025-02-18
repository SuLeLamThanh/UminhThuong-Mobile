# Sử dụng image SDK để xây dựng ứng dụng
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Đặt thư mục làm việc trong container
WORKDIR /app

# Sao chép các tệp .csproj của từng dự án vào thư mục tương ứng trong container
COPY ./src/ResearchDatabase.API/*.csproj ./ResearchDatabase.API/
COPY ./src/ResearchDatabase.Infrastructure/*.csproj ./ResearchDatabase.Infrastructure/
COPY ./src/ResearchDatabase.Domain/*.csproj ./ResearchDatabase.Domain/

# Chạy dotnet restore trong thư mục chứa dự án API
WORKDIR /app/ResearchDatabase.API
RUN dotnet restore

# Sao chép toàn bộ mã nguồn vào container
COPY ./src/ResearchDatabase.API/ ./ResearchDatabase.API/
COPY ./src/ResearchDatabase.Infrastructure/ ./ResearchDatabase.Infrastructure/
COPY ./src/ResearchDatabase.Domain/ ./ResearchDatabase.Domain/

# Build và publish ứng dụng
RUN dotnet publish ./ResearchDatabase.API/ResearchDatabase.API.csproj -c Release -o /app/out

# Kiểm tra xem thư mục /app/out có tồn tại không
RUN ls -al /app/out

# Dùng image ASP.NET để chạy ứng dụng
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "ResearchDatabase.API.dll"]  