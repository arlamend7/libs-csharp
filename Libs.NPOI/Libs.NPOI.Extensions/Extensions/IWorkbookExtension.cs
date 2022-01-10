using Autoglass.Precificacao.DataTransfer.Utils;
using NPOI.SS.UserModel;
using System;
using System.Collections;

namespace Libs.NPOI.Extensions
{
    public static class IWorkbookExtension
    {
        public static ExecutationResult<TSucesso, TErro> Execute<TSucesso, TErro>(this IWorkbook wookbook, int sheetNumber, Func<IRow, ExecutationResult<TSucesso, TErro>, TSucesso> fucntion)
        {
            ExecutationResult<TSucesso, TErro> response = new ExecutationResult<TSucesso, TErro>();
            ISheet mainSheet = wookbook.GetSheetAt(sheetNumber);
            IEnumerator rows = mainSheet.GetRowEnumerator();
            IRow row;
            if (rows.MoveNext())
            {
                while (rows.MoveNext())
                {
                    row = (IRow)rows.Current;
                    try
                    {
                        TSucesso entidade = fucntion.Invoke(row, response);
                        response.Sucessos.Add(entidade);
                    }
                    catch (ExecutationException<TErro> ex)
                    {
                        ex.Linha = row.RowNum;
                        response.Erros.Add(ex);
                    }
                    catch (Exception ex)
                    {
                        response.Erros.Add(new ExecutationException<TErro>(row.RowNum, ex));
                    }
                }
            }
            return response;
        }
    }
}

