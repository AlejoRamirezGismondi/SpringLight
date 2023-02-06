using NUnit.Framework;
using Puzzle4;
using UnityEngine;

namespace Tests.PlayMode
{
    public class RotatingPuzzleTests
    {
        [Test]
        public void RotateTest()
        {
            var rotatingPuzzle = new GameObject();
            rotatingPuzzle.AddComponent<RotatingPuzzle>();
            rotatingPuzzle.GetComponent<RotatingPuzzle>().Rotate(3);
            // Use the Assert class to test conditions
            Assert.AreEqual(90, rotatingPuzzle.transform.rotation.eulerAngles.z);
        }
        
        [Test]
        public void RotateTimesTest()
        {
            var rotatingPuzzle = new GameObject();
            rotatingPuzzle.AddComponent<RotatingPuzzle>();
            rotatingPuzzle.GetComponent<RotatingPuzzle>().Rotate(2);
            // Use the Assert class to test conditions
            Assert.AreEqual(180, rotatingPuzzle.transform.rotation.eulerAngles.z);
        }
        
        [Test]
        public void IsUprightTest()
        {
            var rotatingPuzzle = new GameObject();
            rotatingPuzzle.AddComponent<RotatingPuzzle>();
            // Use the Assert class to test conditions
            Assert.AreEqual(true, rotatingPuzzle.GetComponent<RotatingPuzzle>().IsUpright());
        }
    }
}