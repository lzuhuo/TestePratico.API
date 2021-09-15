using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TestePratico.Services.Interfaces.DAO;
using TestePratico.Services.Models;

namespace TestePratico.Data.DAO
{
    public class CatDAO : ICatDAO
    {
        private string _strCon;
        private SqlConnection _con;

        public CatDAO(IConfiguration config)
        {
            _strCon = config["ConnectionString:DBTICKET"];
        }
        public List<Cat> GetCat()
        {
            List<Cat> cats = null;
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT * FROM Cats");
            try
            {
                _con = new SqlConnection(_strCon);
                _con.Open();

                cats = _con.Query<Cat>(sql.ToString()).ToList();
            }
            catch
            {
                throw new NotImplementedException();
            }
            finally
            {
                if (_con != null && _con.State != ConnectionState.Closed)
                {
                    _con.Close();
                    _con = null;
                }
                else
                {
                    _con = null;
                }
            }
            return cats;
        }

        public Cat GetCat(int code)
        {
            Cat cat = null;
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT * FROM Cats WHERE Id = @Id");

            var parameter = new
            {
                Id = code
            };

            try
            {
                _con = new SqlConnection(_strCon);
                _con.Open();

                cat = _con.Query<Cat>(sql.ToString(), parameter).FirstOrDefault();

            }
            catch (SqlException)
            {
                throw;
            }
            catch
            {
                throw new NotImplementedException();
            }
            finally
            {
                if (_con != null && _con.State != ConnectionState.Closed)
                {
                    _con.Close();
                    _con = null;
                }
                else
                {
                    _con = null;
                }
            }
            return cat;
        }

        public int InsertCat(Cat cat)
        {
            int code;
            StringBuilder sql = new StringBuilder();
            sql.AppendLine( "INSERT INTO Cats                   ");
            sql.AppendLine( "(Name, Age, OwnerId)               ");
            sql.AppendLine( "VALUES                             ");
            sql.AppendLine( "(@Name, @Age, @OwnerId)            ");
            sql.AppendLine( "SELECT SCOPE_IDENTITY() AS CODE  ");

            var parameter = new
            {
                Name = cat.Name,
                Age = cat.Age,
                OwnerId = cat.OwnerId
            };

            try
            {
                _con = new SqlConnection(_strCon);
                _con.Open();

                code = _con.Query<int>(sql.ToString(), parameter).FirstOrDefault();

            }
            catch (SqlException)
            {
                throw;
            }
            catch
            {
                throw new NotImplementedException();
            }
            finally
            {
                if (_con != null && _con.State != ConnectionState.Closed)
                {
                    _con.Close();
                    _con = null;
                }
                else
                {
                    _con = null;
                }
            }
            return code;
        }

        public bool UpdateCat(Cat cat, int code)
        {
            bool result = false;
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(" UPDATE Cats            ");
            sql.AppendLine(" SET                    ");
            sql.AppendLine("     Name = @Name,      ");
            sql.AppendLine("     Age = @Age,        ");
            sql.AppendLine("     OwnerId = @OwnerId ");
            sql.AppendLine(" WHERE Id = @Code       ");

            var parameter = new
            {
                Name = cat.Name,
                Age = cat.Age,
                OwnerId = cat.OwnerId,
                Code = code
            };

            try
            {
                _con = new SqlConnection(_strCon);
                _con.Open();

                result = _con.Execute(sql.ToString(), param: parameter) > 0;

            }
            catch (SqlException)
            {
                throw;
            }
            catch
            {
                throw new NotImplementedException();
            }
            finally
            {
                if (_con != null && _con.State != ConnectionState.Closed)
                {
                    _con.Close();
                    _con = null;
                }
                else
                {
                    _con = null;
                }
            }
            return result;
        }

        public bool DeleteCat(int code)
        {
            bool result = false;
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(" DELETE FROM Cats WHERE Id = @Code ");
            
            var parameter = new
            {
                Code = code
            };

            try
            {
                _con = new SqlConnection(_strCon);
                _con.Open();

                result = _con.Execute(sql.ToString(), param: parameter) > 0;

            }
            catch (SqlException)
            {
                throw;
            }
            catch
            {
                throw new NotImplementedException();
            }
            finally
            {
                if (_con != null && _con.State != ConnectionState.Closed)
                {
                    _con.Close();
                    _con = null;
                }
                else
                {
                    _con = null;
                }
            }
            return result;
        }

    }
}
