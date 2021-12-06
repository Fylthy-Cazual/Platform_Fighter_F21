using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelectorIcons : MonoBehaviour
{
    public GameObject player1;//Set on Unity
    public GameObject player2;//Set on Unity
    public GameObject border1;//Set on Unity
    public GameObject border2;//Set on Unity
    public GameObject border12;//Set on Unity

    public Cursor cursor1;
    public Cursor cursor2;
    // Start is called before the first frame update
    void Start()
    {
        cursor1 = player1.GetComponent<Cursor>();
        cursor2 = player2.GetComponent<Cursor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cursor1.ratSelected == this.name && cursor2.ratSelected == this.name) {
            border12.GetComponent<SpriteRenderer>().enabled = true;
            border1.GetComponent<SpriteRenderer>().enabled = false;
            border2.GetComponent<SpriteRenderer>().enabled = false;
        } else if (cursor1.ratSelected == this.name) {
            border12.GetComponent<SpriteRenderer>().enabled = false;
            border1.GetComponent<SpriteRenderer>().enabled = true;
            border2.GetComponent<SpriteRenderer>().enabled = false;
        } else if (cursor2.ratSelected == this.name) {
            border12.GetComponent<SpriteRenderer>().enabled = false;
            border1.GetComponent<SpriteRenderer>().enabled = false;
            border2.GetComponent<SpriteRenderer>().enabled = true;
        } else {
            border12.GetComponent<SpriteRenderer>().enabled = false;
            border1.GetComponent<SpriteRenderer>().enabled = false;
            border2.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
