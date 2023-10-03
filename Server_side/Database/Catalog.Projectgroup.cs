
using NUnit.Framework;
using A2v10.Data;
using A2v10.Data.Interfaces;

namespace Server_side.Database;

[TestFixture]
public partial class Catalog
{

    [Test]
    public async Task ProjectGroup_Index()
    {
        IDataModel dm = await _dbContext.LoadModelAsync(null, "[app].[ProjectGroup.Index]", new { UserId = 1 });
        var md = new MetadataTester(dm);
        md.IsAllKeys("TRoot,TProjectGroup");
        md.IsItemType("TRoot", "ProjectGroups", FieldType.Array);


        const string ObjectType = "TProjectGroup";

        md.HasAllProperties(
           ObjectType,
           "Id,Name,Memo"
           );

        md.IsId(ObjectType, "Id");
        md.IsName(ObjectType, "Name");

     
    }
}