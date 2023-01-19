using System;
using UnityEngine;

namespace Puzzle2
{
    public class SwitchPuzzleManager : MonoBehaviour
    {
        private SwitchPuzzle[] _puzzles;
        private Rewards _rewards;

        private void Awake()
        {
            _rewards = FindObjectOfType<Rewards>();
            _puzzles = GetComponentsInChildren<SwitchPuzzle>();
            // Sort puzzles by name
            Array.Sort(_puzzles, (a, b) => String.Compare(a.name, b.name, StringComparison.Ordinal));
        }

        // Start is called before the first frame update
        void Start()
        {
            for (var i = 0; i < _puzzles.Length; i++) if (i % 2 == 0) _puzzles[i].Activate();
        }

        public void SwitchWasFlipped()
        {
            var isSolved = true;
            foreach (var puzzle in _puzzles) if (!puzzle.IsActivated()) isSolved = false;
            if (isSolved) _rewards.ShowRewards();
        }
    }
}
