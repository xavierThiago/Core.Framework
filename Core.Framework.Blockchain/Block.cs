using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace Core.Framework.Blockchain
{
    public class Block
    {
        public int Index { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public string PreviousHash { get; set; }
        public string Hash { get; set; }
        public int Nonce { get; set; }
        public IList<object> Data { get; set; }

        public Block(DateTimeOffset timestamp, object data)
        {
            Index = 0;
            Timestamp = timestamp;
            PreviousHash = null;
            Nonce = 0;
            Data = new List<object> { data };
            Hash = CalculateHash();
        }

        public bool IsValid()
        {
            return Hash == CalculateHash();
        }

        public void CreateData(object data)
        {
            Data.Add(data);
            Hash = CalculateHash();
        }

        protected internal string CalculateHash()
        {
            SHA256 sHA256 = SHA256.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(
                $"{Timestamp}-{PreviousHash ?? ""}-{Nonce}-{JsonConvert.SerializeObject(Data)}");
            byte[] outputBytes = sHA256.ComputeHash(inputBytes);

            return Convert.ToBase64String(outputBytes);
        }

        protected internal void Mine(int difficulty)
        {
            var leadingZeros = new string('0', difficulty);

            while (Hash == null || Hash.Substring(0, difficulty) != leadingZeros)
            {
                Nonce++;
                Hash = CalculateHash();
            }
        }
    }
}
