
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;


namespace ETests.Model
{
    public interface ISQLite
    {
           SQLiteAsyncConnection GetConnection();
        //}
    }
}
