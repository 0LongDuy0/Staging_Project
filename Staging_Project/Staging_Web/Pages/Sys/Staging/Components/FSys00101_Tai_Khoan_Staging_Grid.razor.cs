using Staging_Controller.Sys;
using Staging_Entity.Sys;

namespace Staging_Web.Pages.Sys.Staging.Components
{
    public partial class FSys00101_Tai_Khoan_Staging_Grid
    {
        public List<E_Sys_Tai_Khoan> v_arrData = new();

        protected override void OnInitialized()
        {
            C_Sys_Tai_Khoan v_objCtrData = new  C_Sys_Tai_Khoan();
            v_arrData = v_objCtrData.List_Sys_Tai_Khoan();
        }

        private void Delete_Data(int p_iAuto_ID)
        {
            C_Sys_Tai_Khoan v_objCtrData = new();

            v_objCtrData.FSys00101_Delete_Sys_Tai_Khoan(p_iAuto_ID, "Admin", "FSys00101_Tai_Khoan_Staging_Grid");

            OnInitialized();
        }

        protected override void Reload_Data()
        {
            OnInitialized();
        }
    }
}
