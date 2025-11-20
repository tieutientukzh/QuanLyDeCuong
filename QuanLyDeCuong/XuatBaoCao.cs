using Excel = Microsoft.Office.Interop.Excel;


namespace QuanLyDeCuong
{
    public class XuatBaoCao
    {
        public void BaoCao(DataGridView dgvReport)
        {
            Excel.Application exApp = null;
            Excel.Workbook exBook = null;
            Excel.Worksheet exSheet = null;

            try
            {
                // Khởi tạo Excel
                exApp = new Excel.Application();
                exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                exSheet = (Excel.Worksheet)exBook.Worksheets[1];

                // 1. Định dạng tiêu đề chung
                // Hàng 1: Tên hệ thống
                Excel.Range qldc = (Excel.Range)exSheet.Cells[1, 1];
                qldc.Font.Size = 12;
                qldc.Font.Bold = true;
                qldc.Font.Color = Color.Blue;
                qldc.Value = "HỆ THỐNG QUẢN LÝ ĐỀ CƯƠNG MÔN HỌC";
                // Merge vài cột để nhìn đẹp hơn
                exSheet.Range["A1:D1"].Merge();

                // Hàng 2: Người thực hiện báo cáo
                Excel.Range nguoiBaoCao = (Excel.Range)exSheet.Cells[2, 1];
                nguoiBaoCao.Font.Size = 11;
                nguoiBaoCao.Font.Bold = false;
                nguoiBaoCao.Value = "Người xuất báo cáo: " + (CurrentUser.FullName ?? "Admin");
                exSheet.Range["A2:D2"].Merge();

                // Hàng 4: Tiêu đề báo cáo
                Excel.Range header = (Excel.Range)exSheet.Cells[4, 2];
                exSheet.Range["A4:D4"].Merge();
                exSheet.Range["A4"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                header = exSheet.Range["A4"]; // Trỏ lại vào ô đã merge
                header.Font.Size = 14;
                header.Font.Bold = true;
                header.Font.Color = Color.Red;
                header.Value = "BÁO CÁO THỐNG KÊ SỐ LIỆU";

                // 2. Định dạng tiêu đề cột (Bắt đầu từ dòng 6)
                int headerRow = 6;
                // Cột STT
                exSheet.Cells[headerRow, 1] = "STT";
                ((Excel.Range)exSheet.Cells[headerRow, 1]).Font.Bold = true;
                ((Excel.Range)exSheet.Cells[headerRow, 1]).Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                // Các cột dữ liệu lấy từ DataGridView
                for (int i = 0; i < dgvReport.Columns.Count; i++)
                {
                    // Cột Excel bắt đầu từ 2 (vì 1 là STT)
                    Excel.Range colHeader = (Excel.Range)exSheet.Cells[headerRow, i + 2];
                    colHeader.Value = dgvReport.Columns[i].HeaderText;
                    colHeader.Font.Bold = true;
                    colHeader.ColumnWidth = 25;
                    colHeader.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    colHeader.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                }

                // 3. Đổ dữ liệu
                for (int i = 0; i < dgvReport.Rows.Count; i++)
                {
                    // Bỏ qua dòng trống cuối cùng của DataGridView (nếu có)
                    if (dgvReport.Rows[i].IsNewRow) continue;

                    int currentRow = headerRow + 1 + i;

                    // Ghi STT
                    Excel.Range cellSTT = (Excel.Range)exSheet.Cells[currentRow, 1];
                    cellSTT.Value = i + 1;
                    cellSTT.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    cellSTT.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    // Ghi dữ liệu các cột
                    for (int j = 0; j < dgvReport.Columns.Count; j++)
                    {
                        Excel.Range cellData = (Excel.Range)exSheet.Cells[currentRow, j + 2];
                        if (dgvReport.Rows[i].Cells[j].Value != null)
                        {
                            cellData.Value = dgvReport.Rows[i].Cells[j].Value.ToString();
                        }
                        cellData.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    }
                }

                // Đặt tên sheet
                exSheet.Name = "BaoCao";

                // 4. Lưu file
                exBook.Activate();
                SaveFileDialog dlgSave = new SaveFileDialog();
                dlgSave.Filter = "Excel Document(*.xlsx)|*.xlsx|Excel 97-2003(*.xls)|*.xls";
                dlgSave.AddExtension = true;
                dlgSave.DefaultExt = ".xlsx";

                if (dlgSave.ShowDialog() == DialogResult.OK)
                {
                    exBook.SaveAs(dlgSave.FileName);
                    MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    exApp.Visible = true;
                }
                else
                {
                    exBook.Close(false);
                    exApp.Quit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi xuất Excel: " + ex.Message + "\n\nHãy đảm bảo máy tính đã cài Microsoft Office.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Dọn dẹp nếu lỗi
                if (exBook != null) exBook.Close(false);
                if (exApp != null) exApp.Quit();
            }
            finally
            {
                // Giải phóng tài nguyên COM để tránh ứng dụng Excel chạy ngầm
                if (exSheet != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(exSheet);
                if (exBook != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(exBook);
                if (exApp != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(exApp);
            }
        }
    }
}
