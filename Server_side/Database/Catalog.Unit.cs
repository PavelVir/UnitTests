
using NUnit.Framework;
using A2v10.Data;
using A2v10.Data.Interfaces;

namespace Server_side.Database;

[TestFixture]
public partial class Catalog
{

    [Test]
    public async Task Unit_Index()
    {
        IDataModel dm = await _dbContext.LoadModelAsync(null, "[app].[Unit.Index]", new { UserId = 1 });
        var md = new MetadataTester(dm);
        md.IsAllKeys("TRoot,TUnit");
        md.IsItemType("TRoot", "Units", FieldType.Array);


        const string ObjectType = "TUnit";

        md.HasAllProperties(
           ObjectType,
           "Id,Name,Memo,Short,CodeUA,RowNo"
           );

        md.IsId(ObjectType, "Id");
        md.IsName(ObjectType, "Name");

     
    }
}