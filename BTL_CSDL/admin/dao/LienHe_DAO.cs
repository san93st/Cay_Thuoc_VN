using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BTL_CSDL.admin.dao
{
    public class LienHe_DAO
    {
        /// <summary>
        /// Hàm Lấy dữ liệu gồm các liên hệ chưa được người quản lý xử lý
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable getLienHeChuaXuLy()
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "GET_ALL_LIENHE_CHUAXULY";
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
        /// Lấy danh sách các liên hệ đã được liên hệ
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable getLienHeDaXuLy()
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "GET_ALL_LIENHE_DAXULY";
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
        /// Lấy Liên Hệ theo Email của người liên hệ
        /// </summary>
        /// <param name="email"></param>
        /// <returns>DataTable</returns>
        public static DataTable getLienHeWithEmail(String email)
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "GET_ALL_LIENHE_EMAIL";
                SqlParameter param = new SqlParameter("@EMAIL", SqlDbType.VarChar, 100);
                param.Value = email;
                cmd.Parameters.Add(param);
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
        /// Sửa thông tin Liên Hệ
        /// </summary>
        /// <param name="email">Email của người liên hệ</param>
        /// <param name="status">Trạng thái (đã liên hệ hay chưa)</param>
        /// <param name="MaQL">Người quản lý liên hệ</param>
        /// <returns></returns>
        public static Boolean updateLienHe(String email,Boolean status,string MaQL)
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "UPDATE_LIENHE";
                SqlParameter pEmail = new SqlParameter("@EMAIL", SqlDbType.VarChar, 100);
                pEmail.Value = email;
                cmd.Parameters.Add(pEmail);
                SqlParameter pTrangThai = new SqlParameter("@TRANGTHAI", SqlDbType.Bit);
                if (status)
                {
                    pTrangThai.Value = 1;
                }
                else
                    pTrangThai.Value = 0;
                cmd.Parameters.Add(pTrangThai);
                SqlParameter pMaQl = new SqlParameter("@MA_QL", SqlDbType.VarChar,50);
                pMaQl.Value = MaQL;
                cmd.Parameters.Add(pMaQl);
                cmd.CommandType = CommandType.StoredProcedure;
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
        public static Boolean xoaLienHe(String email)
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "DELETE_LIENHE";
                SqlParameter pEmail = new SqlParameter("@EMAIL", SqlDbType.VarChar, 100);
                pEmail.Value = email;
                cmd.Parameters.Add(pEmail);
                cmd.CommandType = CommandType.StoredProcedure;
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

        public static Boolean insertLienHe(String email,String tenHienThi,String TieuDe,String NoiDung,String SDT)
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "INSERT_LIENHE";
                SqlParameter pEmail = new SqlParameter("@EMAIL", SqlDbType.VarChar, 100);
                pEmail.Value = email;
                cmd.Parameters.Add(pEmail);

                SqlParameter pTenHienThi = new SqlParameter("@TEN_HIENTHI", SqlDbType.NVarChar, 50);
                pTenHienThi.Value = tenHienThi;
                cmd.Parameters.Add(pTenHienThi);
                SqlParameter pTieuDe = new SqlParameter("@TIEU_DE", SqlDbType.NVarChar, 500);
                pTieuDe.Value = TieuDe;
                cmd.Parameters.Add(pTieuDe);
                SqlParameter pND = new SqlParameter("@NOI_DUNG", SqlDbType.NText);
                pND.Value = NoiDung;
                cmd.Parameters.Add(pND);
                SqlParameter pSDT = new SqlParameter("@SO_DIEN_THOAI", SqlDbType.VarChar, 20);
                pSDT.Value = SDT;
                cmd.Parameters.Add(pSDT);

                cmd.CommandType = CommandType.StoredProcedure;
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