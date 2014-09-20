using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace BTL_CSDL.admin.dao
{
    public class CayThuoc_DAO
    {
        /// <summary>
        /// Lấy tất cả các danh sách cây thuốc
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable getAllCayThuoc()
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "GET_ALL_CAYTHUOC";
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


        public static String getTenHienThi_MaCay(int macay)
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "GET_TENCAY_MACAY";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pMaCay = new SqlParameter("@MA_CAY", SqlDbType.Int);
                pMaCay.Value = macay;
                cmd.Parameters.Add(pMaCay);
                cmd.Connection = con;

                da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt.Rows[0][0].ToString();
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
        /// Lấy cây thuốc theo mã cây thuốc
        /// </summary>
        /// <param name="macay">Mã Cây Thuốc</param>
        /// <returns>DataTable</returns>
        public static DataTable getCayThuoc_MaCay(int macay)
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "GET_CAYTHUOC_MACAY";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                SqlParameter pMaCay = new SqlParameter("@MA_CAY", SqlDbType.Int);
                pMaCay.Value = macay;
                cmd.Parameters.Add(pMaCay);

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
        /// Thêm mới cây thuốc
        /// </summary>
        /// <param name="macay">Mã Cây Thuốc</param>
        /// <param name="TenHT">Tên Hiển Thị</param>
        /// <param name="TenKH">Tên Khoa Học</param>
        /// <param name="ND">Nội Dung</param>
        /// <param name="status">Trạng Thái hiển Thị</param>
        /// <param name="MaHo">Mã Họ Cây Thuốc</param>
        /// <param name="maQl">Mã Quản Lý Cây Thuốc</param>
        /// <returns>Boolean</returns>
        public static Boolean insertCayThuoc(String TenHT, String TenKH, String ND, Boolean status, int MaHo, String maQl)
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "INSERT_CAYTHUOC";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                SqlParameter pTenHT = new SqlParameter("@TEN_HIEN_THI", SqlDbType.NVarChar, 100);
                pTenHT.Value = TenHT;
                cmd.Parameters.Add(pTenHT);

                SqlParameter pTenKH = new SqlParameter("@TEN_KH", SqlDbType.VarChar, 100);
                pTenKH.Value = TenKH;
                cmd.Parameters.Add(pTenKH);

                SqlParameter pND = new SqlParameter("@NOI_DUNG", SqlDbType.NText);
                pND.Value = ND;
                cmd.Parameters.Add(pND);

                SqlParameter pStatus = new SqlParameter("@TRANG_THAI", SqlDbType.Bit);
                pStatus.Value = status;
                cmd.Parameters.Add(pStatus);

                SqlParameter pMaHo = new SqlParameter("@MA_HO", SqlDbType.Int);
                pMaHo.Value = MaHo;
                cmd.Parameters.Add(pMaHo);

                SqlParameter pMaQL = new SqlParameter("@MA_QL", SqlDbType.VarChar, 50);
                pMaQL.Value = maQl;
                cmd.Parameters.Add(pMaQL);
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
        /// Sửa cây thuốc
        /// </summary>
        /// <param name="macay">Mã Cây Thuốc</param>
        /// <param name="TenHT">Tên Hiển Thị</param>
        /// <param name="TenKH">Tên Khoa HỌc</param>
        /// <param name="ND">Nội Dung</param>
        /// <param name="status">Trạng Thái HIển Thị</param>
        /// <param name="MaHo">Mã Họ</param>
        /// <param name="maQl">Mã Quản Lý</param>
        /// <returns>Boolean</returns>
        public static Boolean updateCayThuoc(int macay, String TenHT, String TenKH, String ND, Boolean status, int MaHo, String maQl)
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "UPDATE_CAYTHUOC";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                SqlParameter pMaCay = new SqlParameter("@MA_CAY", SqlDbType.Int);
                pMaCay.Value = macay;
                cmd.Parameters.Add(pMaCay);

                SqlParameter pTenHT = new SqlParameter("@TEN_HIEN_THI", SqlDbType.NVarChar, 100);
                pTenHT.Value = TenHT;
                cmd.Parameters.Add(pTenHT);

                SqlParameter pTenKH = new SqlParameter("@TEN_KH", SqlDbType.VarChar, 100);
                pTenKH.Value = TenKH;
                cmd.Parameters.Add(pTenKH);

                SqlParameter pND = new SqlParameter("@NOI_DUNG", SqlDbType.NText);
                pND.Value = ND;
                cmd.Parameters.Add(pND);

                SqlParameter pStatus = new SqlParameter("@TRANG_THAI", SqlDbType.Bit);
                pStatus.Value = status;
                cmd.Parameters.Add(pStatus);

                SqlParameter pMaHo = new SqlParameter("@MA_HO", SqlDbType.Int);
                pMaHo.Value = MaHo;
                cmd.Parameters.Add(pMaHo);

                SqlParameter pMaQL = new SqlParameter("@MA_QL", SqlDbType.VarChar, 50);
                pMaQL.Value = maQl;
                cmd.Parameters.Add(pMaQL);
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

        public static Boolean deleteCayThuoc(int macay)
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "DELETE_CAYTHUOC";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                SqlParameter pMaCay = new SqlParameter("@MA_CAY", SqlDbType.Int);
                pMaCay.Value = macay;
                cmd.Parameters.Add(pMaCay);

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
        /// Lấy danh sách cây thuốc hiển thị bên Client
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable getAllCayThuocClient()
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "GET_CAYTHUOC_CLIENT";
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
        public static DataTable getAllCayThuocClientMaHo(int id)
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "GET_CAYTHUOC_CLIENT_MAHO";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pMaHo = new SqlParameter("@MAHO", SqlDbType.Int);
                pMaHo.Value = id;
                cmd.Parameters.Add(pMaHo);
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

        public static DataTable searchTenCayThuoc(string prefix)
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "SEARCH_CAYTHUOC";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                SqlParameter pTenHT = new SqlParameter("@PREFIX", SqlDbType.NVarChar, 100);
                pTenHT.Value = prefix;
                cmd.Parameters.Add(pTenHT);

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

        public static DataTable searchhocaythuoc(string prefix)
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "SEARCH_CAYTHUOC_HOCAYTHUOC";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                SqlParameter pTenHT = new SqlParameter("@PRE", SqlDbType.NVarChar, 100);
                pTenHT.Value = prefix;
                cmd.Parameters.Add(pTenHT);

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

        public static DataTable searchBaiThuoc(string prefix)
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "SEARCH_CAYTHUOC_BAITHUOC";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                SqlParameter pTenHT = new SqlParameter("@PRE", SqlDbType.NVarChar, 200);
                pTenHT.Value = prefix;
                cmd.Parameters.Add(pTenHT);

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
    }
}