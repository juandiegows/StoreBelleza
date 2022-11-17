
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreBelleza.Model
{
    public class OrderDetails
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public double Total { get; set; }
    }
}
