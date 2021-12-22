using RozetkaPageFactory.TestDataAccess;
using System;
using System.Collections.Generic;

namespace RozetkaPageFactoryParallel.TestDataAccess
{
    [Serializable]
    public class Filters
    {
        public List<Filter> FiltersList { get; set; }
        public Filters()
        {
            FiltersList = new List<Filter>();
        }
    }
}
