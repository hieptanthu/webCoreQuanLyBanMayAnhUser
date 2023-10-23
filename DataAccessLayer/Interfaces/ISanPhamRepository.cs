using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Interfaces
{
    public interface ISanPhamRepository
    {
        SanPham GetDatabyID(string id);
        List<SanPham> Search(int pageIndex, int pageSize, out long total, string ten, int DanhMucId , int ThuongHieuId,int LoaiSanPham);
        List<SanPham> sanBanChay();
        List<SanPham> sanBanHot();
        List<SanPham> sanPhamMoi();


    }
}
