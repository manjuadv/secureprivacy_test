﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class StoreDatabaseSettings : IStoreDatabaseSettings
    {
        public string BooksCollectionName { get; set; }
        public string CustomersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IStoreDatabaseSettings
    {
        string BooksCollectionName { get; set; }
        public string CustomersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
