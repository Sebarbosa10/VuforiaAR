
using UnityEngine;

public class SmoothLogoMotion : MonoBehaviour
{
    public float bounceHeight = 0.08f;
    public float bounceSpeed = 2f;
    public float rotationSpeed = 30f;
    public float squashAmount = 0.04f;

    private Vector3 startPos;
    private Vector3 startScale;

    void Start()
    {
        startPos = transform.localPosition;
        startScale = transform.localScale;
    }

    void Update()
    {
        float wave = (Mathf.Sin(Time.time * bounceSpeed) + 1f) * 0.5f;
        float yOffset = wave * bounceHeight;

        transform.localPosition = startPos + new Vector3(0f, yOffset, 0f);
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);

        float squash = 1f - (wave < 0.1f ? squashAmount : 0f);
        float stretch = 1f + (wave < 0.1f ? squashAmount * 0.5f : 0f);

        transform.localScale = new Vector3(
            startScale.x * stretch,
            startScale.y * squash,
            startScale.z * stretch
        );
    }
}