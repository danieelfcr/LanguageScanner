using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Scanner.ExpressionTree
{
    public class Follow
    {
        public string symbol { get; set; }

        public List<int> followList { get; set; }
        public Follow(string symbol)
        {
            this.symbol = symbol;
            followList = new List<int>();
        }
        public void insertFollow(int follow)
        {
            if (!followList.Contains(follow))
            {
                followList.Add(follow);
                followList.Sort();
            }
        }

    }
}
