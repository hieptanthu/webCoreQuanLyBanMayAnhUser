using DAL;
using DataAccessLayer.Repository.Interfaces;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class SanPhamRepository : ISanPhamRepository
    {

        private IDatabaseHelper _dbHelper;
        public SanPhamRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        
        public SanPham GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "SanPhamSelect",
                     "@Id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanPham>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SanPham> sanBanChay()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "SanPhamBanChay");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanPham>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SanPham> sanBanHot()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "SanPhamHot");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanPham>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SanPham> sanPhamMoi()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "SanPhamNew");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanPham>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SanPham> Search(int pageIndex, int pageSize, out long total, string ten, int DanhMucId, int ThuongHieuId, int LoaiSanPham)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "ThuongHieuSearch",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@Ten", ten,
                     "@DanhMucId", DanhMucId,
                      "@ThuongHieuId", ThuongHieuId,
                       "@LoaiSanPham", LoaiSanPham
                    );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SanPham>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

     
    }
}
