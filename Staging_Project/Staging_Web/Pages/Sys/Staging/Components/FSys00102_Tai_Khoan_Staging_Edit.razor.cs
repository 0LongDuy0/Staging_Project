using Staging_Controller.Sys;
using Staging_Entity.Sys;
using Staging_Utility;
using System.Text;

namespace Staging_Web.Pages.Sys.Staging.Components
{
    public partial class FSys00102_Tai_Khoan_Staging_Edit
    {
		private E_Sys_Tai_Khoan m_objData = new();
		protected override void OnInitialized()
		{
			C_Sys_Tai_Khoan v_objCtrData = new();
			m_objData = v_objCtrData.Get_Sys_Tai_Khoan_By_ID(r_iFBase_Edit_Auto_ID);

			if (m_objData == null)
				m_objData = new E_Sys_Tai_Khoan();
			else
			{
				r_bFBase_Edit_Update = true;
			}	

        }

		private async Task Save_Data()
		{
			r_objFBase_Edit_Call_Back_Event.Message_ID = (int)U_EModal_Result.Close_And_Reload_Data;

			try
			{
				if (r_bFBase_Edit_Update == true)
					Update_Data();
				else
					Add_Data();
			}
			catch (Exception ex)
			{
				r_strError = Set_Error_MessageBox(ex.Message);
				r_objFBase_Edit_Call_Back_Event.Message_ID = (int)U_EModal_Result.Exception;
			}

			await OnClose.InvokeAsync(r_objFBase_Edit_Call_Back_Event);
		}

		private void Add_Data()
		{
			C_Sys_Tai_Khoan v_objCtrData = new();
			m_objData.Last_Updated_By = "Admin";
			m_objData.Last_Updated_By_Function = "FSys00102_Tai_Khoan_Staging_Edit_Add";

			m_objData.Auto_ID = v_objCtrData.FSys00102_Insert_Sys_Tai_Khoan(m_objData);
		}

		private void Update_Data()
		{
			C_Sys_Tai_Khoan v_objCtrData = new();
			m_objData.Last_Updated_By = "Admin";
			m_objData.Last_Updated_By_Function = "FSys00102_Tai_Khoan_Staging_Edit_Update";
			v_objCtrData.FSys00102_Update_Sys_Tai_Khoan(m_objData);
        }

        public static string Set_Error_MessageBox(string p_strMessage)
        {
            StringBuilder v_sb = new StringBuilder();

            v_sb.AppendLine("<div class=\"alert alert-danger alert-styled-left\">");
            v_sb.AppendLine("<span>" + p_strMessage + "</span>");
            v_sb.AppendLine("</div>");

            return v_sb.ToString();
        }
    }
}
