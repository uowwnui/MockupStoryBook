using UnityEngine;

public class MoveToTargetAndStop : MonoBehaviour
{
    [SerializeField] private Vector3 moveStep = Vector3.right * 25f;
    [SerializeField] private Vector3 offset = Vector3.zero;
    [SerializeField] private float moveSpeed = 5.0f; // Speed of movement

    private bool isMoving = false;
    private Vector3 _currentPosition = Vector3.zero;
    private Vector3 _targetPosition = Vector3.zero;

    public void MoveRight()
    {
        isMoving = true;
        _targetPosition = _currentPosition + moveStep + offset;
    }

    public void MoveLeft()
    {
        isMoving = true;
        _targetPosition = _currentPosition - moveStep + offset;
    }

    private void Update()
    {
        UpdateController();
        UpdateMove();
    }

    private void UpdateController()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            MoveRight();
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
    }

    private void UpdateMove()
    {
        if (isMoving == false)
        {
            return;
        }

        // Calculate the distance to the target
        float distanceToTarget = (transform.position - _targetPosition).sqrMagnitude;

        // Move towards the target using Lerp
        transform.position = Vector3.Lerp(transform.position, _targetPosition, moveSpeed * Time.deltaTime / distanceToTarget);

        // Check if we are close enough to the target (you can adjust the threshold as needed)
        if (distanceToTarget < 0.1f)
        {
            // Stop moving when close to the target
            isMoving = false;
            _currentPosition = _targetPosition - offset;
        }
    }
}
