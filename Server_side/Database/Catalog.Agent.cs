
using NUnit.Framework;
using A2v10.Data;
using A2v10.Data.Interfaces;

namespace Server_side.Database
{
    [TestFixture]
    public partial class Catalog
    {

        [Test]
        public async Task Agent_Index()
        {
            IDataModel dm = await _dbContext.LoadModelAsync(null, "[app].[Agent.Index]", new { UserId = 1 });
            var md = new MetadataTester(dm);
            md.IsAllKeys("TRoot,TAgent");
            md.IsItemType("TRoot", "Agents", FieldType.Array);

            const string ObjectType = "TAgent";

            md.HasAllProperties(
               ObjectType,
               "Id,Name,FullName,Memo,IsActive,ExternalCode,EDRPOU,IsOther,AgentType"
               );

            md.IsId(ObjectType, "Id");
            md.IsName(ObjectType, "Name");

        }
    }

}