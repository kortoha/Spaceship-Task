using UnityEngine;

public class Mover : MonoBehaviour 
{
    public float moveSpeed = 8f;
    private float currentScrollPosition = 0f;

	private void Start () 
    {
        switch (SpaceManager.instance.scrollDirection)
        {
            case ScrollDirection.LeftToRight:
            case ScrollDirection.RightToLeft:
                currentScrollPosition = transform.position.x / moveSpeed;
                break;
            case ScrollDirection.DownToUp: case ScrollDirection.UpToDown:
                currentScrollPosition = transform.position.y / moveSpeed;
                break;
        }
    }
	
	private void Update () 
    {
        currentScrollPosition += Time.deltaTime;
        Vector3 newPosition = Vector3.zero;
        switch (SpaceManager.instance.scrollDirection)
        {
            case ScrollDirection.LeftToRight:
                newPosition = new Vector3(Mathf.Lerp(transform.position.x, moveSpeed * currentScrollPosition, 1f * Time.deltaTime), transform.position.y, transform.position.z);
                break;
            case ScrollDirection.RightToLeft:
                newPosition = new Vector3(Mathf.Lerp(transform.position.x, -moveSpeed * currentScrollPosition, 1f * Time.deltaTime), transform.position.y, transform.position.z);
                break;
            case ScrollDirection.DownToUp:
                newPosition = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, moveSpeed * currentScrollPosition, 1f * Time.deltaTime), transform.position.z);
                break;
            case ScrollDirection.UpToDown:
                newPosition = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, -moveSpeed * currentScrollPosition, 1f * Time.deltaTime), transform.position.z);
                break;
        }
        transform.position = newPosition;

    }
}
