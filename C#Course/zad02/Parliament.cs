using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace C_Course.zad02
{
    public delegate void Notify();

    class Parliament
    {
        //Parliaments listens to parliamentalists to count votes for and against
        public List<Parliamentalist> Parliamentalists { get; set; }
        event Notify? VoteStart;
        event Notify? VoteEnd;
        string? _lastVoteSubject;
        int _lastVoteFor;
        int _lastVoteAgainst;


        public Parliament(int parliamentalistCount)
        {
            Parliamentalists = [];
            for (int i = 0; i < parliamentalistCount; i++)
            {
                Parliamentalist parliamentalist = new(RegisterVote);
                Parliamentalists.Add(parliamentalist);
                VoteStart += parliamentalist.StartVoting;
                VoteEnd += parliamentalist.EndVoting;
            }
        }

        void RegisterVote(object? sender, VoteArgs e)
        {
            if (e.Result)
                _lastVoteFor++;
            else _lastVoteAgainst++;
        }

        void OnVoteStarted()
        {
            VoteStart?.Invoke();
        }

        public void StartVoting(string subject)
        {
            _lastVoteSubject = subject;
            _lastVoteAgainst = 0;
            _lastVoteFor = 0;
            OnVoteStarted();
        }

        void OnVoteEnded()
        {
            VoteEnd?.Invoke();
        }
        public void EndVoting()
        {
            OnVoteEnded();
        }
        public void ShowResults()
        {
            Console.WriteLine($"Vote subject: {_lastVoteSubject}\nVotes for: {_lastVoteFor}\nVotes against: {_lastVoteAgainst}");
        }
    }

    class VoteArgs : EventArgs
    {
        public bool Result { get; set; }
    }
}
