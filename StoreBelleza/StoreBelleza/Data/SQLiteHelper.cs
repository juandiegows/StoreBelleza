using SQLite;
using StoreBelleza.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreBelleza.Data
{
    public class SQLiteHelper :SQLiteAsyncConnection
    {
        SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath):base(dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Product>().Wait();
            db.CreateTableAsync<Order>().Wait();
            db.CreateTableAsync<OrderDetails>().Wait();

        }

    
    }
}
