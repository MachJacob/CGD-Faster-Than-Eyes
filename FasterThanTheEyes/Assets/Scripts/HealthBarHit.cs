using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBarHit : MonoBehaviour
{

    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Image>().fillAmount = 1.0f;
    }

    // Update is called once per frame
    public void UpdateHealthBarHit(float amount)
    {
        GetComponent<Image>().fillAmount = amount;
    }
}
