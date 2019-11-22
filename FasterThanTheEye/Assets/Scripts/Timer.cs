using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private ImagePulse imagePulse;

    public Text timerText; 
    [SerializeField]
    public float counter = 99.0f;
    private int counterInt;
    // Start is called before the first frame update
    void Awake()
    {
        imagePulse = GetComponent<ImagePulse>();
        timerText = GetComponent<Text>();
        counterInt = (int)counter;
        timerText.text = counterInt.ToString();
    }

    // Update is called once per frame
    public void UpdateTimer()
    {
        counter -= Time.deltaTime;
        if (counter < 0.0f)
        {
            timerText.color = new Color(233.0f, 232.0f, 0.0f, 1.0f);
            counter = 0.0f;
        }
       if(counterInt != (int)counter)
        {
            counterInt = (int)counter;
            switch (counterInt)
            {
                case 10:

                    //play countdown sound
                    timerText.color = new Color( 1.0f, 200.0f / 255.0f, 0.0f, 1.0f);
                    imagePulse.SetPulse(1.0f, 0.5f, 1.0f);
                    break;
                case 9:
                    //play countdown sound
                    timerText.color = new Color(1.0f, 150.0f / 255.0f, 0.0f, 1.0f);
                    imagePulse.SetPulse(1.0f, 0.8f, 1.0f);
                    break;
                case 8:
                    //play countdown sound
                    timerText.color = new Color(1.0f, 100.0f / 255.0f, 0.0f, 1.0f);
                    imagePulse.SetPulse(1.0f, 1.1f, 1.0f);
                    break;
                case 7:
                    //play countdown sound
                    timerText.color = new Color(1.0f, 50.0f / 255.0f, 0.0f, 1.0f);
                    imagePulse.SetPulse(1.0f, 1.4f, 1.0f);
                    break;
                case 6:
                    //play countdown sound
                    timerText.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                    imagePulse.SetPulse(1.0f, 1.7f, 1.0f);
                    break;
                case 5:
                    //play countdown sound
                    imagePulse.SetPulse(1.0f, 2.0f, 1.0f);
                    break;
                case 4:
                    //play countdown sound
                    imagePulse.SetPulse(1.0f, 2.3f, 1.0f);
                    break;
                case 3:
                    //play countdown sound
                    imagePulse.SetPulse(1.0f, 2.6f, 1.0f);
                    break;
                case 2:
                    //play countdown sound
                    imagePulse.SetPulse(1.0f, 2.9f, 1.0f);
                    break;
                case 1:
                    //play countdown sound
                    imagePulse.SetPulse(1.0f, 3.2f, 1.0f);
                    break;
                default:
                    break;
            }
        }
        timerText.text = counterInt.ToString();
    }
    public void SetTimer(float seconds)
    {
        counter = seconds;
    }

    public float GetCounter()
    {
        return counter;
    }
}
