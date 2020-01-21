using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class HandleSubmit : MonoBehaviour
{
    public string WORD = "";

    public int SCORE = 0;

    public ArrayList wordList;

    protected int potentialLetterScore;

    private void Start()
    {

        string line;

        wordList = new ArrayList();
        // Creates a StreamReader to iterate through the words list.
        StreamReader reader = new StreamReader("english3.txt", Encoding.Default);

        try
        {
            using (reader)
            {
                do
                {
                    line = reader.ReadLine();

                    if (line != null)
                    {
                        wordList.Add(line);
                    }
                }
                while (line != null);
                reader.Close();

            }
        }
        catch (IOException e)
        {
            print(e);
        }
    }

    // Checks to see if the word submitted is actually a word.
    // Handles this information accordingly.
    public void handleSubmit()
    {

        if (wordList.Contains(WORD))
        {
            GameObject.Find("_Manager").GetComponent<IncrementScore>().incrementScore(potentialLetterScore);
            SCORE += potentialLetterScore;
            potentialLetterScore = 0;
            WORD = "";
        }
        else
        {
            potentialLetterScore = 0;
            WORD = "";
        }


    }

    public void appendLetter(string l)
    {
        WORD += l;
        print(WORD);
    }

    public void addPotentialLetterScore(int currLetterScore)
    {
        potentialLetterScore += currLetterScore;
    }

    //void Awake()
    //{
    //    DontDestroyOnLoad(this.gameObject);
    //}

}
