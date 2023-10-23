using BLL.Interfaces;
using DAL.Repository.Interfaces;
using DataAccessLayer.Repository.Interfaces;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ThuongHieuBusiness : IThuongHieuBusiness
    {


        private IthuongHieuRepository _res;
        public ThuongHieuBusiness(IthuongHieuRepository res)
        {
            _res = res;
        }

        public List<ThuongHieu> GetAll()
        {
          return _res.GetAll();
        }
    }
}
