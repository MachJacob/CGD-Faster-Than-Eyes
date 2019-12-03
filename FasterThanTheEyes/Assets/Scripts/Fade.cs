using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    CanvasGroup canvasGroup;
    public float transitionSmoothTime = 0.1f;
    private float targetAlpha = 0.1f;
    private bool transitioning = false;
    public bool loadScene = false;
    // Start is called before the first frame update
    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transitioning)
        {
            if(targetAlpha == 0.0f)
            {

                canvasGroup.alpha = targetAlpha;
                if (targetAlpha == 1)
                {
                    loadScene = true;
                }

                transitioning = false;
            }
            float diff = Mathf.Abs(canvasGroup.alpha - targetAlpha);
            float transitionRate = 0.0f;

            if (diff > 0.025f)
            {
                canvasGroup.alpha = Mathf.SmoothDamp(canvasGroup.alpha, targetAlpha, ref transitionRate, transitionSmoothTime);
                diff = Mathf.Abs(canvasGroup.alpha - targetAlpha);
            }
            else
            {
                canvasGroup.alpha = targetAlpha;
                if (targetAlpha == 1)
                {
                    loadScene = true;
                }
                if (targetAlpha == 0)
                    GetComponent<Canvas>().sortingOrder = 0;

                transitioning = false;
            }
        }
    }

    public void setFade(int targetAlpha)
    {
        if (transitioning)
            return;
        GetComponent<Canvas>().sortingOrder = 1;
        transitioning = true;
        this.targetAlpha = targetAlpha;
    }
}
