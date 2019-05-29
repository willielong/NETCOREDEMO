/*
 * 目的：研究NPOI操作EXCEL下拉菜单隐藏域功能及下拉框级联操作
 * 创建日期：2019.05.29
 * 创建人：
 * 修改人：
 * 修改日期：2019.05.29
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace Workflow.Core.Controllers
{
    public class ExcelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult DownloadExcel()
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("sheet1");

            IRow row = sheet.CreateRow(0);
            row.CreateCell(0).SetCellValue("姓名");
            row.CreateCell(1).SetCellValue("身份证号");
            row.CreateCell(2).SetCellValue("年级");
            row.CreateCell(3).SetCellValue("班级");
            row.CreateCell(4).SetCellValue("课程");
            row.CreateCell(5).SetCellValue("角色（班主任、单科老师）");


            IRow row1 = sheet.CreateRow(1);
            row1.CreateCell(0).SetCellValue("张峰");
            row1.CreateCell(1).SetCellValue("1111111111111");
            row1.CreateCell(2).SetCellValue("小学六年级");
            row1.CreateCell(3).SetCellValue("4班");
            row1.CreateCell(4).SetCellValue("语文");
            row1.CreateCell(5).SetCellValue("单科老师");

            var ic = workbook.CreateCellStyle();
            ic.DataFormat = HSSFDataFormat.GetBuiltinFormat("@");

            sheet.SetDefaultColumnStyle(1, ic);

            sheet.SetColumnWidth(1, 5000);
            sheet.SetColumnWidth(2, 4000);
            sheet.SetColumnWidth(3, 4000);
            sheet.SetColumnWidth(5, 24000);

            IList<CourseCodeInfo> list = new List<CourseCodeInfo>();
            for (int i = 1; i < 201; i++)
            {
                list.Add(new CourseCodeInfo() { Name = string.Format("课程{0}", i) });
            }
            var CourseSheetName = "Course";
            var RangeName = "dicRange";
            ISheet CourseSheet = workbook.CreateSheet(CourseSheetName);
            CourseSheet.CreateRow(0).CreateCell(0).SetCellValue("课程列表（用于生成课程下拉框，请勿修改）");
            for (var i = 0; i < list.Count; i++)
            {
                int r = i + 1;
                CourseSheet.CreateRow(r).CreateCell(0).SetCellValue(list[i].Name);
            }
            string refersul = string.Format("{0}!$A$2:$A${1}", CourseSheetName, list.Count);
            sheet.AddValidationData(workbook.SetHSSFDataValidation(RangeName, CourseSheetName, 1, 4, refersul));
            string sheetName = "TeacherSheet";
            ISheet teacherSheet = workbook.CreateSheet(sheetName);
            workbook.SetSheetHidden(workbook.GetSheetIndex(sheetName), SheetState.Hidden);
            for (int i = 0; i < list.Count; i++)
            {
                for (int w = 0; w < 10; w++)
                {
                    IRow ro;
                    if (teacherSheet.GetRow(w) == null)
                    {
                        ro = teacherSheet.CreateRow(w);
                    }
                    else
                    {
                        ro = teacherSheet.GetRow(w);
                    }
                    ICell cell;
                    if (ro.GetCell(i) == null)
                    {
                        cell = ro.CreateCell(i);
                    }
                    else
                    {
                        cell = ro.GetCell(i);
                    }
                    cell.SetCellValue(string.Format("{0}{1}", list[i].Name, w));
                }
                StringBuilder strColName = new StringBuilder();
                strColName.setExcelColumnName(i);
                refersul = string.Format("{0}!${1}$1:${1}${2}", sheetName, strColName, 10);
                strColName = new StringBuilder();
                strColName.setExcelColumnName(4);
                sheet.AddValidationData(workbook.SetHSSFDataValidation(list[i].Name, sheetName, 1, 0, refersul, string.Format("INDIRECT(${0}1)", strColName)));
            }
            System.IO.MemoryStream fs = new System.IO.MemoryStream();
            workbook.Write(fs);
            Response.ContentType = "application/vnd.ms-excel";
            Response.Headers.Add("Content-Disposition", new string[] { "attachment; filename=" + WebUtility.UrlEncode("教师授课模板.xls") });
            Response.Body.Write(fs.ToArray(), 0, fs.ToArray().Length);
            return new EmptyResult();

        }
    }
}