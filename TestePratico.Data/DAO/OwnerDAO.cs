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
    public class OwnerDAO : IOwnerDAO
    {
        private string _strCon;
        private SqlConnection _con;

        public OwnerDAO(IConfiguration config)
        {
            _strCon = config["ConnectionString:DBTICKET"];
        }
        public List<Owner> GetOwner()
        {
            List<Owner> owners = null;
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT * FROM Owner");
            try
            {
                _con = new SqlConnection(_strCon);
                _con.Open();

                owners = _con.Query<Owner>(sql.ToString()).ToList();
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
            return owners;

        }

        public Owner GetOwner(int code)
        {
            Owner owner = null;
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT * FROM Owner WHERE Id = @Id");

            var parameter = new
            {
                Id = code
            };

            try
            {
                _con = new SqlConnection(_strCon);
                _con.Open();

                owner = _con.Query<Owner>(sql.ToString(), parameter).FirstOrDefault();

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
            return owner;
        }
    }
}
