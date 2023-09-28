
using NUnit.Framework;
using A2v10.Data;
using A2v10.Data.Interfaces;

namespace Server_side.Database
{
    [TestFixture]
    public partial class Catalog
    {

        [Test]
        public async Task Nomenclature_Index()
        {
            IDataModel dm = await _dbContext.LoadModelAsync(null, "[app].[Nomenclature.Index]", new { UserId = 1 });
            var md = new MetadataTester(dm);
            md.IsAllKeys("TRoot,TNomenclature,TNomenclatureGroup,TUnit");
            md.IsItemType("TRoot", "Nomenclatures", FieldType.Array);
            md.IsItemType("TRoot", "NomenclatureGroups", FieldType.Array);


            const string ObjectType = "TNomenclature";

            md.HasAllProperties(
               ObjectType,
               "Id,Name,Unit,NomenclatureGroup,FullName,Memo,IntegrationID"
               );

            md.IsId(ObjectType, "Id");
            md.IsName(ObjectType, "Name");

            md.IsItemType(ObjectType, "NomenclatureGroup", FieldType.Object);

            md.HasAllProperties(
                            "TNomenclatureGroup",
                            "Id,Name");

            md.IsId("TNomenclatureGroup", "Id");

            /*
            String script = dm.CreateScript(_scripter);
            var pos = script.IndexOf("cmn.defineObject(TAgent, {props: {}}, true);");
            Assert.That(pos, Is.Not.EqualTo(-1), "Invalid script for TAgent");
            */
        }
    }

}