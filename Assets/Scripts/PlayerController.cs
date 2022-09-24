using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private bool _isMoving;

    private Vector2 _input;

    [SerializeField] private LayerMask whatStopsMovement;

    private void Update()
    {
        if (!_isMoving)
        {
            _input.x = Input.GetAxisRaw("Horizontal");
            _input.y = Input.GetAxisRaw("Vertical");

            if (_input.x != 0) _input.y = 0;

            if (_input != Vector2.zero)
            {
                var targetPos = transform.position;

                // Checks whether the next movement is allowed or not (with the LayerMask)
                if (!Physics2D.OverlapCircle(targetPos + new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f), .2f,
                        whatStopsMovement))
                {
                    targetPos.x += _input.x;
                    targetPos.y += _input.y;
                }

                StartCoroutine(Move(targetPos));
            }
        }
    }

    // This method is called a coroutine. It always must return an IEnumerator and the return furction is
    // called with yield return null. That will tell it to skip to the next frame. It can be used for processes
    // that need to stop and start independently of other parts of the code
    IEnumerator Move(Vector3 targetPos)
    {
        _isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos;

        _isMoving = false;
    }
}