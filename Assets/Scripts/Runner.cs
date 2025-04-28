using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    public GameObject prefab;
    private Manager m;
    private float cy=4;
    private float[] cx={-4.2f,-2.8f,-1.4f,0f,1.4f,2.8f,4.2f};
    private short xpos=0;
    private GameObject checker;
    void Start()
    {
        m=new Manager();
        Checker();
    }

    void Update()
    {
        while(!m.Winner())
        {
            if(m.PlayerTurn())
            {
                if(Input.GetKeyDown(KeyCode.H))
                {
                    //move right
                    if(xpos+1<cx.Length)
                    {
                        xpos++;
                        checker.transform.position=new Vector3(this.cx[xpos],cy,0f);
                    }
                }
                if(Input.GetKeyDown(KeyCode.L))
                {
                    //move left
                    if(xpos-1>=0)
                    {
                        xpos--;
                        checker.transform.position=new Vector3(this.cx[xpos],cy,0f);
                    }
                }
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    //drop the piece
                    if(m.PlayerMove(xpos)){Drop();}
                }
            }
            else
            {
                //its the enemy's turn
                checker.transform.position=new Vector3(this.cx[m.EnemyMove()],cy,0f);
                Drop();
            }
        }
    }

    private void Checker(){checker=Instantiate(prefab,new Vector3(cx[xpos],cy,0f),prefab.transform.rotation);}
    private void Drop()
    {
        checker.GetComponent<CircleCollider2D>().enabled=true;
        checker.GetComponent<Rigidbody2D>().simulated=true;
        xpos=0;
        Checker();
    }
    public static void PrintStuff(string s){Debug.Log(s);}
}
