using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballsBulletCollision : MonoBehaviour
{
    public Transform[] lettersArray;
    public HexGrid hg;
    public string[] letters;
    private string currLetterString;
    private char currChar;
   // private Transform currLetter;

    public BulletHandler bullet;

    // Start is called before the first frame update
    void Start()
    {
        hg = gameObject.AddComponent(typeof(HexGrid)) as HexGrid;
        this.lettersArray = hg.getLetterArray();
        this.letters = new string[] {"a", "b", "c", "d", "e", "f", "g", "h", "i",
        "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x",
        "y", "z"};
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //int letterInt = 0;
        if (col.gameObject.tag == "Bullet")
        {
            currLetterString = this.name;
            setCurrLetter(currLetterString);

            // the bullet hasn't collided with any balls yet
            if (bullet.collided == false)
            {
                //letterInt = this.findIndexOfLetter(currLetter);
                Destroy(gameObject);

            }
            print(currLetterString);
            print(currChar);
            GameObject.Find("_Manager").GetComponent<HandleSubmit>().appendLetter(currChar.ToString());
           
        }
    }


    //int findIndexOfLetter(Transform letter)
    //{
    //    int letterInt = 0;
    //   // print(this.lettersArray.Length);
    //    for (int i = 0; i < this.lettersArray.Length; i++)
    //    {
    //        {
    //            if (this.lettersArray[i] == letter)
    //            {
    //                letterInt = i;
    //            }
    //        }
    //    }
    //    return letterInt;
    //}

    void setCurrLetter(string currLetterString)
    {
        switch(currLetterString)
        {
            case "A(Clone)":
                currChar = 'a';
                break;
            case "B(Clone)":
                currChar = 'b';
                break;
            case "C(Clone)":
                currChar = 'c';
                break;
            case "D(Clone)":
                currChar = 'd';
                break;
            case "E(Clone)":
                currChar = 'e';
                break;
            case "F(Clone)":
                currChar = 'f';
                break;
            case "G(Clone)":
                currChar = 'g';
                break;
            case "H(Clone)":
                currChar = 'h';
                break;
            case "I(Clone)":
                currChar = 'i';
                break;
            case "J(Clone)":
                currChar = 'j';
                break;
            case "K(Clone)":
                currChar = 'k';
                break;
            case "L(Clone)":
                currChar = 'l';
                break;
            case "M(Clone)":
                currChar = 'm';
                break;
            case "N(Clone)":
                currChar = 'n';
                break;
            case "O(Clone)":
                currChar = 'o';
                break;
            case "P(Clone)":
                currChar = 'p';
                break;
            case "Q(Clone)":
                currChar = 'q';
                break;
            case "R(Clone)":
                currChar = 'r';
                break;
            case "S(Clone)":
                currChar = 's';
                break;
            case "T(Clone)":
                currChar = 't';
                break;
            case "U(Clone)":
                currChar = 'u';
                break;
            case "V(Clone)":
                currChar = 'v';
                break;
            case "W(Clone)":
                currChar = 'w';
                break;
            case "X(Clone)":
                currChar = 'x';
                break;
            case "Y(Clone)":
                currChar = 'y';
                break;
            case "Z(Clone)":
                currChar = 'z';
                break;
            default:
                break;

        }
    }
}
