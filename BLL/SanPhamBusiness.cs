using BLL.Interfaces;
using DataAccessLayer.Repository.Interfaces;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SanPhamBusiness : ISanPhamBusiness
    {
        private readonly ISanPhamRepository _res;

        public SanPhamBusiness (ISanPhamRepository res) 
        {
            _res = res;
        }
        public SanPham GetDatabyID(string id)
        {
           return _res.GetDatabyID(id);
        }

        public List<SanPham> sanBanChay()
        {
            return _res.sanBanChay();
        }

        public List<SanPham> sanBanHot()
        {
            return _res.sanBanHot();
        }

        public List<SanPham> sanPhamMoi()
        {
            return _res.sanPhamMoi();
        }

        public List<SanPham> Search(int pageIndex, int pageSize, out long total, string ten, int DanhMucId, int ThuongHieuId, int LoaiSanPham)
        {
            return _res.Search(pageIndex, pageSize, out total, ten, DanhMucId, ThuongHieuId, LoaiSanPham );
        }
    }
}
