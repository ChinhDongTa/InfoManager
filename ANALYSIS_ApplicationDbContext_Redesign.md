# ApplicationDbContext - Phân tích lại cấu trúc

## Vấn đề hiện tại

### 1. **Farm liên kết với Family (Sai)**
```csharp
public required string FamilyId { get; set; }
```
- Farm là phần của SFMS (Kinh doanh)
- Family là phần Personal (Cá nhân)
- **Mâu thuẫn**: Không nên liên kết trực tiếp

### 2. **Mối quan hệ hợp lý**
```
User (ApplicationUser)
  ├─ Personal
  │   └─ Family (Gia đình cá nhân)
  │       └─ FamilyMember (Thành viên gia đình)
  │           └─ HREmployee (Nhân viên + 1-1)
  │               └─ JobAssignment (Công việc cụ thể)
  │
  └─ Business (SFMS)
	  └─ Farm (Nông trại - thuộc User, không thuộc Family)
		  └─ Field, Sensor, Equipment, Tasks...
```

## Sửa đổi cần thiết

### 1. **Xóa FamilyId từ Farm**
- Farm sẽ liên kết với User (CreatedBy)
- Farm là tài sản của User

### 2. **HREmployee liên kết đúng**
- HREmployee → FamilyMember (1-to-1) ✓
- HREmployee → Farm (Many-to-1) ✓
- Nhân viên từ Family có thể làm việc cho Farm

### 3. **Phân tách DbContext**
```
Personal/Family DbSets
├── Family & related
├── FamilyMember
├── User-level data
└── Filtered by UserId & FamilyId

SFMS DbSets
├── Farm & business entities
├── HR (JobPosition, HREmployee, EmployeeAccount, JobAssignment)
├── Agriculture (Crop, Field, etc.)
└── Filtered by Farm ownership
```

## Sơ đồ quan hệ mới

```
ApplicationUser (1)
  ├─ UserProfile (1-to-1)
  │
  ├─ Family (1-to-many) [Personal - Optional]
  │   ├─ FamilyMember
  │   │   └─ HREmployee (1-to-1) [HR Profile]
  │   │       ├─ JobAssignment → JobPosition
  │   │       ├─ EmployeeAccount (1-to-1) [Login Account]
  │   │       ├─ EmployeeAttendance
  │   │       └─ Payroll
  │   │
  │   └─ FamilyEvent, FamilyRelation, etc.
  │
  └─ Farm (1-to-many) [Business - SFMS]
	  ├─ Field → Sensor, SoilAnalysis, Tasks
	  ├─ Equipment → Maintenance
	  ├─ Crop, CropPlanting → Harvest, Yield
	  ├─ Infestation → Pest/Disease
	  ├─ Payroll (Farm payroll separate from personal)
	  └─ FarmExpense, FarmRevenue, CostAnalysis
```

## Thay đổi code

### Farm.cs - Xóa FamilyId
```csharp
// Trước:
public required string FamilyId { get; set; }

// Sau:
// Không cần - Farm sẽ thuộc User (via CreatedBy)
// Nếu muốn ghi chú, có thể lưu:
public string? OwnerUserId { get; set; }  // Optional, default = CreatedBy
```

### HREmployee.cs - Giữ liên kết đúng
```csharp
// Đã đúng:
public required string FamilyMemberId { get; set; }  // Link to Family side
public required string FarmId { get; set; }          // Link to Business side
```

## Query Filtering

```csharp
// Personal/Family - Filter by User
.HasQueryFilter(f => f.CreatedBy == _currentUserId)

// SFMS/Farm - Filter by User's farms
.HasQueryFilter(f => 
	_farmsOwnedByUser.Contains(f.Id))

// HREmployee - Filter by User's farms
.HasQueryFilter(e => 
	_farmsOwnedByUser.Contains(e.FarmId))
```

## Kết luận

**Personal/Family**: Phần tiện ích cá nhân của User
- Family quản lý thành viên gia đình
- HREmployee là "tư cách" của FamilyMember khi làm việc

**SFMS/Business**: Phần kinh doanh của User
- Farm là hoạt động kinh doanh
- HREmployee là nhân sự cho Farm
- Nhân viên từ Family có thể được assign vào Job tại Farm

**Không nên**: Farm.FamilyId - vì Farm không phải của gia đình mà của User
