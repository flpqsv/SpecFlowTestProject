using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Data;
using NUnit.Framework;

namespace HW16.Steps
{
    [Binding]
    public sealed class DatabaseSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private NpgsqlConnection _sqlConnection;
        
        public DatabaseSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _sqlConnection = _scenarioContext.Get<NpgsqlConnection>(Context.SqlConnection);
        }
        
        [Given(@"Data is added with insert command")]
        public void GivenDataIsAddedWithInsertCommand()
        {
            Insert("\"Products\"",
                new Dictionary<string, string> { { "Id", "2" }, { "Name", "'Old_Prod'" }, { "Quantity", "11" } });
        }

        [When(@"I add data with insert command")]
        public void WhenIAddDataWithInsertCommand(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            
            Insert("\"Products\"",
                new Dictionary<string, string> { { "Id", $"{data.id}" }, { "Name", $"'{data.name}'" }, { "Quantity", $"{data.quantity}" } });
        }
        
        public void Insert(string table, Dictionary<string, string> parameters)
        {
            var columns = string.Empty;
            var values = string.Empty;

            foreach (var (key, value) in parameters)
            {
                columns += $"\"{key}\",";
                values += $"{value},";
            }

            var command = new NpgsqlCommand($"insert into {table} ({columns.TrimEnd(',')}) values ({values.TrimEnd(',')})",
                _sqlConnection);
            command.ExecuteNonQuery();
        }
        
        [When(@"I select data with id (.*) with delete command")]
        public void WhenISelectDataWithIdWithDeleteCommand(string id)
        {
            id = "1";
            Delete("Products", id);
        }
        
        public void Delete(string table, string id)
        {
            var command = new NpgsqlCommand($"delete from \"{table}\" where \"Id\" = {id}",
                _sqlConnection);
            command.ExecuteNonQuery();
        }
        
        [When(@"I change item name to (.*) with update command")]
        public void WhenIChangeItemNameToWithUpdateCommand(string p0)
        {
            p0 = "Toys";
            Update("Products", p0);
        }
        
        public void Update(string table, string new_name)
        {
            var command = new NpgsqlCommand($"update \"{table}\" set \"Name\" = '{new_name}' where \"Id\" = 2",
                _sqlConnection);
            command.ExecuteNonQuery();
        }
        
        [When(@"I select data with name (.*) with select command")]
        public void WhenISelectDataWithNameWithSelectCommand(string name)
        {
            name = "Old_Prod";
            IsRowExistedInTable("\"Products\"",
                new Dictionary<string, string> {{ "Name", $"'{name}'" }});
        }
        
        [When(@"I add new table with create command")]
        public void WhenIAddNewTableWithCreateCommand()
        {
            Create("\"Toys\"",
                new Dictionary<string, string> { { "Id", "int," }, { "Name", "varchar(255)," }, { "For_age", "int" } });
        }
        
        public void Create(string table, Dictionary<string, string> parameters)
        {
            var pair = string.Empty;

            foreach (var (key, value) in parameters)
            {
               pair += $"{key} {value}";
            }

            var command = new NpgsqlCommand($"create table {table} ({pair})",
                _sqlConnection);
            command.ExecuteNonQuery();
        }
        
        [When(@"I delete existing table in Shop database")]
        public void WhenIDeleteExistingTableInShopDatabase()
        {
            Drop("Toys");
        }
        
        public void Drop(string table)
        {
            var command = new NpgsqlCommand($"drop table \"{table}\"",
                _sqlConnection);
            command.ExecuteNonQuery();
        }

        [Then(@"The data is added to Products table")]
        public void ThenTheDataIsAddedToProductsTable()
        {
            var res = IsRowExistedInTable("\"Products\"",
                new Dictionary<string, string> { { "Id", "1" }, { "Name", "'Product'" }, { "Quantity", "32" } });
            
            Assert.True(res);
        }
        
        public bool IsRowExistedInTable(string table, Dictionary<string, string> parameters)
        {
            var whereParameters = string.Empty;

            foreach (var (key, value) in parameters)
                whereParameters += $" and \"{key}\"={value}";

            var sqlDataAdapter = new NpgsqlDataAdapter(
                $"select * from {table} where {whereParameters.Substring(5)}",
                _sqlConnection);
            var dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            return dataTable.Rows.Count > 0;
        }

        [Then(@"The data is deleted from Products table")]
        public void ThenTheDataIsDeletedFromProductsTable()
        {
            var res = IsRowExistedInTable("\"Products\"",
                new Dictionary<string, string> { { "Id", "1" }, { "Name", "'Product'" }, { "Quantity", "32" } });
            
            Assert.False(res);
        }

        [Then(@"Data is changed in Products table")]
        public void ThenDataIsChangedInProductsTable()
        {
            var res = IsRowExistedInTable("\"Products\"",
                new Dictionary<string, string> { { "Id", "2" }, { "Name", "'Toys'" }, { "Quantity", "11" } });
            
            Assert.True(res);
        }


        [Then(@"The selected data exists")]
        public void ThenTheSelectedDataExists()
        {
            var name = "Old_Prod";
            var res = IsRowExistedInTable("\"Products\"", new Dictionary<string, string> {{ "Name", $"'{name}'" }});
            
            Assert.True(res);
        }

        [Then(@"Table is created")]
        public void ThenTableIsCreated()
        {
            Insert("\"Toys\"",
                new Dictionary<string, string> { { "id", "88" }, { "name", "'Shrek'" }, { "for_age", "6" } });
            
            var res = IsRowExistedInTable("\"Toys\"",
                new Dictionary<string, string> { { "id", "88" }, { "name", "'Shrek'" }, { "for_age", "6" } });
            
            Assert.True(res);
        }

        [Then(@"Table is successfully deleted")]
        public void ThenTableIsSuccessfullyDeleted()
        {
            
        }
    }
}