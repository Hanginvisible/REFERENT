using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMCLIS.GATEWAY.CORE
{
    public class UIdGenerator
    {
        private static readonly Lazy<UIdGenerator> _lazy = new Lazy<UIdGenerator>(
            () => new UIdGenerator(), LazyThreadSafetyMode.ExecutionAndPublication);

        public static UIdGenerator Instance
        {
            get { return UIdGenerator._lazy.Value; }
        }

        private readonly Random _random = new Random();
        private readonly Dictionary<int, StringBuilder> _stringBuilders = new Dictionary<int, StringBuilder>();
        private const string CHARACTERS = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        private UIdGenerator()
        {
        }

        public string GenerateUId(int length)
        {
            StringBuilder result;
            if (!_stringBuilders.TryGetValue(length, out result))
            {
                result = new StringBuilder();
                _stringBuilders[length] = result;
            }

            result.Clear();

            for (int i = 0; i < length; i++)
            {
                result.Append(CHARACTERS[_random.Next(CHARACTERS.Length)]);
            }

            return result.ToString().ToUpper();
        }
    }
}
