using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Rat[] allPlayers;

    public Rat player1;
    public Rat player2;
    public Rat player3;
    public Rat player4;

    public RectTransform statusDisplay;
    private GUIStyle hpStyle;

    // Start is called before the first frame update
    void Start()
    {
        allPlayers = FindObjectsOfType<Rat>();
        if (allPlayers[0] != null) {
            player1 = allPlayers[0];
        }
        if (allPlayers[1] != null) {
            player2 = allPlayers[1];
        }
        if (allPlayers[2] != null) {
            player3 = allPlayers[2];
        }
        if (allPlayers[3] != null) {
            player4 = allPlayers[3];
        }

        hpStyle.fontSize = 80;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        GUI.skin.label.fontSize = 50;
        string health = "";
        foreach (Rat rat in allPlayers) {
            health += rat.name + ": " + rat.hp.ToString() + " ";
        }
        GUI.Label(new Rect(20, 20, 7000, 5000), health);
         
    }
}
