using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    public bool charSelected;
    //public Vector3[] charPositions;
    //public GameObject[] charSelectors;
    //public GameObject leftChar; //Set on Unity
    //public GameObject rightChar;//Set on Unity
    public GameObject[] charIcons;
    private int iconCt;
    public KeyCode[] controls; 
    public string ratSelected;
    public int currPos;
    public Vector3 cursorsDistance;

    // Start is called before the first frame update
    void Start()
    {
        iconCt = charIcons.Length;
        if (this.name == "Player1") {
            controls = new KeyCode[]{KeyCode.A, KeyCode.D, KeyCode.X, KeyCode.Z};
            cursorsDistance = new Vector3(0,0,0);
        } else {
            controls = new KeyCode[]{KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.Return, KeyCode.Comma};
            cursorsDistance = new Vector3(2.8f,0.6f,0);
        }

        // currPos = 1;
        // leftChar = GameObject.Find("Cowboy");
        // rightChar = GameObject.Find("Mafia");
        // GameObject[] temp = new GameObject[charSelectors.Length];
        // for (int i = 0; i < charSelectors.Length; i++) {
        //     temp[charSelectors.Length - i - 1] = charSelectors[i];
        // }
        // charSelectors = temp;
        // charPositions = new Vector3[2];
        // for (int i = 0; i < charSelectors.Length; i++) {
        //     charPositions[i] = charSelectors[i].transform.position;
        // }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(controls[0]) && !charSelected) //left
        { 
            currPos = (currPos - 1) % iconCt;
            this.transform.position = charIcons[currPos].transform.position + new Vector3(-1,-3.03f,0) + cursorsDistance;
        }
        else if (Input.GetKeyDown(controls[1]) && !charSelected){ //right
            currPos = (currPos + 1) % iconCt;
            this.transform.position = charIcons[currPos].transform.position + new Vector3(-1,-3.03f,0) + cursorsDistance;
        } 
        else if (Input.GetKeyDown(controls[2])) //select Character
        { 
            this.GetComponent<SpriteRenderer>().enabled = false;
            charSelected = true;
            ratSelected = charIcons[currPos].name;    
        } 
        else if (Input.GetKeyDown(controls[3])) //deselect Character
        { 
            this.GetComponent<SpriteRenderer>().enabled = true;
            charSelected = false;
            ratSelected = null;
        }
    }


}
