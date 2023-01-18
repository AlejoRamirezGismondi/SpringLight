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
            StartCoroutine(Teleport(col));
        else
            Debug.LogError("No target or player controller assigned to teleporter");
    }

    private IEnumerator Teleport(Collider2D player)
    {
        _playerController.DisableMovement();
        yield return new WaitForSeconds(0.01f);
        player.transform.position = target.transform.position;
        yield return new WaitForSeconds(0.01f);
        _playerController.EnableMovement();
    }
}
