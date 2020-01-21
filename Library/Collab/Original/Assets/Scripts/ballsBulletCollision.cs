using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballsBulletCollision : MonoBehaviour
{
    public Transform[] lettersArray;
    public HexGrid hg;
    public string[] letters;

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
        int letterInt = 0;
        if (col.gameObject.tag == "Bullet")
        {
            // the bullet hasn't collided with any balls yet
            if (bullet.collided == false)
            {
                // should be this
                //letterInt = this.findIndexOfLetter(col);
                // should not be this:
                letterInt = 1;
                Destroy(gameObject);

            }
            GameObject.Find("_Manager").GetComponent<HandleSubmit>().appendLetter(letters[letterInt]);

           
        }
    }


    int findIndexOfLetter(Collision2D col)
    {
        int letterInt = 0;
        print(this.lettersArray.Length);
        for (int i = 0; i < this.lettersArray.Length; i++)
        {
            {
                if (this.lettersArray[i].Equals(col))
                {
                    letterInt = i;
                }
            }
        }
        return letterInt;
    }
}
