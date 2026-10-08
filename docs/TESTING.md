# Kiểm thử — Bài 5 — Bảng điều khiển Quản lý Đơn giao hàng

Ngày chạy: 08/10/2026. Môi trường: Windows, .NET SDK 10.0.401.

Đã chạy 20/20 kiểm tra đạt với vi-VN. Chạy thêm 20/20 đạt với en-US.

Các kiểm tra chạy trên form thật: hiển thị control, gọi handler, nhập/sửa dữ liệu và xử lý MessageBox. Hộp thoại xác nhận được chương trình kiểm tra trả lời Yes/No tự động. Bộ kiểm tra được chạy ngoài repo để không trộn công cụ audit vào bài nộp.

| Kiểm tra đã chạy | Kết quả |
|---|---|
| `sample_total` | PASS |
| `sample_weight_10_5` | PASS |
| `tabs` | PASS |
| `edited_total` | PASS |
| `edited_weight_15` | PASS |
| `error_next_to_editor` | PASS |
| `zero_qty_error` | PASS |
| `invalid_other_row_retained` | PASS |
| `nonnumeric_qty` | PASS |
| `negative_weight` | PASS |
| `nonnumeric_weight` | PASS |
| `all_errors_clear` | PASS |
| `overflow_handled` | PASS |
| `clock_ticks` | PASS |
| `F2` | PASS |
| `delete` | PASS |
| `customer_delete_keeps_rows` | PASS |
| `minimum_layout` | PASS |
| `maximize_grid` | PASS |
| `timer_disposed` | PASS |

Kết quả chi tiết: [test-results.json](./test-results.json).

## Kiểm tra thêm trước khi nộp

- [ ] Mở solution bằng Visual Studio 2026, chọn MainForm.cs → Shift+F7 và kiểm tra kéo thả trong Toolbox.
- [ ] Chạy F5, đi qua các bước ở README bằng bàn phím/chuột.
- [ ] Kiểm tra giao diện ở DPI/cỡ màn hình đang dùng.
- [x] Đối chiếu đủ 3 ảnh screenshot với kết quả chạy thực tế ngày 08/10/2026.
