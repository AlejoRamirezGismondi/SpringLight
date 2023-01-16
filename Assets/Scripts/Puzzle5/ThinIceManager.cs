using System.Collections;
using UnityEngine;

namespace Puzzle5
{
    public class ThinIceManager : MonoBehaviour
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
            foreach (var thinIce in _thinIceList) thinIce.Reset();
            StartCoroutine(Teleport(player));
        }
        
        private IEnumerator Teleport(GameObject player)
        {
            playerController.DisableMovement();
            yield return new WaitForSeconds(0.01f);
            player.transform.position = target.transform.position;
            yield return new WaitForSeconds(0.01f);
            playerController.EnableMovement();
        }
    }
}
