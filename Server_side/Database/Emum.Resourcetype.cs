
using NUnit.Framework;
using A2v10.Data;
using A2v10.Data.Interfaces;

namespace Server_side.Database
{
    [TestFixture]
    public partial class Catalog
    {

        [Test]
        public async Task Resourcetype_Index()
        {
            IDataModel dm = await _dbContext.LoadModelAsync(null, "[enum].[resourcetype.Index]", new { UserId = 1 });
            var md = new MetadataTester(dm);
            md.IsAllKeys("TRoot,TResourceType");
            md.IsItemType("TRoot", "ResourceTypes", FieldType.Array);


            const string ObjectType = "TResourceType";

            md.HasAllProperties(
               ObjectType,
               "Id,Name,Memo,SubType"
               );

            md.IsId(ObjectType, "Id");
            md.IsName(ObjectType, "Name");

         
        }
    }

}