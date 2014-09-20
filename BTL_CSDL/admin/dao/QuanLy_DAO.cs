using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BTL_CSDL.admin.dao
{
    public class QuanLy_DAO
    {
        /// <summary>
        /// Hàm kiểm tra lúc đăng nhập hệ thống của người quản lý
        /// </summary>
        /// <param name="userName">Tên đăng nhập hoặc email của người quản lý</param>
        /// <param name="password">mật khẩu đăng nhập</param>
        /// <returns>DataTable</returns>
        public static DataTable check_Login(String userName, String password)
        {
            String strCon  = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {
                
                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "CHECK_LOGIN";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                SqlParameter pUserName = new SqlParameter("@USERNAME", SqlDbType.VarChar, 50);
                SqlParameter pEmail = new SqlParameter("@EMAIL", SqlDbType.VarChar, 100);
                SqlParameter pPassword = new SqlParameter("@PASS", SqlDbType.NVarChar, 50);
                pUserName.Value = userName;
                pEmail.Value = userName;
                pPassword.Value = password;
                cmd.Parameters.Add(pUserName);
                cmd.Parameters.Add(pEmail);
                cmd.Parameters.Add(pPassword);
                                
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
        /// Lấy tất cả danh sách của những người quản lý trong hệ thống
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable getAllQuanLy()
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "GET_ALL_QUANLY";
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
        /// Lấy thông tin người quản lý theo Mã Quản Lý
        /// </summary>
        /// <param name="MaQl"></param>
        /// <returns></returns>
        public static DataTable getQuanLyByMaQL(String MaQl)
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "GET_QUANLY_MA_QL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                SqlParameter pUserName = new SqlParameter("@MA_QL", SqlDbType.VarChar, 50);
                pUserName.Value = MaQl;
                cmd.Parameters.Add(pUserName);
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
        /// Sửa thông tin người quản lý
        /// </summary>
        /// <param name="MaQL">Mã Quản Lý</param>
        /// <param name="TenQL">Tên Quản Lý</param>
        /// <param name="MatKhau">Mật Khẩu quản lý</param>
        /// <param name="DiaChi">Địa chỉ </param>
        /// <param name="Email">Email</param>
        /// <param name="SoDienThoai">Số Điện Thoại</param>
        /// <param name="ngaysinh">Ngày Sinh</param>
        /// <returns>Boolean</returns>
        public static Boolean updateQuanLy(String MaQL,String TenQL,String DiaChi,String Email,String SoDienThoai,DateTime ngaysinh)
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "UPDATE_QUANLY";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                SqlParameter pUserName = new SqlParameter("@MA_QL", SqlDbType.VarChar, 50);
                pUserName.Value = MaQL;
                cmd.Parameters.Add(pUserName);
                SqlParameter pTenQl = new SqlParameter("@TEN_QL", SqlDbType.NVarChar, 50);
                pTenQl.Value = MaQL;
                cmd.Parameters.Add(pTenQl);

                SqlParameter pDiaChi = new SqlParameter("@DIA_CHI", SqlDbType.NVarChar, 200);
                pDiaChi.Value = MaQL;
                cmd.Parameters.Add(pDiaChi);

                SqlParameter pEmail = new SqlParameter("@EMAIL", SqlDbType.VarChar, 100);
                pEmail.Value = Email;
                cmd.Parameters.Add(pEmail);

                SqlParameter pSDT = new SqlParameter("@SO_DIEN_THOAI", SqlDbType.VarChar, 20);
                pSDT.Value = SoDienThoai;
                cmd.Parameters.Add(pSDT);

                SqlParameter pNgaySinh = new SqlParameter("@NGAY_SINH", SqlDbType.Date);
                pNgaySinh.Value = ngaysinh;
                cmd.Parameters.Add(pNgaySinh);

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
        /// Hàm sửa thông tin người quản lý do admin của hệ thống sửa
        /// </summary>
        /// <param name="MaQL">Mã Quản Lý</param>
        /// <param name="TenQL">Tên Quản Lý</param>
        /// <param name="MatKhau">Mật Khẩu</param>
        /// <param name="DiaChi">Địa chỉ</param>
        /// <param name="Email">Email</param>
        /// <param name="SoDienThoai">Số Điện Thoại</param>
        /// <param name="ngaysinh">Ngày Sinh</param>
        /// <param name="isAdmin">Cấp quyền Admin hay không?</param>
        /// <returns></returns>
        public static Boolean updateQuanLyAdmin(String MaQL, String TenQL,String DiaChi, String Email, String SoDienThoai, DateTime ngaysinh,Boolean isAdmin)
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "UPDATE_QUANLY_ADMIN";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                SqlParameter pUserName = new SqlParameter("@MA_QL", SqlDbType.VarChar, 50);
                pUserName.Value = MaQL;
                cmd.Parameters.Add(pUserName);

                SqlParameter pTenQl = new SqlParameter("@TEN_QL", SqlDbType.NVarChar, 50);
                pTenQl.Value = TenQL;
                cmd.Parameters.Add(pTenQl);

                SqlParameter pDiaChi = new SqlParameter("@DIA_CHI", SqlDbType.NVarChar, 200);
                pDiaChi.Value = DiaChi;
                cmd.Parameters.Add(pDiaChi);

                SqlParameter pEmail = new SqlParameter("@EMAIL", SqlDbType.VarChar, 100);
                pEmail.Value = Email;
                cmd.Parameters.Add(pEmail);

                SqlParameter pSDT = new SqlParameter("@SO_DIEN_THOAI", SqlDbType.VarChar, 20);
                pSDT.Value = SoDienThoai;
                cmd.Parameters.Add(pSDT);

                SqlParameter pNgaySinh = new SqlParameter("@NGAY_SINH", SqlDbType.Date);
                pNgaySinh.Value = ngaysinh;
                cmd.Parameters.Add(pNgaySinh);

                SqlParameter pIsAdmin = new SqlParameter("@IS_ADMIN", SqlDbType.Bit);
                pIsAdmin.Value = isAdmin;
                cmd.Parameters.Add(pIsAdmin);

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
        /// Thêm Người quản lý. 
        /// Lưu Ý: việc thêm này do admin của hệ thống thêm ngoài ra các quản lý khác không có quyền!
        /// </summary>
        /// <param name="MaQL">Mã Quản Lý</param>
        /// <param name="TenQL">Tên Quản Lý</param>
        /// <param name="MatKhau">Mật Khẩu</param>
        /// <param name="DiaChi">Địa Chỉ</param>
        /// <param name="Email">Email</param>
        /// <param name="SoDienThoai">Số Điện Thoại</param>
        /// <param name="ngaysinh">Ngày Sinh</param>
        /// <param name="isAdmin">Cấp quyền Admin hay Không</param>
        /// <returns>Boolean</returns>
        public static Boolean insertQuanLy(String MaQL, String TenQL, String DiaChi, String Email, String SoDienThoai, DateTime ngaysinh, Boolean isAdmin)
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "INSERT_QUANLY";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                SqlParameter pUserName = new SqlParameter("@MA_QL", SqlDbType.VarChar, 50);
                pUserName.Value = MaQL;
                cmd.Parameters.Add(pUserName);
                SqlParameter pTenQl = new SqlParameter("@TEN_QL", SqlDbType.NVarChar, 50);
                pTenQl.Value = MaQL;
                cmd.Parameters.Add(pTenQl);

                SqlParameter pDiaChi = new SqlParameter("@DIA_CHI", SqlDbType.NVarChar, 200);
                pDiaChi.Value = MaQL;
                cmd.Parameters.Add(pDiaChi);

                SqlParameter pEmail = new SqlParameter("@EMAIL", SqlDbType.VarChar, 100);
                pEmail.Value = Email;
                cmd.Parameters.Add(pEmail);

                SqlParameter pSDT = new SqlParameter("@SO_DIEN_THOAI", SqlDbType.VarChar, 20);
                pSDT.Value = SoDienThoai;
                cmd.Parameters.Add(pSDT);

                SqlParameter pNgaySinh = new SqlParameter("@NGAY_SINH", SqlDbType.Date);
                pNgaySinh.Value = ngaysinh;
                cmd.Parameters.Add(pNgaySinh);

                SqlParameter pIsAdmin = new SqlParameter("@IS_ADMIN", SqlDbType.Bit);
                pIsAdmin.Value = isAdmin;
                cmd.Parameters.Add(pIsAdmin);

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
        /// Xóa quản lý với Mã Quản lý tương ứng!
        /// Chức năng này chỉ có admin của hệ thống mới thực hiện được!
        /// </summary>
        /// <param name="MaQL">Mã Quản Lý</param>
        /// <returns>Boolean</returns>
        public static Boolean deleteQuanLy(String MaQL)
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "DELETE_QUANLY_MAQL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                SqlParameter pMaQL = new SqlParameter("@MA_QL", SqlDbType.VarChar, 50);
                pMaQL.Value = MaQL;
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
        /// Khôi Phục mật khẩu về mặc định
        /// Chức năng này chỉ có admin mới thực hiện được
        /// </summary>
        /// <param name="MaQL">Ma quản lý</param>
        /// <returns>Boolean</returns>
        public static Boolean khoiphucmatkhau(String MaQL)
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "RESET_PASSWORD";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                SqlParameter pMaQL = new SqlParameter("@MA_QL", SqlDbType.VarChar, 50);
                pMaQL.Value = MaQL;
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
        /// Đổi mật khẩu
        /// chức năng này hỗ trợ tất cả các người quản lý
        /// </summary>
        /// <param name="MaQL">Mã Quản Lý</param>
        /// <param name="newpass">Mật Khẩu mới</param>
        /// <returns>Boolean</returns>
        public static Boolean doimatkhau(String MaQL,string newpass)
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "DOI_MATKHAU";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                SqlParameter pMaQL = new SqlParameter("@MA_QL", SqlDbType.VarChar, 50);
                pMaQL.Value = MaQL;
                cmd.Parameters.Add(pMaQL);

                SqlParameter pNewPass = new SqlParameter("@NEWPASS", SqlDbType.NVarChar, 50);
                pNewPass.Value = newpass;
                cmd.Parameters.Add(pNewPass);

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