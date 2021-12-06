using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : ManagerSO<CharacterManager>
{
    public Cursor cursor1;
    public Cursor cursor2;
    // Start is called before the first frame update
    void Start()
    {
        cursor1 = GameObject.Find("Player1").GetComponent<Cursor>();
        cursor2 = GameObject.Find("Player2").GetComponent<Cursor>();
    }

    // Update is called once per frame
    public override void Update()
    {   
        if (cursor1.charSelected == true && cursor2.charSelected == true) {//both players ready
            //Change scene? (Confirmation/start battle screen)
            //Somehow pass on player assignments to gameplaymanager? -prefabs w/ names/tags?

        }
    }



    public override void Initialize()
    {
        Instance = this;

    }    

}
