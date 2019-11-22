using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageShake : MonoBehaviour
{
    [SerializeField]
    public Transform imageTransform;

    // How long the object should shake for.
    private float shakeDuration = 0.0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    private float shakeAmount = 5.0f;
    private float decreaseFactor = 1.0f;

    
    Vector3 originalPos;

    void Awake()
    {
        if (imageTransform == null)
        {
            imageTransform = GetComponentInParent<Transform>();
        }
    }

    void OnEnable()
    {
        originalPos = imageTransform.localPosition;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            imageTransform.localPosition = new Vector3(originalPos.x + Random.insideUnitCircle.x * shakeAmount, originalPos.y + Random.insideUnitCircle.y * shakeAmount, 0.0f) ;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            imageTransform.localPosition = originalPos;
        }
    }

    public void SetShake(float duration, float amount, float decreaseFactor)
    {
        this.shakeDuration = duration;
        this.shakeAmount = amount;
        this.decreaseFactor = decreaseFactor;
    }

    public void SetShakeAmount( float amount  )
    {
        this.shakeDuration = 1.0f;
        this.shakeAmount = amount;
        this.decreaseFactor = 0.0f;
    }
}