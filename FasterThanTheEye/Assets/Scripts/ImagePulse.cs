using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagePulse : MonoBehaviour
{
    [SerializeField]
    public Transform imageTransform;

    // How long the object should shake for.
    private float pulseDuration = 0.0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    private float pulseAmount = 5.0f;
    private float decreaseFactor = 1.0f;

    public Vector3 originalScale;

    void Awake()
    {
        if (imageTransform == null)
        {
            imageTransform = GetComponentInParent<Transform>();
        }
        
    }

    void OnEnable()
    {
        originalScale = imageTransform.localScale;
    }

    void Update()
    {
        if (pulseDuration > 0)
        {
            float scale = Random.Range(0.5f, 1.5f);
            imageTransform.localScale = new Vector3(originalScale.x + scale * pulseAmount, originalScale.y + scale * pulseAmount, originalScale.z) ;

            pulseDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            pulseDuration = 0f;
            imageTransform.localScale = originalScale;
        }
    }

    public void SetPulse(float duration, float amount, float decreaseFactor)
    {
        this.pulseDuration = duration;
        this.pulseAmount = amount;
        this.decreaseFactor = decreaseFactor;
    }
}