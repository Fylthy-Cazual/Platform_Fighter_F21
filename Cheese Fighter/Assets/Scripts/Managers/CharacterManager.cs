using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    public Cursor cursor1;
    public Cursor cursor2;
    public GameObject cowboyPrefab;
    public GameObject mafiaPrefab;
    public GameObject roguePrefab;
    private Rat p1;
    private Rat p2;

    // Start is called before the first frame update
    void Start()
    {
        cursor1 = GameObject.Find("Player1").GetComponent<Cursor>();
        cursor2 = GameObject.Find("Player2").GetComponent<Cursor>();
        CameraManager.Instance.FixCameraPos();
    }

    // Update is called once per frame
    public void Update()
    {   
        if (cursor1.charSelected == true && cursor2.charSelected == true) {//both players ready
            SceneManager.LoadScene("FirstStage");
            //Change scene? (Confirmation/start battle screen)
            //Somehow pass on player assignments to gameplaymanager? -prefabs w/ names/tags?
            if (cursor1.ratSelected == "Cowboy") 
            {
                p1 = Instantiate(cowboyPrefab, new Vector3(-5, 0, 0), Quaternion.identity).GetComponent<Rat>();
            } 
            else if (cursor1.ratSelected == "Mafia") 
            {
                p1 = Instantiate(mafiaPrefab, new Vector3(-5, 0, 0), Quaternion.identity).GetComponent<Rat>();
            }
            else 
            {
                p1 = Instantiate(roguePrefab, new Vector3(-5, 0, 0), Quaternion.identity).GetComponent<Rat>();
            }

            if (cursor2.ratSelected == "Cowboy") 
            {
                p2 = Instantiate(cowboyPrefab, new Vector3(5, 0, 0), Quaternion.identity).GetComponent<Rat>();
            } 
            else if (cursor2.ratSelected == "Mafia") 
            {
                p2 = Instantiate(mafiaPrefab, new Vector3(5, 0, 0), Quaternion.identity).GetComponent<Rat>();
            }
            else 
            {
                p2 = Instantiate(roguePrefab, new Vector3(5, 0, 0), Quaternion.identity).GetComponent<Rat>();
            }

            p1.tag = "p0";
            p1.playerNum = 0;
            p2.tag = "p1";
            p2.playerNum = 1;
            DontDestroyOnLoad(p1);
            DontDestroyOnLoad(p2);
            UnityManager.Instance.Initialize();
            CameraManager.Instance.UnfixCameraPos();


        }
    }

}
