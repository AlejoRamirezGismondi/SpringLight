using System.Linq;
using UnityEngine;

public class ConditionalTeleporter : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject failTarget;
    private PlayerController _playerController;
    private IConditionalTeleportManager _manager;

    private void Awake()
    {
        _manager = FindObjectsOfType<MonoBehaviour>().OfType<IConditionalTeleportManager>().First();
        _playerController = FindObjectOfType<PlayerController>();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Player")) return;
        if (target != null && _playerController != null && failTarget != null && _manager != null)
        {
            if (_manager.CheckWinConditions())
            {
                StartCoroutine(Teleporter.Teleport(_playerController, target.transform.position));
                _manager.SuccessTeleported();
            }
            else
            {
                StartCoroutine(Teleporter.Teleport(_playerController, failTarget.transform.position));
                _manager.FailTeleported();
            }
            
        }
        else
            Debug.LogError("Not all fields are set to the ConditionalTeleporter");
    }
}

public interface IConditionalTeleportManager
{
    public bool CheckWinConditions();
    
    public void FailTeleported();
    public void SuccessTeleported();
}
