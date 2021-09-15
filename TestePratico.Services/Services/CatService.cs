using System;
using System.Collections.Generic;
using System.Text;
using TestePratico.Services.Interfaces.DAO;
using TestePratico.Services.Interfaces.Services;
using TestePratico.Services.Models;

namespace TestePratico.Services.Services
{
    public class CatService : ICatService
    {
        private ICatDAO _catDAO;
        public CatService(ICatDAO catDAO)
        {
            _catDAO = catDAO;
        }

        public List<Cat> GetCat()
        {
            List<Cat> cats = null;

            try
            {
                cats = _catDAO.GetCat();
            }
            catch
            {
                throw new NotImplementedException();
            }
            return cats;
        }

        public Cat GetCat(int code)
        {
            Cat cat = null;

            try
            {
                cat = _catDAO.GetCat(code);
            }
            catch
            {
                throw new NotImplementedException();
            }
            return cat;
        }

        public int InsertCat(Cat cat)
        {
            int code;

            try
            {
                code = _catDAO.InsertCat(cat);
            }
            catch
            {
                throw new NotImplementedException();
            }
            return code;
        }

        public bool UpdateCat(Cat cat, int code)
        {
            bool result;

            try
            {
                result = _catDAO.UpdateCat(cat, code);
            }
            catch
            {
                throw new NotImplementedException();
            }
            return result;
        }
        public bool DeleteCat(int code)
        {
            bool result;

            try
            {
                result = _catDAO.DeleteCat(code);
            }
            catch
            {
                throw new NotImplementedException();
            }
            return result;
        }
    }
}
