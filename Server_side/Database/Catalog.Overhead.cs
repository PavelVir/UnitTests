
using NUnit.Framework;
using A2v10.Data;
using A2v10.Data.Interfaces;

namespace Server_side.Database;

[TestFixture]
public partial class Catalog
{

    [Test]
    public async Task Overhead_Index()
    {
        IDataModel dm = await _dbContext.LoadModelAsync(null, "[app].[Overhead.Index]", new { UserId = 1 });
        var md = new MetadataTester(dm);
        md.IsAllKeys("TRoot,TOverhead,TOverhead_Group,TOverhead_Method,TOverhead_Type");
        md.IsItemType("TRoot", "Overheads", FieldType.Array);

        const string ObjectType = "TOverhead";

        md.HasAllProperties(
           ObjectType,
           "Id,Name,Overhead_Group,Overhead_Method,Overhead_Type,"+
           "Application_area,Base_IND,Base_MASH,Base_OB,Base_OH1,Base_OH2, Base_OZP, Base_PZ, Base_SP, Base_ZM, Baze_MAT,"+
           "OValue,Value,Memo"
           );

        md.IsId(ObjectType, "Id");
        md.IsName(ObjectType, "Name");

        md.IsItemType(ObjectType, "Overhead_Group", FieldType.Object);
        md.IsItemType(ObjectType, "Overhead_Method", FieldType.Object);
        md.IsItemType(ObjectType, "Overhead_Type", FieldType.Object);

        md.HasAllProperties(
                        "TOverhead_Group",
                        "Id,Name");

        md.IsId("TOverhead_Group", "Id"); 
        
        md.HasAllProperties(
                        "TOverhead_Method",
                        "Id,Name");

        md.IsId("TOverhead_Method", "Id"); 
        
        md.HasAllProperties(
                        "TOverhead_Type",
                        "Id,Name");

        md.IsId("TOverhead_Type", "Id");

      
    }
}