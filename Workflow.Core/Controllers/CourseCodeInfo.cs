using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System.Text;

namespace Workflow.Core.Controllers
{
    internal class CourseCodeInfo
    {
        public string Name { get; internal set; }
    }

    internal static class HSSFDataValidationExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workbook">excel表格</param>
        /// <param name="rangeName">数据源名称</param>
        /// <param name="SheetName">表格名称</param>
        /// <param name="startRow"></param>
        /// <param name="startCell"></param>
        /// <param name="sheetCount"></param>
        /// <returns></returns>
        public static HSSFDataValidation SetHSSFDataValidation(this IWorkbook workbook, string rangeName, string SheetName, int startRow, int startCell, string RefersToFormula, string constraintSetting = null)
        {
            int endRow = 65535;
            if (constraintSetting == null)
            {
                constraintSetting = rangeName;
            }
            ////设置隐藏域数据源
            if (workbook.GetName(rangeName) == null)
            {
                IName range = workbook.CreateName();
                range.RefersToFormula = RefersToFormula;// string.Format("{0}!$A$2:$A${1}", SheetName, sheetCount);
                range.NameName = rangeName;
            }
            ///将数据组装到表中
            CellRangeAddressList regions = new CellRangeAddressList(startRow, endRow, startCell, startCell);
            DVConstraint constraint = DVConstraint.CreateFormulaListConstraint(constraintSetting);
            HSSFDataValidation dataValidate = new HSSFDataValidation(regions, constraint);
            workbook.SetSheetHidden(workbook.GetSheetIndex(SheetName), SheetState.Hidden);
            return dataValidate;
        }
        /// <summary>
        /// 按照索引获取excel对应的列名
        /// </summary>
        /// <param name="str"></param>
        /// <param name="col"></param>
        public static void setExcelColumnName(this StringBuilder str, int col)
        {
            int tmp = col / 26;
            if (tmp > 26)
            {
                setExcelColumnName(str, tmp - 1);
            }
            else if (tmp > 0)
            {
                str.Append((char)(tmp + 64));
            }
            str.Append((char)(col % 26 + 65));
        }
    }
}