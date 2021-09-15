using System;
using System.Collections.Generic;
using System.Text;
using TestePratico.Services.Interfaces.DAO;
using TestePratico.Services.Interfaces.Services;
using TestePratico.Services.Models;

namespace TestePratico.Services.Services
{
    public class DogService : IDogService
    {
        private IDogDAO _DogDAO;
        public DogService(IDogDAO DogDAO)
        {
            _DogDAO = DogDAO;
        }

        public List<Dog> GetDog()
        {
            List<Dog> Dogs = null;

            try
            {
                Dogs = _DogDAO.GetDog();
            }
            catch
            {
                throw new NotImplementedException();
            }
            return Dogs;
        }

        public Dog GetDog(int code)
        {
            Dog Dog = null;

            try
            {
                Dog = _DogDAO.GetDog(code);
            }
            catch
            {
                throw new NotImplementedException();
            }
            return Dog;
        }

        public int InsertDog(Dog Dog)
        {
            int code;

            try
            {
                code = _DogDAO.InsertDog(Dog);
            }
            catch
            {
                throw new NotImplementedException();
            }
            return code;
        }

        public bool UpdateDog(Dog Dog, int code)
        {
            bool result;

            try
            {
                result = _DogDAO.UpdateDog(Dog, code);
            }
            catch
            {
                throw new NotImplementedException();
            }
            return result;
        }
        public bool DeleteDog(int code)
        {
            bool result;

            try
            {
                result = _DogDAO.DeleteDog(code);
            }
            catch
            {
                throw new NotImplementedException();
            }
            return result;
        }
    }
}
