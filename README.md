# BÁO CÁO BÀI TẬP / ĐỒ ÁN

## THÔNG TIN SINH VIÊN
- **Họ và tên:** Phạm Tuấn Thành
- **Mã số sinh viên:** 24810320264
- **Tên môn học:** Lập trình C# / Windows Forms
- **Tên bài tập:** BT5 - Bảng điều khiển Quản lý Đơn giao hàng

---

## MÔ TẢ BÀI TẬP
Dashboard quản lý đơn giao hàng phức tạp với layout đa tầng.

**Controls sử dụng:** SplitContainer, DataGridView, StatusStrip, Timer, ErrorProvider

**Tính năng:**
- SplitContainer chia 2 cột: trái (thông tin khách hàng) / phải (bảng hàng hóa)
- DataGridView cho phép nhập/sửa trực tiếp: Tên hàng, Số lượng, Trọng lượng, Đơn giá
- Cột Thành tiền tự tính (Số lượng × Đơn giá)
- StatusStrip hiển thị: Đồng hồ realtime + Tổng SL + Tổng KL + Tổng tiền
- ErrorProvider cảnh báo khi Số lượng hoặc Trọng lượng ≤ 0
- **F2** = thêm dòng mới | **Delete** = xóa dòng đang chọn

---

## KẾT QUẢ THỰC HÀNH

### 1. Ảnh màn hình Giao diện chính
![Giao diện chính](./screenshots/main_ui.png)

### 2. Ảnh màn hình Chức năng thực thi / Kết quả
![Thực thi chức năng](./screenshots/execution_result.png)

### 3. Ảnh màn hình Kiểm tra lỗi (Validation)
![Kiểm tra lỗi](./screenshots/validation_error.png)

---

## CÁCH CHẠY
- Yêu cầu: .NET 10.0 SDK + Windows
- Mở file `DeliveryDashboard.sln` bằng Visual Studio 2022/2026
- Nhấn **F5** để chạy
