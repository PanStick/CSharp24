using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Course.zad02
{
    class Parliamentalist(EventHandler<VoteArgs> ReturnVote)
    {
        readonly EventHandler<VoteArgs> ReturnVote = ReturnVote;
        bool votePossible = false;

        public void StartVoting() { votePossible = true; }

        public void Vote()
        {
            //Console.WriteLine("Parliamentalist voting");
            if (votePossible)
            {
                int voteResult = new Random().Next(2);
                ReturnVote?.Invoke(this, new VoteArgs() { Result = Convert.ToBoolean(voteResult) });
            }
            else Console.WriteLine("Vote not possible");
        }
        public void EndVoting() { votePossible = false; }

    }
}
