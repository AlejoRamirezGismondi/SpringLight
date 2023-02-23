using System.Collections;
using UnityEngine;

namespace Puzzle5
{
    public class ThinIceManager : MonoBehaviour, IConditionalTeleportManager
    {
        [SerializeField] private GameObject target;
        private PlayerController _playerController;
        private ThinIce[] _thinIceList;
        private AnimationTransition failAnimation;

        private void Awake()
        {
            _thinIceList = FindObjectsOfType<ThinIce>();
            _playerController = FindObjectOfType<PlayerController>();
            failAnimation = FindObjectOfType<AnimationTransition>();
        }

        public void PlayerHasFallen(GameObject player)
        {
            failAnimation.StartAnimationTransition();
            StartCoroutine(Teleport(player));
        }

        private void ResetThinIce()
        {
            foreach (var thinIce in _thinIceList) thinIce.Reset();
        }
        
        private IEnumerator Teleport(GameObject player)
        {
            _playerController.DisableMovement();
            yield return new WaitForSeconds(0.01f);
            player.transform.position = target.transform.position;
            yield return new WaitForSeconds(0.5f);
            _playerController.EnableMovement();
            ResetThinIce();
        }

        public bool CheckWinConditions()
        {
            bool playerWon = true;
            foreach (var thinIce in _thinIceList)
                if (!thinIce.IsConsumed()) playerWon = false;
            return playerWon;
        }

        public void FailTeleported()
        {
            failAnimation.StartAnimationTransition();
            ResetThinIce();
        }

        public void SuccessTeleported()
        {
            ResetThinIce();
        }
    }
}
