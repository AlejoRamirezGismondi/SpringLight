using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Puzzle4
{
    public class RotatingPuzzleManager : MonoBehaviour
    {
        private RotatingPuzzle[] _puzzles;
        private Rewards _rewards;

        private void Awake()
        {
            _rewards = FindObjectOfType<Rewards>();
            _puzzles = GetComponentsInChildren<RotatingPuzzle>();
            // Sort puzzles by name
            Array.Sort(_puzzles, (a, b) => String.Compare(a.name, b.name, StringComparison.Ordinal));
        }

        private void Start()
        {
            // Rotate all puzzles randomly. Can be rotated 0 times or 3 times (second parameter of range is exclusive)
            foreach (var puzzle in _puzzles) puzzle.Rotate(Random.Range(0, 4));
        }
        
        public void PuzzleWasRotated()
        {
            bool solved = true;
            // Check if all puzzles are upright
            foreach (var rotatingPuzzle in _puzzles)
                if (!rotatingPuzzle.IsUpright()) solved = false;
            if (solved) _rewards.ShowRewards();
        }
    }
}
