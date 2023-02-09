using Staging_DataLayer;
using Staging_Entity.Sys;
using Staging_Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staging_Controller.Sys
{
    public class C_Sys_Tai_Khoan
    {
        #region Default Tài Khoản
        public List<E_Sys_Tai_Khoan> List_Sys_Tai_Khoan()
        {
            List<E_Sys_Tai_Khoan> v_arrRes = new List<E_Sys_Tai_Khoan>();
            DataTable v_dt = new DataTable();

            try
            {
                D_SqlHelper.FillDataTable(U_Config.Project_Staging_Conn_String, v_dt, "sp_sel_List_Sys_Tai_Khoan");

                foreach (DataRow v_row in v_dt.Rows)
                {
                    E_Sys_Tai_Khoan v_objRes = U_Utility.Map_Row_To_Entity<E_Sys_Tai_Khoan>(v_row);
                    v_arrRes.Add(v_objRes);
                }
            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                v_dt.Dispose();
            }

            return v_arrRes;
        }

        public E_Sys_Tai_Khoan Get_Sys_Tai_Khoan_By_ID(long p_iID)
        {
            E_Sys_Tai_Khoan v_objRes = null;
            DataTable v_dt = new DataTable();

            try
            {
                D_SqlHelper.FillDataTable(U_Config.Project_Staging_Conn_String, v_dt, "sp_sel_Get_Sys_Tai_Khoan_By_ID", p_iID);

                if (v_dt.Rows.Count > 0)
                {
                    v_objRes = U_Utility.Map_Row_To_Entity<E_Sys_Tai_Khoan>(v_dt.Rows[0]);
                }
            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                v_dt.Dispose();
            }

            return v_objRes;
        }

        public int Insert_Sys_Tai_Khoan(E_Sys_Tai_Khoan p_objData)
        {
            int v_iRes = U_Const.INT_VALUE_NULL;

            try
            {
                v_iRes = Convert.ToInt32(D_SqlHelper.ExecuteScalar(U_Config.Project_Staging_Conn_String, "sp_ins_Sys_Tai_Khoan",
                    p_objData.Ten_Nguoi_Dung, p_objData.Mat_Khau, p_objData.Email, p_objData.Dia_Chi, p_objData.SĐT, p_objData.CCCD, p_objData.Ghi_Chu, p_objData.Last_Updated_By, p_objData.Last_Updated_By_Function));
            }

            catch (Exception)
            {
                throw;
            }

            return v_iRes;
        }

        public void Update_Sys_Tai_Khoan(E_Sys_Tai_Khoan p_objData)
        {
            try
            {
                D_SqlHelper.ExecuteNonquery(U_Config.Project_Staging_Conn_String, "sp_upd_Sys_Tai_Khoan", p_objData.Auto_ID,
                    p_objData.Ten_Nguoi_Dung, p_objData.Mat_Khau, p_objData.Email, p_objData.Dia_Chi, p_objData.SĐT, p_objData.CCCD, p_objData.Ghi_Chu, p_objData.Last_Updated_By, p_objData.Last_Updated_By_Function);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public void Delete_Sys_Tai_Khoan(long p_iAuto_ID, string p_strLast_Updated_By, string p_strLast_Updated_By_Function)
        {
            try
            {
                D_SqlHelper.ExecuteNonquery(U_Config.Project_Staging_Conn_String, "sp_del_Sys_Tai_Khoan", p_iAuto_ID, p_strLast_Updated_By, p_strLast_Updated_By_Function);
            }

            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region FSys00101_Tai_Khoan_Staging_Grid, FSys00102_Tai_Khoan_Staging_Edit
        public void FSys00101_Delete_Sys_Tai_Khoan(long p_iAuto_ID, string p_strLast_Updated_By, string p_strLast_Updated_By_Function)
        {
            try
            {
                D_SqlHelper.ExecuteNonquery(U_Config.Project_Staging_Conn_String, "FSys00101_sp_del_Sys_Tai_Khoan", p_iAuto_ID, p_strLast_Updated_By, p_strLast_Updated_By_Function);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public int FSys00102_Insert_Sys_Tai_Khoan(E_Sys_Tai_Khoan p_objData)
        {
            int v_iRes = U_Const.INT_VALUE_NULL;

            try
            {
                v_iRes = Convert.ToInt32(D_SqlHelper.ExecuteScalar(U_Config.Project_Staging_Conn_String, "FSys00102_sp_ins_Sys_Tai_Khoan",
                    p_objData.Ten_Nguoi_Dung, p_objData.Mat_Khau, p_objData.Email, p_objData.Dia_Chi, p_objData.SĐT, p_objData.CCCD, p_objData.Ghi_Chu, p_objData.Last_Updated_By, p_objData.Last_Updated_By_Function));
            }

            catch (Exception)
            {
                throw;
            }

            return v_iRes;
        }

        public void FSys00102_Update_Sys_Tai_Khoan(E_Sys_Tai_Khoan p_objData)
        {
            try
            {
                D_SqlHelper.ExecuteNonquery(U_Config.Project_Staging_Conn_String, "FSys00102_sp_upd_Sys_Tai_Khoan", p_objData.Auto_ID,
                    p_objData.Ten_Nguoi_Dung, p_objData.Mat_Khau, p_objData.Email, p_objData.Dia_Chi, p_objData.SĐT, p_objData.CCCD, p_objData.Ghi_Chu, p_objData.Last_Updated_By, p_objData.Last_Updated_By_Function);
            }

            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
