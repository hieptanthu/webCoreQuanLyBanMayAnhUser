using DataAccessLayer.Repository.Interfaces;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DonHangRepository : IDonHangRepository
    {

        private IDatabaseHelper _dbHelper;
        public DonHangRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public bool Create(DonHang model)
        {
            string msgError = "";
            try
            {
                var xxx = model.list_json_chitiethoadon != null ? MessageConvert.SerializeObject(model.list_json_chitiethoadon) : null;

                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "DonHangInsrt",
                "@@idDiaChi", model.idDiaChi,

                "@list_json_chitiethoadon", model.list_json_chitiethoadon != null ? MessageConvert.SerializeObject(model.list_json_chitiethoadon) : null);

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

        public bool Delete(string id)
        {
            DonHang dh = new DonHang();
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "DonHangDelete",
                     "@Id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);

                dh = dt.ConvertTo<DonHang>().FirstOrDefault();
                return true;
               
            }
            
            
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DonHang GetDatabyID(string id)
        {
            DonHang dh = new DonHang();
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "DonHangSelect",
                     "@Id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);

                dh = dt.ConvertTo<DonHang>().FirstOrDefault();

                return dh;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public List<DonHang> Search(int pageIndex, int pageSize, out long total, string TaiKhoanId, string NgayTao, string NgayThanhToan, string TrangThai, string SanPhamId)
        {
            string msgError = "";
            List<DonHang> dh = new List<DonHang>();
            List<ChiTietDonHang> ChiTiet = new List<ChiTietDonHang>();
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "DonHangSearch",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@TaiKhoanId", TaiKhoanId,
                    "@NgayTao", NgayTao,
                    "@NgayThanhToan", NgayThanhToan,
                    "@trangThai", TrangThai,
                    "@SanPhamId", SanPhamId);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];


                dh = dt.ConvertTo<DonHang>().ToList();



                return dh;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
