using System;
using System.Collections.Generic;
using System.Text;
using TR.Web.Models.Models;

namespace TR.Web.Services.Interfaces
{
    public interface IRepo
    {
        IEnumerable<TestObject> GetTestData();
        TestObject GetObjById(string s);
    }
}
