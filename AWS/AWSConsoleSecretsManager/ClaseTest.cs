using AWSConsoleSecretsManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSConsoleSecretsManager
{
    public class ClaseTest
    {
        private KeysModel keys;
        public ClaseTest(KeysModel keys)
        {
            this.keys = keys;
        }
        public string GetBucketValue()
        {
            return this.keys.Bucket;
        }
    }
}
