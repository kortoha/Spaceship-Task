using UnityEngine;

public enum ScrollDirection { LeftToRight, RightToLeft, DownToUp, UpToDown };

public class SpaceManager : MonoBehaviour 
{
    public ScrollDirection scrollDirection = ScrollDirection.LeftToRight;
    private ScrollDirection direction;

    public static SpaceManager instance = null;

    void Start () 
    {
        direction = scrollDirection;
        instance = this;
    }
	
	void Update () 
    {
        if(direction != scrollDirection)
        {
            scrollDirection = direction;
        }
	}
}
