using System;
using System.Collections.Generic;
using System.Text;
using TestePratico.Services.Models;

namespace TestePratico.Services.Interfaces.DAO
{
    public interface ICatDAO
    {
        List<Cat> GetCat();
        Cat GetCat(int code);
        int InsertCat(Cat cat);
        bool UpdateCat(Cat cat, int code);
        bool DeleteCat(int code);

    }
}
