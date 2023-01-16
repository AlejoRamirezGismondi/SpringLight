using System.Collections;
using UnityEngine;

namespace Puzzle5
{
    public class ThinIceManager : MonoBehaviour, IConditionalTeleportManager
    {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private GameObject target;
        private ThinIce[] _thinIceList;

        private void Start()
        {
            _thinIceList = FindObjectsOfType<ThinIce>();
        }

        public void PlayerHasFallen(GameObject player)
        {
            ResetThinIce();
            StartCoroutine(Teleport(player));
        }

        private void ResetThinIce()
        {
            foreach (var thinIce in _thinIceList) thinIce.Reset();
        }
        
        private IEnumerator Teleport(GameObject player)
        {
            playerController.DisableMovement();
            yield return new WaitForSeconds(0.01f);
            player.transform.position = target.transform.position;
            yield return new WaitForSeconds(0.01f);
            playerController.EnableMovement();
        }

        public bool CanTeleport()
        {
            bool canTeleport = true;
            foreach (var thinIce in _thinIceList)
                if (!thinIce.IsConsumed()) canTeleport = false;
            return canTeleport;
        }

        public void FailTeleported()
        {
            ResetThinIce();
        }

        public void SuccessTeleported()
        {
            ResetThinIce();
        }
    }
}
