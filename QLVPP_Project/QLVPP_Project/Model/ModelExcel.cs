using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace QLVPP_Project.Model
{
    class ModelExcel
    {
        public void ExportExcel(DataTable data, string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("ExportSheet");

                // Đưa dữ liệu từ DataTable vào Excel
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    for (int j = 0; j < data.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1].Value = data.Rows[i][j].ToString();
                    }
                }

                // Thêm tiêu đề cột
                for (int i = 0; i < data.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1].Value = data.Columns[i].ColumnName;
                }

                // Lưu tệp Excel
                var fileInfo = new FileInfo(filePath);
                package.SaveAs(fileInfo);
            }
        }

        public DataTable ImportExcel(string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            DataTable data = new DataTable();
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var workSheet = package.Workbook.Worksheets[0];
                bool hasHeader = true;
                int rowCnt = workSheet.Dimension.Rows;
                int colCnt = workSheet.Dimension.Columns;

                if (hasHeader) 
                {
                    for (int col = 1; col <= colCnt; col++)
                    {
                        data.Columns.Add(workSheet.Cells[1, col].Text);
                    }
                }

                for (int row = (hasHeader ? 2 : 1); row <= rowCnt; row++)
                {
                    DataRow dataRow = data.NewRow();
                    for (int col = 1; col <= colCnt; col++)
                    {
                        dataRow[col - 1] = workSheet.Cells[row, col].Text;
                    }
                    data.Rows.Add(dataRow); 
                }


            }
            return data;
        }



    }
}
