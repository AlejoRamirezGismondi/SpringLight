using Items;
using NUnit.Framework;
using UnityEngine;

namespace Tests.PlayMode
{
    public class RewardsTests
    {
        [Test]
        public void RewardsTestSimplePasses()
        {
            var gameObject = new GameObject();
            var rewards = gameObject.AddComponent<Rewards>();
            var reward = new GameObject();
            reward.AddComponent<Item>();
            reward.transform.parent = rewards.transform;
            rewards.Awake();
            rewards.ShowRewards();
            // Use the Assert class to test conditions
            Assert.AreEqual(true, reward.gameObject.activeSelf);
        }
        
        [Test]
        public void RewardsTestSimplePasses2()
        {
            var gameObject = new GameObject();
            var rewards = gameObject.AddComponent<Rewards>();
            var reward = new GameObject();
            reward.AddComponent<Item>();
            reward.transform.parent = rewards.transform;
            rewards.Awake();
            rewards.HideRewards();
            // Use the Assert class to test conditions
            Assert.AreEqual(false, reward.gameObject.activeSelf);
        }
    }
}