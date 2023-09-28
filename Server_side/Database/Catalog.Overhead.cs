
using NUnit.Framework;
using A2v10.Data;
using A2v10.Data.Interfaces;

namespace Server_side.Database
{
    [TestFixture]
    public partial class Catalog
    {

        [Test]
        public async Task Overhead_Index()
        {
            IDataModel dm = await _dbContext.LoadModelAsync(null, "[app].[Overhead.Index]", new { UserId = 1 });
            var md = new MetadataTester(dm);
            md.IsAllKeys("TRoot,TOverhead,TOverhead_Group,TAgent,TPricetype");
            md.IsItemType("TRoot", "Overheads", FieldType.Array);
            md.IsItemType("TRoot", "OverheadGroups", FieldType.Array);


            const string ObjectType = "TOverhead";

            md.HasAllProperties(
               ObjectType,
               "Id,Name,OverheadGroup,FullName,Code,IsActive,Memo,Customer," +
               "General_constractor,IsSales_Resource_method,ExternalCode,Pricetype_Cost,Pricetype_Selling"
               );

            md.IsId(ObjectType, "Id");
            md.IsName(ObjectType, "Name");

            md.IsItemType(ObjectType, "OverheadGroup", FieldType.Object);
            md.IsItemType(ObjectType, "Customer", FieldType.Object);
            md.IsItemType(ObjectType, "General_constractor", FieldType.Object);
            md.IsItemType(ObjectType, "Pricetype_Cost", FieldType.Object);
            md.IsItemType(ObjectType, "Pricetype_Selling", FieldType.Object);

            md.HasAllProperties(
                            "TOverheadGroup",
                            "Id,Name");

            md.IsId("TOverheadGroup", "Id");

            /*
            String script = dm.CreateScript(_scripter);
            var pos = script.IndexOf("cmn.defineObject(TAgent, {props: {}}, true);");
            Assert.That(pos, Is.Not.EqualTo(-1), "Invalid script for TAgent");
            */
        }
    }

}