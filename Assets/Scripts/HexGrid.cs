using UnityEngine;
using System.Collections;

public class HexGrid : MonoBehaviour
{
    public Transform A;
    public Transform B;
    public Transform C;
    public Transform D;
    public Transform E;
    public Transform F;
    public Transform G;
    public Transform H;
    public Transform I;
    public Transform J;
    public Transform K;
    public Transform L;
    public Transform M;
    public Transform N;
    public Transform O;
    public Transform P;
    public Transform Q;
    public Transform R;
    public Transform S;
    public Transform T;
    public Transform U;
    public Transform V;
    public Transform W;
    public Transform X; 
    public Transform Y;
    public Transform Z;

    public GameObject background;

    public Random random;

    public Transform[] lettersArray;

    public float[] weights;

    public ArrayList instantiatedObjects = new ArrayList();

    public  int x;
    public  int y;

    public int rowOn;
    public float distanceMovedDown;

    public float radius = 1f;
    public bool useAsInnerCircleRadius = true;

    private float offsetX, offsetY;

    void Start()
    {
        this.distanceMovedDown = 0;
        this.rowOn = y;
        InvokeRepeating("GenerateRow", 2.0f, 10.0f);
        lettersArray = new Transform[] {this.A, this.B, this.C, this.D, this.E, this.F,
        this.G, this.H, this.I, this.J, this.K, this.L, this.M, this.N, this.O, this.P,
        this.Q, this.R, this.S, this.T, this.U, this.V, this.W, this.X, this.Y, this.Z };

        this.weights = new float[] {
            0.4f, // a
            0.25f, // b
            0.25f, // c
            0.3f, // d
            0.45f, // e
            0.2f, // f
            0.25f, // g
            0.2f, // h
            0.4f, // i
            0.15f, // j
            0.17f, // k
            0.35f, // l
            0.25f, // m
            0.35f, // n
            0.4f, // o
            0.25f, // p
            0.1f, // q
            0.35f, // r
            0.35f, // s
            0.35f, // t
            0.4f, // u
            0.2f, // v
            0.2f, // w
            0.15f, // x
            0.2f, // y
            0.1f // z
        };

        float unitLength = (useAsInnerCircleRadius) ? (radius / (Mathf.Sqrt(3) / 2)) : radius;

        offsetX = (unitLength / 1.5f) * Mathf.Sqrt(3);
        offsetY = (unitLength / 1.5f) * 1.5f;

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                int letterIndex = Random.Range(0, 26);
                Vector2 hexpos = HexOffset(i, j);
                Vector3 pos = new Vector3(hexpos.x - 2, hexpos.y + 3, -0.5f);
                Transform generateMe = this.weightedSelectionOfGameObject();
                if (generateMe != null)
                {
                    Transform obj = Instantiate(weightedSelectionOfGameObject(), pos, Quaternion.identity);
                    instantiatedObjects.Add(obj);
                }
               
            }
        }
    }

    private void Update()
    {

    }

    // Used in the InvokeRepeating call
    // generates a new row of bubbles
    void GenerateRow()
    {
        for (int i = 0; i < x; i++)
        {
            for (int j = rowOn; j < rowOn + 1; j++)
            {
                
                int letterIndex = Random.Range(0, 26);
                Vector2 hexpos = HexOffset(i, j);
                Vector3 pos = new Vector3(hexpos.x - 2, hexpos.y + 3 - distanceMovedDown, -0.2f);
                Transform generateMe = this.weightedSelectionOfGameObject();
                if (generateMe != null)
                {
                    Transform obj = Instantiate(generateMe, pos, Quaternion.identity);
                    instantiatedObjects.Add(obj);
                }
            }
        }
        this.rowOn++;

        foreach (Transform t in instantiatedObjects)
        {
            if (t != null)
            {
                t.position = t.position + new Vector3(0, -1f, 0);
            }
        }
        distanceMovedDown += 1.3f;
    }


    Vector2 HexOffset(int x, int y)
    {
        Vector2 position = Vector2.zero;

        if (y % 2 == 0)
        {
            position.x = x * offsetX;
            position.y = y * offsetY;
        }
        else
        {
            position.x = (x + 0.5f) * offsetX;
            position.y = y * offsetY;
        }

        return position;
    }


    // selects what game object should be instantiated based on the specified weights
    Transform weightedSelectionOfGameObject()
    {
        float selected = Random.Range(0.0f, 1.0f);
        for (int i = 0; i < weights.Length; i++)
        {
            int weightIndex = Random.Range(0, weights.Length);
            if (weights[weightIndex] >= selected)
            {
                    return lettersArray[weightIndex];
            }
        }
        return weightedSelectionOfGameObject();
    }

    public Transform[] getLetterArray()
    {
        return new Transform[] {this.A, this.B, this.C, this.D, this.E, this.F,
        this.G, this.H, this.I, this.J, this.K, this.L, this.M, this.N, this.O, this.P,
        this.Q, this.R, this.S, this.T, this.U, this.V, this.W, this.X, this.Y, this.Z };

    }
}
