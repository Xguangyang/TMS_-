using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Smart_logistics.Model
{
    /// <summary>
    /// 货主合同跟踪表
    /// </summary>
    public class OwnerOfCargoVehicleTailAfter
    {
        public int VehicleTailAfterID { get; set; }//跟踪管理ID
        public Nullable<int> OwnerOfCargoContractID { get; set; }  //货主合同外键ID
        public Nullable<int> CircuitAdministrationID { get; set; } //线路管理外键ID
        public Nullable<int> AbnormalAlarm { get; set; }           //异常警报
        public Nullable<int> OwnerOfCargoRunStatus { get; set; }   //运输状态（运输中、未起运、已完成）
        public Nullable<int> VehicleTailAfterStatus { get; set; }  //跟踪状态
    }
}


