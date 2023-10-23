using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Interfaces
{
    public interface IDonHangRepository
    {
        DonHang GetDatabyID(string id);
        bool Create(DonHang model);
        bool Delete(string id);
        List<DonHang> Search(int pageIndex, int pageSize, out long total, string TaiKhoanId, string NgayTao, string NgayThanhToan, string TrangThai,
            string SanPhamId);
    }
}
