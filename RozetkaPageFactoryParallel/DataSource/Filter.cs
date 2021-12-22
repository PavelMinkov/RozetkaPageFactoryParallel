
using System;

namespace RozetkaPageFactory.TestDataAccess
{
    [Serializable]
    public class Filter
    {
        public int categoryProducts { get; set; }
        public string nameProducts { get; set; }
        public string brand { get; set; }
        public int sort { get; set; }
        public int numberProduct { get; set; }
        public int price { get; set; }
    }
}
