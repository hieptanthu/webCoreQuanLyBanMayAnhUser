using DAL.Repository.Interfaces;
using DataAccessLayer;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class DanhMucRepository : IDanhMucRepository
    {
        private IDatabaseHelper _dbHelper;
        public DanhMucRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        
        public List<DanhMuc> GetDatabyAll()
        {

            string msgError = "";
            try
            {
                //gọi danh mục con để tìm được câc cấp
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "DanhMucSelect"
                    );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DanhMuc>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

       

       
    }
}
