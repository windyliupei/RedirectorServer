using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SqlAccess
    {
        private string _connStr;
        public SqlAccess(string connection)
        {
            _connStr = connection;
        }

        public string GetEncryptKey(string macId)
        {
            using (EACDBContext context = new EACDBContext(_connStr))
            {
                var query = context.EncryptionKeys.Where(x => x.MacId == macId);

                if (query.Any())
                {
                    byte[] keyBytes = query.FirstOrDefault().EncryptionKey;

                    return System.Text.Encoding.UTF8.GetString(keyBytes);
                }
            }

            return string.Empty;
        }
    }
}
