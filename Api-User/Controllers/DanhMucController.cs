using BLL.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MODEL;

namespace Api.BanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucController : ControllerBase
    {
        private IDanhMucBusiness _Bll;
        public DanhMucController(IDanhMucBusiness Bll)
        {
            _Bll = Bll;
        }
        [Route("get-DanhMucAll")]
        [HttpGet]
        public List<DanhMuc> GetDatabyAll()
        {
            return _Bll.GetDatabyAll();
        }
      
    }
}
