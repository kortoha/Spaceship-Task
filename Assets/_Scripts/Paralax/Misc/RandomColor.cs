using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RandomColor : MonoBehaviour 
{
	SpriteRenderer spriteRenderer;
	public Color[] colors;

    [Range(0.0f, 100.0f)]
    public int invisibleProbability = 30;

	private void Start () {
        spriteRenderer = GetComponent<SpriteRenderer> ();
        Generate();
	}

	public void Generate(){
		if (invisibleProbability > 0 && Random.Range (0, 100) < invisibleProbability) {
            spriteRenderer.color = Color.clear;
			return;
		}
		int colorSelected = Random.Range (0, colors.Length);
		if (colors.Length > 0) {
            spriteRenderer.color = colors[colorSelected];
		}
	}
}
