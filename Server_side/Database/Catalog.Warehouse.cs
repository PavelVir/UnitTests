
using NUnit.Framework;
using A2v10.Data;
using A2v10.Data.Interfaces;
using OpenQA.Selenium.DevTools;

namespace Server_side.Database
{
    [TestFixture]
    public partial class Catalog
    {

        [Test]
        public async Task Warehouse_Index()
        {
            IDataModel dm = await _dbContext.LoadModelAsync(null, "[app].[warehouses.Index]", new { UserId = 1 });
            var md = new MetadataTester(dm);
            md.IsAllKeys("TRoot,TWarehouse,TProject,TAgent");
            md.IsItemType("TRoot", "Warehouses", FieldType.Array);


            const string ObjectType = "TWarehouse";

            md.HasAllProperties(
               ObjectType,
               "Id,Name,Project,Agent,Memo,IntegrationID"
               );

            md.IsId(ObjectType, "Id");
            md.IsName(ObjectType, "Name");

            md.IsItemType(ObjectType, "Project", FieldType.Object);
            md.IsItemType(ObjectType, "Agent", FieldType.Object);

            md.HasAllProperties(
                            "TProject",
                            "Id,Name");

            md.IsId("TProject", "Id");

            md.HasAllProperties(
                            "TAgent",
                            "Id,Name");

            md.IsId("TProject", "Id");
        }
    }

}