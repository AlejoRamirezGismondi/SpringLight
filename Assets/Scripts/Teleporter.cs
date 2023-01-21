using System.Collections;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private PlayerController _playerController;

    private void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Player")) return;
        if (target != null && _playerController != null)
            StartCoroutine(Teleport(_playerController, target.transform.position));
        else
            Debug.LogError("No target or player controller assigned to teleporter");
    }

    public static IEnumerator Teleport(PlayerController player, Vector3 target)
    {
        player.DisableMovement();
        yield return new WaitForSeconds(0.05f);
        player.transform.position = target;
        yield return new WaitForSeconds(0.05f);
        player.EnableMovement();
    }
}
