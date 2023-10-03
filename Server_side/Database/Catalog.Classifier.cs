
using NUnit.Framework;
using A2v10.Data;
using A2v10.Data.Interfaces;

namespace Server_side.Database;

[TestFixture]
public partial class Catalog
{

    [Test]
    public async Task Classifier_Index()
    {
        IDataModel dm = await _dbContext.LoadModelAsync(null, "[app].[Classifier.Index]", new { UserId = 1 });
        var md = new MetadataTester(dm);
        md.IsAllKeys("TRoot,TClassifier,TProject,TParam,TKind");
        md.IsItemType("TRoot", "Classifiers", FieldType.Array);
        md.IsItemType("TRoot", "Params", FieldType.Object);
        md.IsItemType("TRoot", "Kinds", FieldType.Map);

        const string ObjectType = "TClassifier";

        md.HasAllProperties(
           ObjectType,
           "Id,Name,Project,Kind,Memo,ExternalCode"
           );

        md.IsId(ObjectType, "Id");
        md.IsName(ObjectType, "Name");

        md.IsItemType(ObjectType, "Project", FieldType.Object);
        md.IsItemType(ObjectType, "Kind", FieldType.Object);

        md.HasAllProperties(
                        "TProject",
                        "Id,Name");

        md.IsId("TProject", "Id");

        md.HasAllProperties(
                       "TKind",
                       "Id,Name");
    }
}