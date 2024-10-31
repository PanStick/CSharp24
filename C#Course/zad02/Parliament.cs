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
        bool _voteInProgress;
        string? _lastVoteSubject;
        int _lastVoteFor;
        int _lastVoteAgainst;


        public Parliament(int parliamentalistCount)
        {
            _voteInProgress = false;
            Parliamentalists = [];
            for (int i = 0; i < parliamentalistCount; i++)
            {
                Parliamentalist parliamentalist = new(RegisterVote, i + 1);
                Parliamentalists.Add(parliamentalist);
                VoteStart += parliamentalist.StartVoting;
                VoteEnd += parliamentalist.EndVoting;
            }
        }

        void RegisterVote(object? sender, VoteArgs e)
        {
            Console.WriteLine("Glos parlamentarzysty nr " + e.Parliamentalist
                                + " to " + (e.Result == true ? "Za" : "Przeciw"));
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
            if (_voteInProgress)
            {
                Console.WriteLine("Trwa glosowanie nad " + _lastVoteSubject);
                return;
            }
            _lastVoteSubject = subject;
            _lastVoteAgainst = 0;
            _lastVoteFor = 0;
            _voteInProgress = true;
            OnVoteStarted();
        }

        void OnVoteEnded()
        {
            VoteEnd?.Invoke();
        }
        public void EndVoting()
        {
            _voteInProgress = false;
            OnVoteEnded();
            ShowResults();
        }
        void ShowResults()
        {
            Console.WriteLine($"Temat obrad: {_lastVoteSubject}\nGlosow za: {_lastVoteFor}\nGlosow przeciwko: {_lastVoteAgainst}");
        }
    }

    class VoteArgs : EventArgs
    {
        public bool Result { get; set; }
        public int Parliamentalist { get; set; }
    }
}
