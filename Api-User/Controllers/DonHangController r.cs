using BLL.Interfaces;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MODEL;

namespace Api_admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonHangController_r : ControllerBase
    {


        private IDonHangBusiness _Bll;
        public DonHangController_r(IDonHangBusiness Bll)
        {
            _Bll = Bll;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public DonHang GetDatabyID(string id)
        {
            return _Bll.GetDatabyID(id);
        }
        

        [Route("delete-DonHang/{id}")]
        [HttpDelete]
        public bool Delete([FromBody] string id)
        {

            return _Bll.Delete(id);
        }


       
        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string TaiKhoanId = "";
                if (formData.Keys.Contains("TaiKhoanId") && !string.IsNullOrEmpty(Convert.ToString(formData["TaiKhoanId"]))) { TaiKhoanId = Convert.ToString(formData["TaiKhoanId"]); }
                string NgayTao = "" ;
                if (formData.Keys.Contains("NgayTao") && !string.IsNullOrEmpty(Convert.ToString(formData["NgayTao"]))) { NgayTao = Convert.ToString(formData["NgayTao"]); }
                string NgayThanhToan = "";
                if (formData.Keys.Contains("NgayThanhToan") && !string.IsNullOrEmpty(Convert.ToString(formData["NgayThanhToan"]))) { NgayThanhToan = Convert.ToString(formData["NgayThanhToan"]); }
                string TrangThai = "";
                if (formData.Keys.Contains("TrangThai") && !string.IsNullOrEmpty(Convert.ToString(formData["TrangThai"]))) { TrangThai = Convert.ToString(formData["TrangThai"]); }
                string SanPhamId = "";
                if (formData.Keys.Contains("SanPhamId") && !string.IsNullOrEmpty(Convert.ToString(formData["SanPhamId"]))) { SanPhamId = Convert.ToString(formData["SanPhamId"]); }
                long total = 0;
                var data = _Bll.Search(page, pageSize, out total, TaiKhoanId, NgayTao, NgayThanhToan, TrangThai, SanPhamId);
                return Ok(
                    new
                    {
                        TotalItems = total,
                        Data = data,
                        Page = page,
                        PageSize = pageSize
                    }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

