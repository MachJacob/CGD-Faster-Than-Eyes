using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public static PlayerScore playerScore;

    public int pScore = 100;

    [SerializeField]
    public static int pAmountTaken = 1;

    [SerializeField]
    public static int hitTaken = 5;

    [SerializeField]
    public static int hitCombo = 5;

    public static bool playing;

    // Start is called before the first frame update
    void Start()
    {
        playerScore = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(playing)
        {
            playing = false;
            StartCoroutine(Ticker());
        }



        //Debug.Log(playing);
    }

    public static void DecreaseScore()
    {
        playerScore.pScore -= hitTaken;
    }

    public static void IncreaseScore()
    {
        playerScore.pScore += hitCombo;
    }

    IEnumerator Ticker()
    {
        while (pScore > 0)
        {
            yield return new WaitForSeconds(5);
            pScore -= pAmountTaken;
            Debug.Log(pScore);
        }

        if(pScore <= 0)
        {
            //EndGame
        }

        yield return null;
    }
}
