using System.Collections;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private PlayerController playerController;
    
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Player")) return;
        if (target != null && playerController != null)
            StartCoroutine(Teleport(col));
        else
            Debug.LogError("No target or player controller assigned to teleporter");
    }

    private IEnumerator Teleport(Collider2D player)
    {
        playerController.DisableMovement();
        yield return new WaitForSeconds(0.01f);
        player.transform.position = target.transform.position;
        yield return new WaitForSeconds(0.01f);
        playerController.EnableMovement();
    }
}
