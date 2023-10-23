using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MODEL;

namespace Api.BanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThuongHieuController : ControllerBase
    {
        private IThuongHieuBusiness _Bll;
        public ThuongHieuController(IThuongHieuBusiness Bll)
        {
            _Bll = Bll;
        }
        [Route("get_thuongHieu_all")]
        [HttpGet]
        public List<ThuongHieu> GetThuongHieuALL()
        {
            return _Bll.GetAll();
        }
       
        
    }
}
