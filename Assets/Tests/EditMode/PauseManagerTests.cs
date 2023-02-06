using NUnit.Framework;
using UnityEngine;

namespace Tests.EditMode
{
    public class PauseManagerTests
    {
        [Test]
        public void PauseManagerTestSimplePasses()
        {
            PauseManager.Pause();
            Assert.IsTrue(PauseManager.IsPaused());
        }
        
        [Test]
        public void PauseManagerTestSimplePasses2()
        {
            PauseManager.Resume();
            Assert.IsFalse(PauseManager.IsPaused());
        }
        
        [Test]
        public void PauseManagerTestSimplePasses3()
        {
            PauseManager.Resume();
            PauseManager.Pause();
            Assert.IsTrue(PauseManager.IsPaused());
        }
        
        [Test]
        public void PauseManagerTestSimplePasses4()
        {
            PauseManager.Pause();
            PauseManager.Resume();
            Assert.IsFalse(PauseManager.IsPaused());
        }
        
        [Test]
        public void PauseManagerTestSimplePasses5()
        {
            PauseManager.Pause();
            PauseManager.Pause();
            Assert.IsTrue(PauseManager.IsPaused());
        }
        
        [Test]
        public void PauseManagerTestSimplePasses6()
        {
            PauseManager.Resume();
            PauseManager.Resume();
            Assert.IsFalse(PauseManager.IsPaused());
        }
        
        [Test]
        public void PauseManagerTestSimplePasses7()
        {
            PauseManager.Pause();
            Assert.AreEqual(Time.timeScale, 0f);
        }
        
        [Test]
        public void PauseManagerTestSimplePasses8()
        {
            PauseManager.Resume();
            Assert.AreEqual(Time.timeScale, 1f);
        }
    }
}