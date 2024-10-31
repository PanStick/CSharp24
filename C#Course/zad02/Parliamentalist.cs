using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Course.zad02
{
    class Parliamentalist(EventHandler<VoteArgs> ReturnVote, int parliamentalistNumber)
    {
        readonly EventHandler<VoteArgs> ReturnVote = ReturnVote;
        bool _votePossible = false;
        int _parliamentalistNumber = parliamentalistNumber;

        public void StartVoting() { _votePossible = true; }

        public void Vote()
        {
            //Console.WriteLine("Parliamentalist voting");
            if (_votePossible)
            {
                int voteResult = new Random().Next(2);
                ReturnVote?.Invoke(this, new VoteArgs()
                {
                    Result = Convert.ToBoolean(voteResult),
                    Parliamentalist = _parliamentalistNumber
                }
                );
                _votePossible = false;
            }
            else Console.WriteLine("Glos nie jest mozliwy");
        }
        public void EndVoting() { _votePossible = false; }

    }
}
