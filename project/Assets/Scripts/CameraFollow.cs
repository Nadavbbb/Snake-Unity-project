using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public bool isCustomOffset;
    public Vector3 offset;

    public float smoothSpeed = 0.01f;
    // עוקב אחרי התנועות של נחש
    // מחשב את הזווית שצריכה להיות בין המצלמה לאובייקט(הנחש)
    // ככל שהתנועות יהיו חלקות יותר כך המשחק ירגיש כאילו הוא זז לאט יותר
    private void Start()
    {
        if (!isCustomOffset)
        {
            offset = transform.position - target.position;
        }
    }

    private void LateUpdate()
    {
        SmoothFollow();   
    }

    public void SmoothFollow()
    {
        Vector3 targetPos = target.position + offset;
        Vector3 smoothFollow = Vector3.Lerp(transform.position,
        targetPos, smoothSpeed);

        transform.position = smoothFollow;
        transform.LookAt(target);
    }
}