using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Framework.Blockchain
{
    public class Blockchain
    {
        public List<Block> Chain { get; private set; }

        public Blockchain()
        {
            InitializeChain();
        }

        void InitializeChain()
        {
            Chain = new List<Block>
            {
                new Block(DateTimeOffset.Now, "{}")
            };
        }

        public Block GetLatest()
        {
            return Chain[Chain.Count - 1];
        }

        public Block GetBlock(Func<Block, bool> predicate)
        {
            return Chain.SingleOrDefault(predicate);
        }

        public bool IsValid()
        {
            if (Chain.Count > 1)
            {
                for (int i = 1; i < Chain.Count; i++)
                {
                    Block currBlock = Chain[i];
                    Block prevBlock = Chain[i - 1];

                    if (currBlock.Hash != currBlock.CalculateHash())
                        return false;

                    if (currBlock.PreviousHash != prevBlock.Hash)
                        return false;
                }
            }

            return true;
        }

        public Block AddBlock(Block block)
        {
            Block latestBlock = GetLatest();
            block.Index = latestBlock.Index + 1;
            block.PreviousHash = latestBlock.Hash;
            block.Hash = block.CalculateHash();
            Chain.Add(block);

            return block;
        }

        public Block AddBlock(Block block, int difficulty)
        {
            Block latestBlock = GetLatest();
            block.Index = latestBlock.Index + 1;
            block.PreviousHash = latestBlock.Hash;
            block.Mine(difficulty);
            Chain.Add(block);

            return block;
        }
    }
}
