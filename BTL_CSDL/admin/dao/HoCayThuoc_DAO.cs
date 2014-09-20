using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BTL_CSDL.admin.dao
{
    public class HoCayThuoc_DAO
    {
        /// <summary>
        /// PHƯƠNG THỨC LẤY VỀ DANH SÁCH HỌ CÁC CÂY THUỐC TRONG BẢNG HO_CAYTHUOC
        /// </summary>
        /// <returns>DataTabel</returns>
        public static DataTable getAll_Hocaythuoc()
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "GET_ALL_HOCAYTHUOC";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con != null)
                    con.Close();
            }
            return null;
        }
        /// <summary>
        /// Lấy về thông tin của Họ cây thuốc với mã họ tương ứng truyền vào
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable getHoCayThuocByMaHo(int id)
        {

            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "GET_HOCAYTHUOC_MAHO";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@MA_HO", SqlDbType.Int);
                param.Value = id;
                cmd.Parameters.Add(param);
                cmd.Connection = con;

                da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con != null)
                    con.Close();
            }
            return null;
        }
        /// <summary>
        /// Update thông tin họ cây thuốc
        /// </summary>
        /// <param name="id"></param>
        /// <returns>boolean</returns>
        public static Boolean update(int id,String tenHienThi,String tenKH)
        {

            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "UPDATE_HOCAYTHUOC";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pMa_Ho = new SqlParameter("@MA_HO", SqlDbType.Int);
                pMa_Ho.Value = id;
                SqlParameter pTenHienThi = new SqlParameter("@TEN_HT", SqlDbType.NVarChar, 100);
                pTenHienThi.Value = tenHienThi;
                SqlParameter pTenKH = new SqlParameter("@TEN_KH", SqlDbType.VarChar, 100);
                pTenKH.Value = tenKH;
                cmd.Parameters.Add(pMa_Ho);
                cmd.Parameters.Add(pTenHienThi);
                cmd.Parameters.Add(pTenKH);
                cmd.Connection = con;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con != null)
                    con.Close();
            }
            return false;
        }

        /// <summary>
        /// Insert họ cây vào trong database
        /// </summary>
        /// <param name="tenHienThi"></param>
        /// <param name="tenKH"></param>
        /// <param name="Ma_Ql"></param>
        /// <returns>boolean</returns>
        public static Boolean insert(String tenHienThi, String tenKH,String Ma_Ql)
        {

            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "INSERT_HOCAYTHUOC";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pMaQL = new SqlParameter("@MA_QL", SqlDbType.VarChar,50);
                pMaQL.Value = Ma_Ql;
                SqlParameter pTenHienThi = new SqlParameter("@TEN_HT", SqlDbType.NVarChar, 100);
                pTenHienThi.Value = tenHienThi;
                SqlParameter pTenKH = new SqlParameter("@TEN_KH", SqlDbType.VarChar, 100);
                pTenKH.Value = tenKH;
                cmd.Parameters.Add(pMaQL);
                cmd.Parameters.Add(pTenHienThi);
                cmd.Parameters.Add(pTenKH);
                cmd.Connection = con;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con != null)
                    con.Close();
            }
            return false;
        }

        public static Boolean delete(int maHo)
        {

            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "DELETE_HOCAYTHUOC";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pMaQL = new SqlParameter("@MA_HO", SqlDbType.Int);
                pMaQL.Value = maHo;
                cmd.Parameters.Add(pMaQL);
                cmd.Connection = con;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con != null)
                    con.Close();
            }
            return false;
        }
       
    }
}