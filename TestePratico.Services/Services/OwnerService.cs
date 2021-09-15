using System;
using System.Collections.Generic;
using System.Text;
using TestePratico.Services.Interfaces.DAO;
using TestePratico.Services.Interfaces.Services;
using TestePratico.Services.Models;

namespace TestePratico.Services.Services
{
    public class OwnerService : IOwnerService
    {
        private IOwnerDAO _ownerDAO;
        public OwnerService(IOwnerDAO ownerDAO)
        {
            _ownerDAO = ownerDAO;
        }
        public List<Owner> GetOwner()
        {
            List<Owner> owner = null;

            try
            {
                owner = _ownerDAO.GetOwner();
            }
            catch
            {
                throw new NotImplementedException();
            }
            return owner;
        }

        public Owner GetOwner(int code)
        {
            Owner owner = null;

            try
            {
                owner = _ownerDAO.GetOwner(code);
            }
            catch
            {
                throw new NotImplementedException();
            }
            return owner;
        }
    }
}
