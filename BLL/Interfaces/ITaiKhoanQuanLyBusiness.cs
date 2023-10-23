using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITaiKhoanQuanLyBusiness
    {
        TaiKhoanQuanLy Login(string userName, string password);
        bool Create(TaiKhoanQuanLy model);
        bool Update(TaiKhoanQuanLy model);
    }
}
