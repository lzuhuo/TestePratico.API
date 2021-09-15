using System;
using System.Collections.Generic;
using System.Text;
using TestePratico.Services.Models;

namespace TestePratico.Services.Interfaces.Services
{
    public interface IDogService
    {
        List<Dog> GetDog();
        Dog GetDog(int code);
        int InsertDog(Dog Dog);
        bool UpdateDog(Dog Dog, int code);
        bool DeleteDog(int code);
    }
}
