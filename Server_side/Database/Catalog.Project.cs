
using NUnit.Framework;
using A2v10.Data;
using A2v10.Data.Interfaces;
using System.Xml.Linq;
using A2v10.Xaml;
using System.Dynamic;
using System.Runtime.InteropServices.JavaScript;
using System.Transactions;

namespace Server_side.Database;

[TestFixture]
public partial class Catalog
{
    [Test]
    public async Task Project_Index()
    {
        IDataModel dm = await _dbContext.LoadModelAsync(null, "[app].[Project.Index]", new { UserId = 1 });
        var md = new MetadataTester(dm);
        md.IsAllKeys("TRoot,TProject,TProjectGroup,TAgent,TPricetype");
        md.IsItemType("TRoot", "Projects", FieldType.Array);
        md.IsItemType("TRoot", "ProjectGroups", FieldType.Array);


        const string ObjectType = "TProject";

        md.HasAllProperties(
           ObjectType,
           "Id,Name,ProjectGroup,FullName,Code,IsActive,Memo,Customer," +
           "General_constractor,IsSales_Resource_method,ExternalCode,Pricetype_Cost,Pricetype_Selling"
           );

        md.IsId(ObjectType, "Id");
        md.IsName(ObjectType, "Name");

        md.IsItemType(ObjectType, "ProjectGroup", FieldType.Object);
        md.IsItemType(ObjectType, "Customer", FieldType.Object);
        md.IsItemType(ObjectType, "General_constractor", FieldType.Object);
        md.IsItemType(ObjectType, "Pricetype_Cost", FieldType.Object);
        md.IsItemType(ObjectType, "Pricetype_Selling", FieldType.Object);

        md.HasAllProperties("TProjectGroup", "Id,Name");

        md.IsId("TProjectGroup", "Id");

        /*
        String script = dm.CreateScript(_scripter);
        var pos = script.IndexOf("cmn.defineObject(TAgent, {props: {}}, true);");
        Assert.That(pos, Is.Not.EqualTo(-1), "Invalid script for TAgent");
        */
    }

    [Test]
    public async Task Project_Load()
    {
        IDataModel dm = await _dbContext.LoadModelAsync(null, "[app].[Project.Load]", new { UserId = 1, Id = 1 });
        var md = new MetadataTester(dm);
        md.IsAllKeys("TRoot,TProject,TProjectGroup,TAgent,TPricetype,TUser,TAttachments");
        md.IsItemType("TRoot", "Project", FieldType.Object);

        const string ObjectType = "TProject";

        md.HasAllProperties(
           ObjectType,
           "Id,Name,ProjectGroup,FullName,Code,IsActive,Memo,Customer," +
           "General_constractor,IsSales_Resource_method,ExternalCode,Pricetype_Cost,Pricetype_Selling," +
           "MainManager, Attachments"
           );

        md.IsId(ObjectType, "Id");
        md.IsName(ObjectType, "Name");

        md.IsItemType(ObjectType, "ProjectGroup", FieldType.Object);
        md.IsItemType(ObjectType, "Customer", FieldType.Object);
        md.IsItemType(ObjectType, "General_constractor", FieldType.Object);
        md.IsItemType(ObjectType, "Pricetype_Cost", FieldType.Object);
        md.IsItemType(ObjectType, "Pricetype_Selling", FieldType.Object);

        md.HasAllProperties("TProjectGroup", "Id,Name");
        md.HasAllProperties("TAgent", "Id,Name");
        md.HasAllProperties("TPricetype", "Id,Name");


    }

    [Test]
    public void Project_Update()
    {

        var AgentObject = new ExpandoObject();
        AgentObject.Set("Id", 1);
        AgentObject.Set("Name", "Basic project");
        AgentObject.Set("FullName", "Basic project");
        AgentObject.Set("IsActive", true);
        AgentObject.Set("Code", "0000001");
        AgentObject.Set("ExternalCode", "0000001");
        AgentObject.Set("Memo", "");
        AgentObject.Set("TenantId", 1);

        var RootObj = new ExpandoObject();
        RootObj.Set("Project", AgentObject);

        using (TransactionScope scope = new())
        {
            // no async in scope _dbContext.SaveModelAsync will not work
            IDataModel dm = _dbContext.SaveModel(null,
                "[app].[Project.Update]",
                RootObj,
                new { UserId = 1, TenantId = 1 });

            var md = new MetadataTester(dm);
            md.IsAllKeys("TRoot,TProject,TProjectGroup,TAgent,TPricetype,TUser,TAttachments");
            md.IsItemType("TRoot", "Project", FieldType.Object);

            const string ObjectType = "TProject";

            md.HasAllProperties(
               ObjectType,
               "Id,Name,ProjectGroup,FullName,Code,IsActive,Memo,Customer," +
               "General_constractor,IsSales_Resource_method,ExternalCode,Pricetype_Cost,Pricetype_Selling," +
               "MainManager,Attachments"
               );

            md.IsId(ObjectType, "Id");
            md.IsName(ObjectType, "Name");

            md.IsItemType(ObjectType, "ProjectGroup", FieldType.Object);
            md.IsItemType(ObjectType, "Customer", FieldType.Object);
            md.IsItemType(ObjectType, "General_constractor", FieldType.Object);
            md.IsItemType(ObjectType, "Pricetype_Cost", FieldType.Object);
            md.IsItemType(ObjectType, "Pricetype_Selling", FieldType.Object);

            md.HasAllProperties("TProjectGroup", "Id,Name");
            md.HasAllProperties("TAgent", "Id,Name");
            md.HasAllProperties("TPricetype", "Id,Name");
        };

    }

}