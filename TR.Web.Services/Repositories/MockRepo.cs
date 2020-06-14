using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TR.Web.Models.Models;
using TR.Web.Services.Interfaces;

namespace TR.Web.Services.Repositories
{
    public class MockRepo : IRepo
    {
        private List<TestObject> _testObj;

        public MockRepo()
        {
            _testObj = new List<TestObject>()
            {
                new TestObject
                {
                    Val = 1,
                    Str = "one"
                },
                new TestObject
                {
                    Val = 2,
                    Str = "two"
                },
            };
        }

        public TestObject GetObjById(string s)
        {
            return _testObj.FirstOrDefault(el => el.Str == s);
        }

        public IEnumerable<TestObject> GetTestData()
        {
            return _testObj;
        }
    }
}
