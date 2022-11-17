using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreBelleza.Model
{
    public class Product 
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]
        [Unique]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
        
        public double Price { get; set; }   

        public int Count { get; set; }
    }
}
