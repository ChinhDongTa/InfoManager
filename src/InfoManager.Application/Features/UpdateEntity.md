Client:
  - Load dữ liệu gốc(đã map sang Dto) → gán vào originalModel
  - Người dùng chỉnh sửa → updateModel
  - (Tùy chọn) Kiểm tra HasChanges()
  - Gửi Full model lên server (PUT)

Backend:
  - Nhận UpdateCommand (full)
  - Lấy entity từ DB
  - Dùng Extension so sánh từng field
  - Chỉ gán những field thực sự khác
  - Lưu entity
	
Quy tắc áp dụng:
  Loại field                        Extension dùng                      Ghi chú
string (Required)                HasValueAndIsDifferent            Bắt buộc có giá trị
string?                          IsDifferentFrom                   Cho phép set null
DateOnly?, int?...               IsDifferentFrom                   Cho phép set null
Nullable nhưng không được xóa    HasValueAndIsDifferent            Chỉ update khi có giá trị mới

Khi nào được phép dùng Partial Update / JsonPatch?
Chỉ khi thỏa một trong các điều kiện sau:
- Entity có ≥ 30 field
- Có field text rất lớn (> 3000–5000 ký tự) và thường xuyên chỉ sửa field nhỏ
- Có usecase update 1–2 field với tần suất cao
- Yêu cầu tuân thủ chuẩn HTTP PATCH nghiêm ngặt

