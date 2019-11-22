using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRound : MonoBehaviour
{
    //round objects
    public GameObject Round1Completed;
    public GameObject Round2Completed;
    public GameObject Round3Completed;
    public Timer RoundTimer;
    //current round
    public int RoundNumber;

    void Awake()
    {
        RoundNumber = 0;
    }

    //set the round
    void SetRoundSprites(string CurrentRound)
    {
        if (string.IsNullOrEmpty(CurrentRound))
        {
            throw new System.ArgumentException("NoInput", nameof(CurrentRound));
        }

        if (CurrentRound == "Round1Completed")
        {
            Round1Completed.SetActive(true);
        }

        if (CurrentRound == "Round2Completed")
        {
            Round2Completed.SetActive(true);
        }

        if (CurrentRound == "Round3Completed")
        {
            Round3Completed.SetActive(true);
        }

        if(CurrentRound == "Reset")
        {
            RoundNumber = 0;
            Round1Completed.SetActive(false);
            Round2Completed.SetActive(false);
            Round3Completed.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
            if (RoundNumber == 1)
            {
                SetRoundSprites("Round1Completed");
            }

            else if (RoundNumber == 2)
            {
                SetRoundSprites("Round2Completed");
            }

            else if (RoundNumber == 3)
            {
                SetRoundSprites("Round3Completed");
            }

            else if (RoundNumber > 4)
            {
                SetRoundSprites("Reset");
            }
    }
    public void IncrementRound()
    {
            RoundNumber++;
    }
}
