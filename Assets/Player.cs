using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public Text text;
    private string last;
    public int[] a;
    public int[] values;
    private int winner;
    public int num;

    int b;
    private float cd;

    // Start is called before the first frame update
    void Start()
    {
        cd = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        GetValues();
        if (cd <= 1)
        {
            for (int i = 0; i <= 39; i++)
            {
                a[i] = values[i];
            }

            for (int j=0; j <=38 ; j++) 
            {
                for (int i = 0; i <= 38; i++)
                {
                    if (a[i + 1] < a[i])
                    {
                        b = a[i + 1];
                        a[i + 1] = a[i];
                        a[i] = b;

                    }
                }
            }

            for(int i = 0; i <= 39; i++)
            {
                if (values[i] == a[16])
                {
                        num = a[16];
                        winner = i;
                }
            }
            Winner(winner);
        }
        else
        {
            for (int i = 0; i <= 39; i++)
            {
                if (values[i] == num)
                {
                    Winner(i);
                    num = 1000;
                }
            }
        }

      



      



        //!!!!!Kodu Buraya Yazın!!!!!

    }

    private void GetValues()
    {
        if (Time.time >= cd)
        {
            cd += 1;
            last = text.text;
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = Random.Range(10, 100);
                text.text += " " + values[i];
            }
            text.text += " \n \n";
        }
    }

    private void Winner(int win)
    {
        text.text = last;
        for (int i = 0; i < values.Length; i++)
        {
            if (i == win)
            {
                text.text += " <color=red>" + values[i] + "</color>";
                Debug.Log("" + cd + ". saniyedeki " + (i + 1) + ". oyuncu kazandı!");
            } else {
                text.text += " " + values[i];
            }
        }
        text.text += " \n \n";
    }
}
