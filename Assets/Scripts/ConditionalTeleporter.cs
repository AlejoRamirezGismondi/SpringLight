using System.Collections;
using System.Linq;
using UnityEngine;

public class ConditionalTeleporter : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject failTarget;
    private IConditionalTeleportManager _manager;

    private void Awake()
    {
        _manager = FindObjectsOfType<MonoBehaviour>().OfType<IConditionalTeleportManager>().First();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Player")) return;
        if (target != null && playerController != null && failTarget != null && _manager != null)
            StartCoroutine(Teleport(col));
        else
            Debug.LogError("Not all fields are set to the ConditionalTeleporter");
    }
    
    private IEnumerator Teleport(Collider2D player)
    {
        playerController.DisableMovement();
        yield return new WaitForSeconds(0.01f);
        if (_manager.CanTeleport())
        {
            player.transform.position = target.transform.position;
            _manager.SuccessTeleported();
        }
        else
        {
            player.transform.position = failTarget.transform.position;
            _manager.FailTeleported();
        }
        yield return new WaitForSeconds(0.01f);
        playerController.EnableMovement();
    }
}

public interface IConditionalTeleportManager
{
    public bool CanTeleport();
    
    public void FailTeleported();
    public void SuccessTeleported();
}
