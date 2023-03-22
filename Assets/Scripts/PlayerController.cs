using System.Collections;
using Interact;
using Inventory.Scripts;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private bool _isMoving;
    private bool _movementEnabled = true;

    private bool _wasMovingInX;
    private Vector2 _previousInput;
    private Vector2 _input;

    [SerializeField] private LayerMask whatStopsMovement;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject interactPoint;
    private InteractPoint _interactTarget;
    private InventoryComponent _inventory;
    private static readonly int MoveX = Animator.StringToHash("moveX");
    private static readonly int MoveY = Animator.StringToHash("moveY");
    private static readonly int IsMoving = Animator.StringToHash("isMoving");

    private void Start()
    {
        _wasMovingInX = false;
        _input = Vector2.zero;
        _previousInput = Vector2.zero;
        interactPoint = GameObject.FindGameObjectsWithTag("InteractPoint")[0];
        _interactTarget = interactPoint.GetComponent<InteractPoint>();
        _inventory = GetComponentInChildren<InventoryComponent>();
        StartCoroutine(StartMovement());
    }
    
    private IEnumerator StartMovement()
    {
        DisableMovement();
        yield return new WaitForSeconds(0.5f);
        EnableMovement();
    }

    private void Update()
    {
        if (!_movementEnabled) return;
        if (Input.GetKeyDown(KeyCode.E)) _interactTarget.Interact();
        CheckForScrollWheel();
        CheckForNumbers();
        if (_isMoving) return;
        _input.x = Input.GetAxisRaw("Horizontal");
        _input.y = Input.GetAxisRaw("Vertical");

        if (_input == Vector2.zero)
        {
            anim.SetBool(IsMoving, false);
            return;
        }

        if (!_input.Equals(_previousInput))
        {
            interactPoint.transform.localPosition = _input.normalized;
            StartCoroutine(Rotate(_input));
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

        StartCoroutine(Move(targetPos));
    }

    // This method is called a coroutine. It always must return an IEnumerator and the return function is
    // called with yield return null. That will tell it to skip to the next frame. It can be used for processes
    // that need to stop and start independently of other parts of the code
    private IEnumerator Move(Vector3 targetPos)
    {
        _isMoving = true;
        anim.SetBool(IsMoving, true);
        AnimateMovement();

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon && _movementEnabled)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos;

        _isMoving = false;
    }

    private IEnumerator Rotate(Vector2 direction)
    {
        _isMoving = true;
        AnimateMovement();
        yield return new WaitForSeconds(0.1f);
        _isMoving = false;
        _previousInput = direction;
    }

    public void EnableMovement()
    {
        _movementEnabled = true;
    }
    
    public void DisableMovement()
    {
        _movementEnabled = false;
    }

    private void AnimateMovement()
    {
        anim.SetFloat(MoveX, _input.normalized.x);
        anim.SetFloat(MoveY, _input.normalized.y);
    }
    
    // This method checks for scrolling wheel input and calls the InventoryComponent's method to change the selected item
    private void CheckForScrollWheel()
    {
        if (Input.mouseScrollDelta.y < 0)
        {
            _inventory.NextSelectedItem();
        }
        else if (Input.mouseScrollDelta.y > 0)
        {
            _inventory.PreviousSelectedItem();
        }
    }

    // This method checks if any numbers from 1 to 9 are pressed and calls the InventoryComponent's method to change the selected item
    private void CheckForNumbers()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _inventory.SelectSlot(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _inventory.SelectSlot(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _inventory.SelectSlot(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _inventory.SelectSlot(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            _inventory.SelectSlot(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            _inventory.SelectSlot(5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            _inventory.SelectSlot(6);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            _inventory.SelectSlot(7);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            _inventory.SelectSlot(8);
        }
    }
}