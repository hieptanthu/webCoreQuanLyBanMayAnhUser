using DAL.Repository.Interfaces;
using DataAccessLayer;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ThuongHieuRepository : IthuongHieuRepository
    {
        private IDatabaseHelper _dbHelper;
        public ThuongHieuRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<ThuongHieu> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "[ThuongHieuSelectAll]"
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ThuongHieu>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
