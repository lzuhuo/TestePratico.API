using System;
using System.Collections.Generic;
using System.Text;
using TestePratico.Services.Models;

namespace TestePratico.Services.Interfaces.Services
{
    public interface IOwnerService
    {
        List<Owner> GetOwner();
        Owner GetOwner(int code);
    }
}
