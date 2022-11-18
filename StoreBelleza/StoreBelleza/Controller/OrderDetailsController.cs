using StoreBelleza.Data;
using StoreBelleza.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreBelleza.Controller
{
    public class OrderDetailsController : IController<OrderDetails>
    {
        private SQLiteHelper SQLite;
        public OrderDetailsController(SQLiteHelper db)
        {
            SQLite = db;
        }


        public int Delete(OrderDetails model)
        {
            return SQLite.Delete(model);
        }

        public List<OrderDetails> Get()
        {
            return SQLite.Table<OrderDetails>().ToList();
        }

        public OrderDetails Get(int ID)
        {
            return (Get()).FirstOrDefault(x => x.Id == ID);
        }

        public int Insert(OrderDetails model)
        {
            return SQLite.Insert(model);
        }

        public int Update(OrderDetails model)
        {
            return SQLite.Update(model);
        }
    }
}
