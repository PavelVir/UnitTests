
using NUnit.Framework;
using A2v10.Data;
using A2v10.Data.Interfaces;

namespace Server_side.Database
{
    [TestFixture]
    public partial class Catalog
    {

        [Test]
        public async Task Resource_Group_Index()
        {
            IDataModel dm = await _dbContext.LoadModelAsync(null, "[app].[Resource_Group.Index]", new { UserId = 1 });
            var md = new MetadataTester(dm);
            md.IsAllKeys("TRoot,TResource_Group");
            md.IsItemType("TRoot", "Resource_Groups", FieldType.Array);


            const string ObjectType = "TResource_Group";

            md.HasAllProperties(
               ObjectType,
               "Id,Name,Memo"
               );

            md.IsId(ObjectType, "Id");
            md.IsName(ObjectType, "Name");

         
        }
    }

}