using System;
using System.Collections.Generic;
using System.Text;

namespace Wickers.Movie.Models
{
    public class ApplicationSettingsModel
    {
        public string Name { get; set; }
        public string Environment { get; set; }
        public string SqlConnectionString { get; set; }
        public int SqlTimeout { get; set; }
    }
}
