
using NUnit.Framework;
using A2v10.Infrastructure;
using Server_side.Configuration;
using A2v10.Data;
using A2v10.Data.Interfaces;

namespace Server_side.Database
{
    [TestFixture]
    public partial class Catalog
    {

        IDbContext _dbContext;
        IDataScripter _scripter;


        [SetUp]
        public void SetUp()
        {
            TestConfig.Start();
            _dbContext = ServiceLocator.Current.GetService<IDbContext>();
            _scripter = ServiceLocator.Current.GetService<IDataScripter>();
        }
    }
}