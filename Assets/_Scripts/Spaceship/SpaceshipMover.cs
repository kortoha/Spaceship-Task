using UnityEngine;

public class SpaceshipMover : MonoBehaviour
{
    [SerializeField] private Transform _leftBorder;
    [SerializeField] private Transform _rightBorder;

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 20f;

    private Vector2 _leftBorderPosition;
    private Vector2 _rightBorderPosition;

    private bool _isMoveLeft = false;
    private bool _isMoveRight = false;

    private float _currentSpeed = 0f;

    private void Start()
    {
        _leftBorderPosition = _leftBorder.position;
        _rightBorderPosition = _rightBorder.position;
    }

    private void Update()
    {
        if (_isMoveLeft && transform.position.x > _leftBorderPosition.x)
        {
            MoveShip(Vector3.left);
            RotateShip(Vector3.forward * 20f);

            _currentSpeed = Mathf.Lerp(_currentSpeed, _moveSpeed, Time.deltaTime);
        }
        else if (_isMoveRight && transform.position.x < _rightBorderPosition.x)
        {
            MoveShip(Vector3.right);
            RotateShip(Vector3.forward * -20f);

            _currentSpeed = Mathf.Lerp(_currentSpeed, _moveSpeed, Time.deltaTime);
        }
        else
        {
            RotateShip(Vector3.zero);
        }
    }

    public void MoveLeft()
    {
        _isMoveLeft = true;
    }

    public void MoveRight()
    {
        _isMoveRight = true;
    }

    public void NotMove()
    {
        _isMoveLeft = false;
        _isMoveRight = false;
        _currentSpeed = 0f;
    }

    private void MoveShip(Vector3 direction)
    {
        transform.Translate(direction * _currentSpeed * (Time.deltaTime * 3), Space.World);
    }

    private void RotateShip(Vector3 rotation)
    {
        Quaternion targetRotation = Quaternion.Euler(rotation);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }
}
