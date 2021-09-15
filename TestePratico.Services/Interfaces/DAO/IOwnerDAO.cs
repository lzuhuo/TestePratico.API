using System;
using System.Collections.Generic;
using System.Text;
using TestePratico.Services.Models;

namespace TestePratico.Services.Interfaces.DAO
{
    public interface IOwnerDAO
    {
        List<Owner> GetOwner();
        Owner GetOwner(int code);
    }
}
