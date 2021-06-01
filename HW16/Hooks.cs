using System;
using Npgsql;
using TechTalk.SpecFlow;

namespace HW16
{
    [Binding]
    public class Hooks
    {
        private NpgsqlConnection _sqlConnection;
        
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario("DB")]
        public void BeforeScenario()
        {
            _sqlConnection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=Mabel123!;Database=Shop");
            _sqlConnection.Open();
            
            _scenarioContext.Add(Context.SqlConnection, _sqlConnection);
        }

        [AfterScenario("DB")]
        public void AfterScenario()
        {
            _scenarioContext.Get<NpgsqlConnection>(Context.SqlConnection).Close();
        }
    }
}