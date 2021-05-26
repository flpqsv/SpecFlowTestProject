using System.Collections.Generic;
using NUnit.Framework;
using System.Net.Security;
using System.Data.SqlClient;

namespace HW16
{
    public class Tests
    {
        private SqlHelper _sqlHelper;

        [SetUp]
        public void Setup()
        {
            _sqlHelper = new SqlHelper("Shop");
            _sqlHelper.OpenConnection();
        }

        [TearDown]
        public void TearDown()
        {
            //_sqlHelper.ExecuteNonQuery("delete from [Shop].[@public].[Products] where id = 23");
            _sqlHelper.CloseConnection();
        }

        [Test]
        public void Test1()
        {
            _sqlHelper.Insert("\"Products\"",
                new Dictionary<string, string> { { "Id", "23" }, { "Name", "'Test23'" }, { "Quantity", "234" } });
            var res = _sqlHelper.IsRowExistedInTable("\"Products\"",
                new Dictionary<string, string> { { "Id", "23" }, { "Name", "'Test23'" }, { "Quantity", "234" } });
            
            Assert.True(res);
        }
    }
}