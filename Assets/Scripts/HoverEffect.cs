using UnityEngine;

public class HoverEffect : MonoBehaviour
{
    public float hoverScaleMultiplier = 1.2f;
    public float scaleSpeed = 5f;

    private Vector3 originalScale;
    private Vector3 targetScale;
    private bool isHovered = false;

    void Start()
    {
        originalScale = transform.localScale;
        targetScale = originalScale;
    }

    void OnMouseEnter()
    {
        isHovered = true;
        targetScale = originalScale * hoverScaleMultiplier;
    }

    void OnMouseExit()
    {
        isHovered = false;
        targetScale = originalScale;
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * scaleSpeed);
    }
}
