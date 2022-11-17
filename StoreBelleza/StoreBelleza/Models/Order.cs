using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreBelleza.Model
{
    public class Order
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Unique]
        public string NIC { get; set; }
        public string Direction { get; set; }
        public double Total { get; set; }
        public DateTime DateOrder { get; set; }
    }
}
