using StoreBelleza.Data;
using StoreBelleza.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreBelleza.Controller
{
    public class OrderController : IController<Order>
    {
        private SQLiteHelper SQLite;
        public OrderController(SQLiteHelper db)
        {
            SQLite = db;
        }

        public int Delete(Order model)
        {
            return SQLite.Delete(model);
        }

        public List<Order> Get()
        {
            return SQLite.Table<Order>().ToList();
        }

        public Order Get(int ID)
        {
            return (Get()).FirstOrDefault(x => x.Id == ID);
        }

        public int Insert(Order model)
        {
            return SQLite.Insert(model);
        }

        public int Update(Order model)
        {
            return SQLite.Update(model);
        }
    }
}
