using System.Collections.Generic;

namespace TreePathSumCalculator
{
    public interface IBinaryTreeValidator
    {
        bool IsTreeValid(List<int[]> tree);
    }

    public class BinaryTreeValidator : IBinaryTreeValidator
    {
        private readonly ILogger _logger;

        public BinaryTreeValidator(ILogger logger)
        {
            _logger = logger;
        }

        public bool IsTreeValid(List<int[]> tree)
        {
            for (int i = 0; i < tree.Count; i++)
            {
                if (tree[i].Length > i + 1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
