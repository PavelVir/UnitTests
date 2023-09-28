
using NUnit.Framework;
using A2v10.Data;
using A2v10.Data.Interfaces;

namespace Server_side.Database
{
    [TestFixture]
    public partial class Catalog
    {

        [Test]
        public async Task Resource_Index()
        {
            IDataModel dm = await _dbContext.LoadModelAsync(null, "[app].[Resource.Index]", new { UserId = 1 });
            var md = new MetadataTester(dm);
            md.IsAllKeys("TRoot,TResource,TResourceType,TResource_Group,TUnit");
            md.IsItemType("TRoot", "Resources", FieldType.Array);
            md.IsItemType("TRoot", "ResourceTypes", FieldType.Array);
            md.IsItemType("TRoot", "Resource_Groups", FieldType.Array);

            const string ObjectType = "TResource";

            md.HasAllProperties(
               ObjectType,
               "Id,Name,ResourceType,Resource_Group,Unit,FullName,Key,Laboriousness,Memo,ExternalCode,$Icon"
               );

            md.IsId(ObjectType, "Id");
            md.IsName(ObjectType, "Name");

            md.IsItemType(ObjectType, "ResourceType", FieldType.Object);
            md.IsItemType(ObjectType, "Resource_Group", FieldType.Object);
            md.IsItemType(ObjectType, "Unit", FieldType.Object);
           
        }
    }

}