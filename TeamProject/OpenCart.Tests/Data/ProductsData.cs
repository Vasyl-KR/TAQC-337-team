using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Data
{
    public class ProductsData
    {
        public static ProductsList GetProductData()
        {
            string folderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace("\\bin\\Debug", "\\Data");
            string path = Path.Combine(folderPath, "SearchProducts.json");
            string productsData;

            using (StreamReader reader = new StreamReader(path))
            {
                productsData = reader.ReadToEnd();
            }

            ProductsList products = JsonConvert.DeserializeObject<ProductsList>(productsData);
            return products;
        }
    }

    public struct Products
    {
        public string SearchMainAcer { get; set; }
        public string SearchCriteria { get; set; }
        public string SearchDescription { get; set; }
        public string SearchCategory { get; set; }
        public string SearchSubcategory { get; set; }
        public string SearchDefault { get; set; }
        public string SearchAZNameSort { get; set; }
        public string SearchLowHighPriceSort { get; set; }
        public string SearchZAModelSort { get; set; }
        public string SearchZAModelSortShow50 { get; set; }
        public string SearchTypeList { get; set; }
        public string SearchTypeGrid { get; set; }
    }

    public struct ProductsList
    {
        public Products Products { get; set; }
    }
}
