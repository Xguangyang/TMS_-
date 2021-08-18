using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Smart_logistics.Model;

namespace TMS_Smart_logistics.IRepository
{
   public interface ICircuitAdministration:IBase<Model.VIewLine>
    {
        List<Model.VIewLine> GetVIewLines(string CircuitName, string CircuitStartPlace, string CircuitEndPlace, string IsOutsource, string EmployeeName, string OutsourcingUnitName);
    }
}
