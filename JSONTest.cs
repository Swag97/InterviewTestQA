using System;
using Newtonsoft.Json;
using NUnit.Framework.Legacy;

namespace InterviewTestQA
{
    public class CostItem
    {
        // Define the properties that match the JSON structure
        /* "YearId": "2015",
         "GeoRegionId": 0,
         "CountryId": 0,
         "RegionId": 0,
         "SchemeId": 40,
         "SchmTypeId": 1,
         "Cost": 0.0000000*/

        public string? YearId { get; set; }
        public int GeoRegionId { get; set; }
        public int CountryId { get; set; }
        public int RegionId { get; set; }
        public int SchemeId { get; set; }
        public int SchmTypeId { get; set; }
        public decimal Cost { get; set; }

    }
    [TestFixture]
    public class JSONTest
    {

        private const string JsonFileName = "CostAnalysis.json";

        [Test]
        public void Test1()
        {
            
            // Ensure the file exists
            ClassicAssert.IsTrue(File.Exists(JsonFileName), "JSON file not found.");

            // Read and deserialize the JSON file
            string jsonContent = File.ReadAllText(JsonFileName);
            List<CostItem>? CostItems = JsonConvert.DeserializeObject<List<CostItem>>(jsonContent);

            // Assert the number of items
            ClassicAssert.IsNotNull(CostItems, "Deserialized list is null.");
            // ClassicAssert.AreEqual(53, CostItems.Count, message: "The list does not contain the expected number of items.");
            Assert.That(CostItems.Count, Is.EqualTo(53), "The list does not contain the expected number of items.");


            // Get the top item ordered by Cost descending
            var topItem = CostItems.OrderByDescending(c => c.Cost).FirstOrDefault();
            ClassicAssert.IsNotNull(topItem, "No top item found.");
            //ClassicAssert.AreEqual(0, topItem.CountryId, "Top item does not match expected CountryId.");
            Assert.That(topItem.CountryId, Is.EqualTo(0), "Top item does not match expected CountryId.");

            // Sum Cost for 2016
            var totalCost2016 = CostItems.Where(c => c.YearId == "2016").Sum(c => c.Cost);
            //ClassicAssert.AreEqual(77911.3744561m, totalCost2016, "Total cost for 2016 does not match expected value.");
            Assert.That(totalCost2016, Is.EqualTo(77911.3744561m), "Total cost for 2016 does not match expected value.");

        }
    }


}