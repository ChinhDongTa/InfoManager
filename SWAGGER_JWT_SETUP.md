# Swagger JWT Authentication - Hướng dẫn sử dụng

## 🔐 Thêm JWT Authentication vào Swagger UI

Bạn đã cấu hình thành công JWT Bearer token authentication trong Swagger UI.

## 📋 Các thay đổi đã thực hiện

### 1. **Program.cs**
- Thêm `using NSwag;` và `using NSwag.Generation.Processors.Security;`
- Loại bỏ cấu hình Swashbuckle (project sử dụng NSwag)
- Giữ lại cấu hình Swagger UI đơn giản

### 2. **DependencyInjection.cs**
- ✅ **Bật JWT Bearer Security Scheme**
  ```csharp
  configure.AddSecurity("Bearer", new NSwag.OpenApiSecurityScheme { ... })
  ```
- ✅ **Áp dụng cho tất cả endpoints**
  ```csharp
  configure.OperationProcessors.Add(
	  new AspNetCoreOperationSecurityScopeProcessor("Bearer"));
  ```

## 🚀 Cách sử dụng

### **Bước 1: Lấy JWT Token**

1. Mở Swagger UI tại `https://localhost:5001/api` (hoặc port tương ứng)
2. Tìm endpoint **POST /auth/login**
3. Nhập credentials:
   ```json
   {
	 "email": "user@example.com",
	 "password": "your-password"
   }
   ```
4. Nhấn **Execute**
5. Sao chép **`accessToken`** từ Response

### **Bước 2: Sử dụng Token trong Swagger**

1. Nhấn nút **🔓 Authorize** ở góc trên cùng bên phải (màu xanh)
2. Dán token vào ô **Authorization**:
   ```
   Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
   ```

   **Hoặc chỉ paste token mà không cần "Bearer " prefix** - Swagger sẽ tự thêm vào

3. Nhấn **Authorize** để lưu

### **Bước 3: Test Protected Endpoints**

1. Tất cả endpoints có `[Authorize]` sẽ nhận token tự động
2. Thực hiện request như bình thường
3. Token sẽ được gửi trong header:
   ```
   Authorization: Bearer <your-token>
   ```

## 🔍 Xác minh cấu hình

Swagger UI sẽ hiển thị:
- ✅ Nút **🔓 Authorize** (không lock)
- ✅ Security lock icon 🔒 trên endpoints có `[Authorize]`
- ✅ Input field để nhập token

## 📝 Ví dụ Protected Endpoint

```csharp
[Authorize]
[HttpGet("/api/profile")]
public async Task<IResult> GetProfile()
{
	// Endpoint này yêu cầu JWT token
	// Swagger sẽ tự động gửi token từ bước "Authorize"
}
```

## ⏰ Token Expiration

- Tokens có thời hạn sử dụng (mặc định: theo cấu hình)
- Nếu token hết hạn: Gọi lại `/auth/login` và update token

## 🎯 Tips & Tricks

1. **Xóa Token**: Nhấn **Authorize** lại → chọn **Logout** → **Authorize**
2. **Multiple Environments**: Swagger giữ token trong browser local storage
3. **CORS**: Đã cấu hình CORS cho tất cả origins
4. **Development Only**: Cấu hình JWT security chỉ dành để test development

## 🔗 Liên quan

- [JWT Authentication docs](https://learn.microsoft.com/aspnet/core/security/authentication/jwt-authn)
- [NSwag GitHub](https://github.com/RicoSuter/NSwag)
- [OpenAPI Security](https://spec.openapis.org/oas/v3.1.0#fixed-fields-29)

---

**Trạng thái:** ✅ Cấu hình hoàn tất - Sẵn sàng để test
