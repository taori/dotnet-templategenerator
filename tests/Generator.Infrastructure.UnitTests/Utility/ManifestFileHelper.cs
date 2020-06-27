using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Generator.Infrastructure.UnitTests.Utility
{
    public class ManifestFileHelper
    {
        private readonly string _prefix;
        private readonly Assembly _assembly;

        public ManifestFileHelper(string prefix, Assembly assembly)
        {
            _prefix = prefix;
            _assembly = assembly;
        }

        public StreamReader GetStreamReader(string file, params string[] paths)
        {
            var prefix = _prefix.EndsWith(".") ? _prefix : _prefix + ".";
            var key = prefix + string.Join(".", paths) + $".{file}";
            var stream = _assembly.GetManifestResourceStream(key);
            if(stream == null)
                throw new KeyNotFoundException($"Key {key} not found.");
            
            return new StreamReader(stream, Encoding.UTF8);
        }
    }
}