using BLL.Interfaces;
using DAL.Repository.Interfaces;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DanhMucBusiness : IDanhMucBusiness
    {
        private  IDanhMucRepository _res;
        public DanhMucBusiness(IDanhMucRepository res)
        {
            _res = res;
        }
        

        public List<DanhMuc> GetDatabyAll()
        {
          return _res.GetDatabyAll();
        }
    }
}
