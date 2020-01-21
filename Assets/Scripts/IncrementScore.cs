using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncrementScore : MonoBehaviour
{
    private int totalScore;
    // Start is called before the first frame update
    void Start()
    {
        totalScore = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void incrementScore(int increment)
    {
        totalScore = totalScore + increment;
        GameObject.Find("ScoreText").GetComponent<UnityEngine.UI.Text>().text = "" + totalScore;
    }
}
