using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoretxt;

    private void Start()
    {
        scoretxt = transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void Score(int point)
    {

        score += point;

        scoretxt.text =  " Score : " + score.ToString();
        
    }

    public void Score(int point, bool booster)
    {

        if (booster)
        {
            score += point * 2;
        }
        else
        {
            score += point;
        }

        scoretxt.text = " Score : " + score.ToString();

    }
}
