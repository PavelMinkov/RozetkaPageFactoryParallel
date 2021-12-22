using RozetkaPageFactoryParallel.TestDataAccess;
using System;
using System.IO;
using System.Xml.Serialization;

namespace RozetkaPageFactory.TestDataAccess
{
    class FilterReader
    {
        private Filter filter;

        public FilterReader()
        {
            this.filter = ReadFromXMLFile();
        }

        private Filter ReadFromXMLFile()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(Filter));
            try
            {
                string path = Directory.GetCurrentDirectory();
                path = path.Substring(0, path.Length - 17);
                path = Path.Combine(path, @"TestDataAccess\Filter.xml");
                using (Stream fStream = File.OpenRead(path))
                {
                    return (Filter)xmlFormat.Deserialize(fStream);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Can`t open filter file");
                return null;
            }
        }

        public int GetCategoryProducts()
        {
            return filter.categoryProducts;
        }

        public string GetNameProducts()
        {
            return filter.nameProducts;
        }

        public string GetBrand()
        {
            return filter.brand;
        }

        public int GetSort()
        {
            return filter.sort;
        }
        public int GetNumberProduct()
        {
            return filter.numberProduct;
        }
        
        public int GetNumberPrice()
        {
            return filter.price;
        }

        public static Filters ReadFiltersFromXML()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(Filters));
            try
            {
                string path = Directory.GetCurrentDirectory();
                path = path.Substring(0, path.Length - 17);
                path = Path.Combine(path, @"TestDataAccess\Filters.xml");
                using (Stream fStream = File.OpenRead(path))
                {
                    return (Filters)xmlFormat.Deserialize(fStream);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Can`t open filters file");
                return null;
            }
        }
    }
}
