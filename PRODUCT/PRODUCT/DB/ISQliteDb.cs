using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace PRODUCT.DB
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
