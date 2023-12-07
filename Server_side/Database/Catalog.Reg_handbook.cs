
using NUnit.Framework;
using A2v10.Data;
using A2v10.Data.Interfaces;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Server_side.Database;

[TestFixture]
public partial class Catalog
{

    [Test]
    public async Task Reg_handbook_Index()
    {
        IDataModel dm = await _dbContext.LoadModelAsync(null, "[app].[Reg_handbook.Index]", new { UserId = 1 });
        var md = new MetadataTester(dm);
        md.IsAllKeys("TRoot,TReg_handbook,TUnit,TResource,TReg_handbookgroup,TResourceType,TReg_rows");
        md.IsItemType("TRoot", "Reg_handbooks", FieldType.Array);
        md.IsItemType("TRoot", "ResourceTypes", FieldType.Array);
        md.IsItemType("TRoot", "Reg_handbookgroups", FieldType.Map);


        const string ObjectType = "TReg_handbook";

        md.HasAllProperties(
           ObjectType,
           "Id,Name,FullName,Memo,IsActive,Code,Unit,Rows,Reg_handbookgroup"
           );

        md.IsId(ObjectType, "Id");
        md.IsName(ObjectType, "Name");

        md.IsItemType(ObjectType, "Unit", FieldType.Object);
        md.IsItemType(ObjectType, "Rows", FieldType.Array);
        md.IsItemType(ObjectType, "Reg_handbookgroup", FieldType.Object);

        md.HasAllProperties(
                        "TUnit",
                        "Id,Name,Short");

        md.IsId("TUnit", "Id");

        md.HasAllProperties(
                       "TReg_handbookgroup",
                       "Id,Name");

        md.IsId("TReg_handbookgroup", "Id");

        md.HasAllProperties(
                       "TReg_rows",
                       "Id,RowNo,Resource,Consumption_rate,Price,Price1,Price2,Laboriousness,OverspendCoef");

        md.IsItemType("TReg_rows", "Resource", FieldType.Object);


    }
}