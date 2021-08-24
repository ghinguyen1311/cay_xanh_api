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
    public class VanBanRepository : ConnectDatabase, IVanBanRepository
    {
        public async Task<Result<QLCX_VanBan>> ThemMoiLoaiVanBan(QLCX_VanBan _danhMucVanBan)
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PLOAIVB", _danhMucVanBan.MaLoaiVanBan);
                parameters.Add("@PCOQUANBANHANH", _danhMucVanBan.CoQuanBanHanh);
                parameters.Add("@PNGAYBANHANH", _danhMucVanBan.NgayBanHanh);
                parameters.Add("@PTRICHYEU", _danhMucVanBan.TrichYeu);
                parameters.Add("@PNGUOIKY", _danhMucVanBan.NguoiKy);
                parameters.Add("@PCHUCVU", _danhMucVanBan.ChucVu);
                parameters.Add("@PNOIDUNG", _danhMucVanBan.NoiDung);
                QLCX_VanBan nhom = await SqlMapper.QueryFirstAsync<QLCX_VanBan>(sqlConn, "SP_VANBAN_THEMMOI", parameters, commandType: CommandType.StoredProcedure);
                return Result<QLCX_VanBan>.Success(nhom);
            }
            catch (Exception ex)
            {
                return Result<QLCX_VanBan>.Failure($"Process error: {ex.Message}");
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }

        public async Task<Result<QLCX_VanBan>> CapNhatLoaiVanBan(QLCX_VanBan _danhMucVanBan)
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PID", _danhMucVanBan.ID);
                parameters.Add("@PLOAIVB", _danhMucVanBan.MaLoaiVanBan);
                parameters.Add("@PCOQUANBANHANH", _danhMucVanBan.CoQuanBanHanh);
                parameters.Add("@PNGAYBANHANH", _danhMucVanBan.NgayBanHanh);
                parameters.Add("@PTRICHYEU", _danhMucVanBan.TrichYeu);
                parameters.Add("@PNGUOIKY", _danhMucVanBan.NguoiKy);
                parameters.Add("@PCHUCVU", _danhMucVanBan.ChucVu);
                parameters.Add("@PNOIDUNG", _danhMucVanBan.NoiDung);
                QLCX_VanBan nhom = await SqlMapper.QueryFirstAsync<QLCX_VanBan>(sqlConn, "SP_VANBAN_CAPNHAT", parameters, commandType: CommandType.StoredProcedure);
                return Result<QLCX_VanBan>.Success(nhom);
            }
            catch (Exception ex)
            {
                return Result<QLCX_VanBan>.Failure($"Process error: {ex.Message}");
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }

        public async Task<Result<QLCX_VanBan>> ThongTinLoaiVanBan(Guid ID)
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PID", ID);
                QLCX_VanBan nhom = SqlMapper.QueryFirstOrDefault<QLCX_VanBan>(sqlConn, "SP_VANBAN_CHITIET", parameters, commandType: CommandType.StoredProcedure);
                return Result<QLCX_VanBan>.Success(nhom);
            }
            catch (Exception ex)
            {
                return Result<QLCX_VanBan>.Failure($"Process error: {ex.Message}");
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }

        public async Task<Result<IEnumerable<QLCX_VanBan>>> TruyVanVanBan()
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                IEnumerable<QLCX_VanBan> nhomvb = await SqlMapper.QueryAsync<QLCX_VanBan>(sqlConn, "SP_VANBAN_TRUYVAN", commandType: CommandType.StoredProcedure);
                return Result<IEnumerable<QLCX_VanBan>>.Success(nhomvb);
                // return await SqlMapper.QueryAsync<QLCX_NhomNhanVien>("sp_RoomGet", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<QLCX_VanBan>>.Failure($"Process error: {ex.Message}");
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }

        public async Task<Result<int>> XoaVanBan(Guid ID)
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PID", ID);
                int kq = await SqlMapper.ExecuteAsync(sqlConn, "SP_VANBAN_XOA", parameters, commandType: CommandType.StoredProcedure);
                bool updateResult = kq > 0;
                if (!updateResult)
                    return Result<int>.Failure("Xóa văn bản không thành công");
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
