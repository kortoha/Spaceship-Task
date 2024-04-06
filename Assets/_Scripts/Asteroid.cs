using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _moveSpeed;

    private void Update()
    {
        transform.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime);

        transform.Translate(Vector2.down * _moveSpeed * Time.deltaTime, Space.World);
    }
}
