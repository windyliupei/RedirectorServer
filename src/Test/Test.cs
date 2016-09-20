using DataAccess;
using System;
using Xunit;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void Test1()
        {
            SqlAccess access = new SqlAccess(RedirectorServer.AppSettingOptions.GetAppSetting().ConnectionSQL);
            var result = access.GetEncryptKey("00d02d23d2ae");
            Assert.True(result.Length > 0);
        }
    }
}
