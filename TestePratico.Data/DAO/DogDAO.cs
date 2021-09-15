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
    public class DogDAO : IDogDAO
    {
        private string _strCon;
        private SqlConnection _con;

        public DogDAO(IConfiguration config)
        {
            _strCon = config["ConnectionString:DBTICKET"];
        }
        public List<Dog> GetDog()
        {
            List<Dog> Dogs = null;
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT * FROM Dogs");
            try
            {
                _con = new SqlConnection(_strCon);
                _con.Open();

                Dogs = _con.Query<Dog>(sql.ToString()).ToList();
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
            return Dogs;
        }

        public Dog GetDog(int code)
        {
            Dog Dog = null;
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT * FROM Dogs WHERE Id = @Id");

            var parameter = new
            {
                Id = code
            };

            try
            {
                _con = new SqlConnection(_strCon);
                _con.Open();

                Dog = _con.Query<Dog>(sql.ToString(), parameter).FirstOrDefault();

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
            return Dog;
        }

        public int InsertDog(Dog Dog)
        {
            int code;
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO Dogs                   ");
            sql.AppendLine("(Name, Age, OwnerId)               ");
            sql.AppendLine("VALUES                             ");
            sql.AppendLine("(@Name, @Age, @OwnerId)            ");
            sql.AppendLine("SELECT SCOPE_IDENTITY() AS CODE  ");

            var parameter = new
            {
                Name = Dog.Name,
                Age = Dog.Age,
                OwnerId = Dog.OwnerId
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

        public bool UpdateDog(Dog Dog, int code)
        {
            bool result = false;
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(" UPDATE Dogs            ");
            sql.AppendLine(" SET                    ");
            sql.AppendLine("     Name = @Name,      ");
            sql.AppendLine("     Age = @Age,        ");
            sql.AppendLine("     OwnerId = @OwnerId ");
            sql.AppendLine(" WHERE Id = @Code       ");

            var parameter = new
            {
                Name = Dog.Name,
                Age = Dog.Age,
                OwnerId = Dog.OwnerId,
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

        public bool DeleteDog(int code)
        {
            bool result = false;
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(" DELETE FROM Dogs WHERE Id = @Code ");

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
