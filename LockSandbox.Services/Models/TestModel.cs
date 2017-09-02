using System;

namespace LockSandbox.Services.Models
{
    public class TestModel
    {
        public TestModel()
        {
            AccessToken = Guid.NewGuid().ToString();
        }

        public string AccessToken { get; }
    }
}