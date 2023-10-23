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
    public class TaiKhoanQuanLyRepository : ITaiKhoanQuanLyRepository
    {
        private IDatabaseHelper _dbHelper;
        public TaiKhoanQuanLyRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public bool Create(TaiKhoanQuanLy model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "TaiKhoanQuanLyUpdate",
                     "@userName", model.userName,
                "@password", model.password,
                "@Email", model.Email,
                "@soDienThoai", model.soDienThoai
                );
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }



            
        }


        public TaiKhoanQuanLy Login(string username, string password)
        {

            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "[sp_login_Quanly]",
                     "@username", username.Trim(),
                "@password", password.Trim()
                );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TaiKhoanQuanLy>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
        

        public bool Update(TaiKhoanQuanLy model)
        {

            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "TaiKhoanQuanLyUpdate",
                     "@Id", model.userName,
                "@password", model.password,
                "@Email", model.Email,
                "@soDienThoai", model.soDienThoai
                );
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    }
}
