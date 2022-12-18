using System.Collections;
using Inventory.Scripts;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private bool _isMoving;

    private bool _wasMovingInX;
    private Vector2 _input;

    [SerializeField] private LayerMask whatStopsMovement;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject interactPoint;
    private InteractPoint _interactTarget;
    private InventoryComponent _inventory;
    private static readonly int MoveX = Animator.StringToHash("moveX");
    private static readonly int MoveY = Animator.StringToHash("moveY");
    private static readonly int isMoving = Animator.StringToHash("isMoving");

    private void Start()
    {
        _wasMovingInX = false;
        _input = Vector2.zero;
        interactPoint = GameObject.FindGameObjectsWithTag("InteractPoint")[0];
        _interactTarget = interactPoint.GetComponent<InteractPoint>();
        _inventory = GetComponentInChildren<InventoryComponent>();
    }

    private void Update()
    {
        if (_isMoving) return;
        if (Input.GetKeyDown(KeyCode.E)) _interactTarget.Interact();
        CheckForScrollWheel();
        _input.x = Input.GetAxisRaw("Horizontal");
        _input.y = Input.GetAxisRaw("Vertical");

        if (_input == Vector2.zero)
        {
            anim.SetBool(isMoving, false);
            return;
        }
        
        // Always accepts the new input. Cannot walk diagonally
        if ((_input.x != 0) && (_input.y != 0))
        {
            if (_wasMovingInX) _input.x = 0;
            else _input.y = 0;
        }

        _wasMovingInX = _input.x != 0;
        
        var targetPos = transform.position;

        // Checks whether the next movement is allowed or not (with the LayerMask)
        if (!Physics2D.OverlapCircle(targetPos + new Vector3(_input.x, _input.y, 0f),
                .2f, whatStopsMovement))
        {
            targetPos.x += _input.x;
            targetPos.y += _input.y;
        }

        interactPoint.transform.localPosition = _input.normalized;
        StartCoroutine(Move(targetPos));
    }

    // This method is called a coroutine. It always must return an IEnumerator and the return function is
    // called with yield return null. That will tell it to skip to the next frame. It can be used for processes
    // that need to stop and start independently of other parts of the code
    private IEnumerator Move(Vector3 targetPos)
    {
        _isMoving = true;
        anim.SetBool(isMoving, true);
        AnimateMovement();

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos;

        _isMoving = false;
    }

    private void AnimateMovement()
    {
        anim.SetFloat(MoveX, _input.normalized.x);
        anim.SetFloat(MoveY, _input.normalized.y);
    }
    
    // This method checks for scrolling wheel input and calls the InventoryComponent's method to change the selected item
    private void CheckForScrollWheel()
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            _inventory.NextSelectedItem();
        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            _inventory.PreviousSelectedItem();
        }
    }
}