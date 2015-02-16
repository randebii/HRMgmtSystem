using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using HRMS.Framework;

namespace HRMS.UnitTests.SQLRepositoryTests
{
    public abstract class TestBase
    {
        protected IDbConnection conn;
        protected TestObjectFactory testObjects;

        static TestBase()
        {
            App app = new App();
            app.Init();
        }

        public TestBase()
        {
            testObjects = new TestObjectFactory();
        }

        protected IDbConnection GetOpenConnection()
        {
            var retVal = new SqlConnection(ConfigurationManager.AppSettings["SQLConnectionString"]);
            retVal.Open();
            return retVal;
        }

        [TestInitialize]
        public virtual void Init()
        {
            conn = GetOpenConnection();
            //CleanDatabase(conn);
        }

        [TestCleanup]
        public virtual void CleanUp()
        {
            CleanDatabase(conn);

            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
            }
        }

        private void CleanDatabase(IDbConnection conn)
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Execute(@"DELETE FROM Employees DBCC CHECKIDENT ('Employees',RESEED, 0)");
                conn.Execute(@"DELETE FROM Departments DBCC CHECKIDENT ('Departments',RESEED, 0)");
                conn.Execute(@"DELETE FROM Positions DBCC CHECKIDENT ('Positions',RESEED, 0)");
            }
        }
    }
}
