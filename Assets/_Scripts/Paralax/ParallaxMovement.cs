using UnityEngine;

public class ParallaxMovement : MonoBehaviour 
{
    ScrollDirection direction;
    public float minSpeed = 0.2f;
    public float maxSpeed = 0.6f;
    private Vector3 speed;
    private float scrollValue;
    private float lastScrollValue;

    public enum BehaviourOnExit { Destroy, Regenerate };
    public BehaviourOnExit behaviourOnExit = BehaviourOnExit.Regenerate;

    Transform cameraTransform;

    public float limitOffScreen = 1f;

    private void Start () 
    {
        if(SpaceManager.instance != null)
            direction = SpaceManager.instance.scrollDirection;
        cameraTransform = Camera.main.transform;
        if (minSpeed > maxSpeed) Debug.LogError("The variable minSpeed cannot be greater than maxSpeed");
        switch (direction)
        {
            case ScrollDirection.LeftToRight:
                lastScrollValue = cameraTransform.position.x;
                speed = new Vector3(Random.Range(minSpeed, maxSpeed), 0f, 0f);
                break;
            case ScrollDirection.RightToLeft:
                lastScrollValue = cameraTransform.position.x;
                speed = new Vector3(-Random.Range(minSpeed, maxSpeed), 0f, 0f);
                break;
            case ScrollDirection.DownToUp:
                lastScrollValue = cameraTransform.position.y;
                speed = new Vector3(0f, -Random.Range(minSpeed, maxSpeed), 0f);
                break;
            case ScrollDirection.UpToDown:
                lastScrollValue = cameraTransform.position.y;
                speed = new Vector3(0f, Random.Range(minSpeed, maxSpeed), 0f);
                break;
        }
    }

    private void Regenerate()
    {
        switch (direction)
        {
            case ScrollDirection.LeftToRight:
                transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1f + limitOffScreen, Random.Range(0f, 1f), 10f));
                break;
            case ScrollDirection.RightToLeft:
                transform.position = Camera.main.ViewportToWorldPoint(new Vector3(-limitOffScreen, Random.Range(0f, 1f), 10f));
                break;
            case ScrollDirection.DownToUp:
                transform.position = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), 1f + limitOffScreen, 10f));
                break;
            case ScrollDirection.UpToDown:
                transform.position = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), -limitOffScreen, 10f));
                break;
        }
        RandomSize[] randomSizes = gameObject.GetComponentsInChildren<RandomSize>();
        RandomColor[] randomColors = gameObject.GetComponentsInChildren<RandomColor>();

        if (randomSizes != null) foreach (RandomSize r in randomSizes) r.Generate();
        if (randomColors != null) foreach (RandomColor r in randomColors) r.Generate();
    }
	
	private void Update () 
    {
        switch (direction)
        {
            case ScrollDirection.LeftToRight:
                scrollValue = cameraTransform.position.x - lastScrollValue;
                lastScrollValue = cameraTransform.position.x;
                break;
            case ScrollDirection.RightToLeft:
                scrollValue = -cameraTransform.position.x + lastScrollValue;
                lastScrollValue = cameraTransform.position.x;
                break;
            case ScrollDirection.DownToUp:
                scrollValue = -cameraTransform.position.y + lastScrollValue;
                lastScrollValue = cameraTransform.position.y;
                break;
            case ScrollDirection.UpToDown:
                scrollValue = cameraTransform.position.y - lastScrollValue;
                lastScrollValue = cameraTransform.position.y;
                break;
        }

        transform.position += speed * scrollValue;

        switch (direction)
        {
            case ScrollDirection.LeftToRight:
                if(Camera.main.WorldToViewportPoint(transform.position).x < -limitOffScreen)
                {
                    switch (behaviourOnExit)
                    {
                        case BehaviourOnExit.Destroy:
                            Destroy(gameObject);
                            break;
                        case BehaviourOnExit.Regenerate:
                            Regenerate();
                            break;
                    }
                }
                break;
            case ScrollDirection.RightToLeft:
                if (Camera.main.WorldToViewportPoint(transform.position).x > 1f + limitOffScreen)
                {
                    switch (behaviourOnExit)
                    {
                        case BehaviourOnExit.Destroy:
                            Destroy(gameObject);
                            break;
                        case BehaviourOnExit.Regenerate:
                            Regenerate();
                            break;
                    }
                }
                break;
            case ScrollDirection.DownToUp:
                if (Camera.main.WorldToViewportPoint(transform.position).y < -limitOffScreen)
                {
                    switch (behaviourOnExit)
                    {
                        case BehaviourOnExit.Destroy:
                            Destroy(gameObject);
                            break;
                        case BehaviourOnExit.Regenerate:
                            Regenerate();
                            break;
                    }
                }
                break;
            case ScrollDirection.UpToDown:
                if (Camera.main.WorldToViewportPoint(transform.position).y > 1f + limitOffScreen)
                {
                    switch (behaviourOnExit)
                    {
                        case BehaviourOnExit.Destroy:
                            Destroy(gameObject);
                            break;
                        case BehaviourOnExit.Regenerate:
                            Regenerate();
                            break;
                    }
                }
                break;
        }
    }
}
