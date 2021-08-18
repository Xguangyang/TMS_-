using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_Smart_logistics.Model;
using TMS_Smart_logistics.IRepository;

namespace TMS_Smart_logistics.Api.Controllers
{
    /// <summary>
    /// 线路管理
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class LIneController : Controller
    {
        public ICircuitAdministration circuitAdministration;
        public LIneController (ICircuitAdministration _circuitAdministration)
        {
            circuitAdministration = _circuitAdministration;
        }
        /// <summary>
        /// 线路管理显示
        /// </summary>
        /// <param name="CircuitName"></param>
        /// <param name="CircuitStartPlace"></param>
        /// <param name="CircuitEndPlace"></param>
        /// <param name="IsOutsource"></param>
        /// <param name="EmployeeName"></param>
        /// <param name="OutsourcingUnitName"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetLine(string CircuitName="", string CircuitStartPlace="", string CircuitEndPlace="", string IsOutsource="", string EmployeeName="", string OutsourcingUnitName="")
        {
            return Ok(circuitAdministration.GetVIewLines(CircuitName,CircuitStartPlace,CircuitEndPlace,IsOutsource,EmployeeName,OutsourcingUnitName));
        }
    }
}
