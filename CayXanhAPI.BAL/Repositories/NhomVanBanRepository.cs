using CayXanhAPI.BAL.Interfaces;
using CayXanhAPI.Domain;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CayXanhAPI.BAL.Repositories
{
    public class NhomVanBanRepository : ConnectDatabase, INhomVanBanRepository
    {
        public async Task<Result<QLCX_LoaiVanBan>> CapNhatLoaiVanBan(QLCX_LoaiVanBan _danhMucVanBan)
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PTRANGTHAI", _danhMucVanBan.TrangThai);
                QLCX_LoaiVanBan nhom = await SqlMapper.QueryFirstAsync<QLCX_LoaiVanBan>(sqlConn, "SP_DANHMUC_VANBAN_CAPNHAT_TRANGTHAI", parameters, commandType: CommandType.StoredProcedure);
                return Result<QLCX_LoaiVanBan>.Success(nhom);
            }
            catch (Exception ex)
            {
                return Result<QLCX_LoaiVanBan>.Failure($"Process error: {ex.Message}");
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }

        public async Task<Result<QLCX_LoaiVanBan>> ThemMoiLoaiVanBan(QLCX_LoaiVanBan _danhMucVanBan)
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PTENLOAI", _danhMucVanBan.TenLoai);
                parameters.Add("@PTRANGTHAI", _danhMucVanBan.TrangThai);
                QLCX_LoaiVanBan nhom = await SqlMapper.QueryFirstAsync<QLCX_LoaiVanBan>(sqlConn, "SP_DANHMUC_VANBAN_THEMMOI", parameters, commandType: CommandType.StoredProcedure);
                return Result<QLCX_LoaiVanBan>.Success(nhom);
            }
            catch (Exception ex)
            {
                return Result<QLCX_LoaiVanBan>.Failure($"Process error: {ex.Message}");
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }

        public async Task<Result<QLCX_LoaiVanBan>> ThongTinLoaiVanBan(int ID)
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PID", ID);
                QLCX_LoaiVanBan nhom = SqlMapper.QueryFirstOrDefault<QLCX_LoaiVanBan>(sqlConn, "SP_DANHMUC_VANBAN_THONGTIN", parameters, commandType: CommandType.StoredProcedure);
                return Result<QLCX_LoaiVanBan>.Success(nhom);
            }
            catch (Exception ex)
            {
                return Result<QLCX_LoaiVanBan>.Failure($"Process error: {ex.Message}");
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }

        public async Task<Result<IEnumerable<QLCX_LoaiVanBan>>> TruyVanLoaiVanBan()
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                IEnumerable<QLCX_LoaiVanBan> nhomvb = await SqlMapper.QueryAsync<QLCX_LoaiVanBan>(sqlConn, "SP_DANHMUC_VANBAN_TRUYVAN", commandType: CommandType.StoredProcedure);
                return Result<IEnumerable<QLCX_LoaiVanBan>>.Success(nhomvb);
                // return await SqlMapper.QueryAsync<QLCX_NhomNhanVien>("sp_RoomGet", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<QLCX_LoaiVanBan>>.Failure($"Process error: {ex.Message}");
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }

        public async Task<Result<int>> XoaLoaiVanBan(int ID)
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PID", ID);
                int kq = await SqlMapper.ExecuteAsync(sqlConn, "SP_DANHMUC_VANBAN_XOA", parameters, commandType: CommandType.StoredProcedure);
                bool updateResult = kq > 0;
                if (!updateResult)
                    return Result<int>.Failure("Xóa nhóm văn bản không thành công");
                return Result<int>.Success(kq);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure($"Process error: {ex.Message}");
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }
    }
}
