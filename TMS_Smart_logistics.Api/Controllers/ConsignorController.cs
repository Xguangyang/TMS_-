using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_Smart_logistics.IRepository;
using TMS_Smart_logistics.Model;


namespace TMS_Smart_logistics.Api.Controllers
{
    /// <summary>
    /// 货主管理
    /// </summary>
    [Route("api/[controller]/[action]")]

    public class ConsignorController : Controller
    {
        public IConsignor consignor;
        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="_consignor"></param>
        public ConsignorController(IConsignor _consignor)
        {
            consignor = _consignor;
        }
        /// <summary>
        /// 货主管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetConsignor(string EmployeeName="", string EmployeePhone="", string DrivingLicenceTime="")
        {
            return Ok(consignor.GetViewConsignors(EmployeeName,EmployeePhone,DrivingLicenceTime));
        }
        /// <summary>
        /// 货主管理添加
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddConsignor(ViewConsignor obj)
        {
            return Ok(consignor.AddConsignor(obj));
        }
        /// <summary>
        /// 货主管理删除
        /// </summary>
        /// <param name="ConsignorID"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DelConsignor(string ConsignorID)
        {
            return Ok(consignor.DelConsignor(ConsignorID));
        }

    }
}
