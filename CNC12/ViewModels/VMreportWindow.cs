using CNC12.Model;
using Microsoft.Win32;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
namespace CNC12.ViewModels
{
    public class VMreportWindow : BaseVM
    {
        // tạo 1 list dạng ObservableCollection ListData 
        // được binding với listview có name là LisData trong xaml
        private ObservableCollection<Chart_Model> _ListData;  
        public ObservableCollection<Chart_Model> ListData
        {
            get => _ListData;
            set
            {
                _ListData = value;
                OnPropertyChanged();
            }
        }

        // khai báo 2 command tương tự 2 nút ấn Import, Export 
        // trong ReportWindow
        public ICommand ImportCommand { get; set; }
        public ICommand ExportCommand { get; set; }
        public VMreportWindow()
        {
            // thực thi cho 2 command trên khi được gọi
            ImportCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { LoadDataFromSQL(); });
            ExportCommand = new RelayCommand<object>((p) => { return true; }, (p) => { ExportDataToExcel(); });
        }
        
        #region Load data từ SQL
        void LoadDataFromSQL()
        {
            // gọi biến List data có kiểu như dưới đây
            ListData = new ObservableCollection<Chart_Model>();

            // gọi biến var của EvenMangerCNCs
            var objectList = DataProvider.Ins.DB.EventManagerCNC1;
            int i = 1;
            try 
            {
                // check null cho ListData
                if (ListData == null)
                    return;
                else
                {
                    // duyệt từng phần tử của objectlist
                    foreach (var item in objectList)
                    {
                        // khai báo các biến tương ứng với các cột trong table 
                        // và sau đó gán giá trị cho chúng
                        var Id = DataProvider.Ins.DB.EventManagerCNC1.Where(p => p.Id == item.Id);
                        var IdHienTrangMayCNC = DataProvider.Ins.DB.EventManagerCNC1.Where(p => p.IdHienTrangMayCNC == item.IdHienTrangMayCNC);
                        var IdHienTrangCuaMayCNC = DataProvider.Ins.DB.EventManagerCNC1.Where(p => p.IdHienTrangCuaMayCNC == item.IdHienTrangCuaMayCNC);
                        var ThoiDiem = DataProvider.Ins.DB.EventManagerCNC1.Where(p => p.ThoiDiem == item.ThoiDiem);
                        if (item != null)
                        {
                            // nếu item ko bị null thì thực thi bên trong :
                            // khai báo một list kiểu Chart_Model ( 1 list rỗng có cấu trúc tương tự bảng )
                            // sau đó gán giá trị cho từng giá trị của list chart_Model.
                            Chart_Model chart_Model = new Chart_Model();
                            chart_Model.Id = i;
                            chart_Model.IdHienTrangMayCNC = item.IdHienTrangMayCNC;
                            chart_Model.IdHienTrangCuaMayCNC = item.IdHienTrangCuaMayCNC;
                            chart_Model.ThoiDiem = item.ThoiDiem;

                            // cho hiển thị chart_Model lên list view ListData
                            ListData.Add(chart_Model);
                            i++;
                        }
                    }
                }         
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                GC.Collect();
                
            }
        }
        #endregion

        #region Export từ Form ra file Excel
        void ExportDataToExcel()
        {
            string filePath = "";
            // tạo SaveFileDialog để lưu file excel
            SaveFileDialog dialog = new SaveFileDialog();

            // chỉ lọc ra các file có định dạng Excel
            dialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";

            // Nếu mở file và chọn nơi lưu file thành công sẽ lưu đường dẫn lại dùng
            if (dialog.ShowDialog() == true)
            {
                filePath = dialog.FileName;
            }
            // nếu đường dẫn null hoặc rỗng thì báo không hợp lệ và return hàm
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
                return;
            }

            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage p = new ExcelPackage())
                {
                    if (p == null)
                    {
                        return;
                    }
                    // đặt tên người tạo file
                    p.Workbook.Properties.Author = "RAV";

                    // đặt tiêu đề cho file
                    p.Workbook.Properties.Title = "Báo cáo thống kê quá trình chạy máy" + " " + DateTime.UtcNow.ToString();

                    //Tạo một sheet để làm việc trên đó
                    p.Workbook.Worksheets.Add("Report" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString());

                    // lấy sheet vừa add ra để thao tác
                    ExcelWorksheet ws = p.Workbook.Worksheets[0];  // BUG***

                    // đặt tên cho sheet
                    ws.Name = DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();

                    // fontsize mặc định cho cả sheet
                    ws.Cells.Style.Font.Size = 11;

                    // font family mặc định cho cả sheet
                    ws.Cells.Style.Font.Name = "Calibri";

                    // Tạo danh sách các column header
                    string[] arrColumnHeader = { "ID", "Hiện trạng máy CNC",
                                                    "Hiện trạng của máy CNC","Thời Điểm" };

                    // lấy ra số lượng cột cần dùng dựa vào số lượng header
                    var countColHeader = arrColumnHeader.Count();

                    // merge các column lại từ column 1 đến số column header
                    // gán giá trị cho cell vừa merge là Thống kê thông tni User Kteam
                    ws.Cells[1, 1].Value = "Thống kê thông số hoạt động máy CNC" + " " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    ws.Cells[1, 1, 1, countColHeader].Merge = true;
                    // in đậm
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                    // căn giữa
                    ws.Cells[1, 1, 1, countColHeader].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    int colIndex = 1;
                    int rowIndex = 2;

                    //tạo các header từ column header đã tạo từ bên trên
                    foreach (var item in arrColumnHeader)
                    {
                        var cell = ws.Cells[rowIndex, colIndex];
                        ws.Cells[rowIndex, colIndex].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        //set màu thành gray
                        var fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                        //căn chỉnh các border
                        var border = cell.Style.Border;
                        border.Bottom.Style =
                        border.Top.Style =
                        border.Left.Style =
                        border.Right.Style = ExcelBorderStyle.Thin;

                        //gán giá trị
                        cell.Value = item;
                        colIndex++;
                    }
                    if (ListData == null)
                        return;
                    // với mỗi item trong danh sách ListData sẽ ghi trên 1 dòng
                    foreach (var item in ListData)    
                    {
                        // bắt đầu ghi từ cột 1. Excel bắt đầu từ 1 không phải từ 0
                        colIndex = 1;

                        // rowIndex tương ứng từng dòng dữ liệu
                        rowIndex++;

                        // Gán giá trị cho từng cell                
                        // Lưu ý phải .ToShortDateString để dữ liệu khi in ra Excel là ngày như ta vẫn thấy.Nếu không sẽ ra tổng số :v
                        ws.Cells[rowIndex, colIndex].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        ws.Cells[rowIndex, colIndex++].Value = item.Id;

                        ws.Cells[rowIndex, colIndex].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        ws.Cells[rowIndex, colIndex++].Value = item.IdHienTrangMayCNC;

                        ws.Cells[rowIndex, colIndex].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        ws.Cells[rowIndex, colIndex++].Value = item.IdHienTrangCuaMayCNC;

                        ws.Cells[rowIndex, colIndex].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        ws.Cells[rowIndex, colIndex++].Value = item.ThoiDiem.ToString();

                    }
                    //p.Save(filePath);

                    //Lưu file lại
                    Byte[] bin = p.GetAsByteArray();
                    File.WriteAllBytes(filePath, bin);
                }
                MessageBox.Show("Xuất file excel thành công!");
            }
            catch (Exception EE)
            {
                MessageBox.Show("Xuất excel thất bại, hãy thử lại!" + " Error code: " + EE.Message);
            }
            finally
            {
                GC.Collect();
            }
        }
        #endregion
    }
}
