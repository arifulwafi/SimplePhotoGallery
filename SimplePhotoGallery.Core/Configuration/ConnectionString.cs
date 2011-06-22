using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplePhotoGallery.Core.Configuration
{
    public class ConnectionString : IConnectionString 
    {
        public string DefaultConnectionString { get; private set; }

        public ConnectionString(string connectionString)
        {
            DefaultConnectionString = connectionString;
        }
    }
}
