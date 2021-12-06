using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinnerManager : MonoBehaviour
{
    public string winner; 
    TextMeshPro nameDisplay;
    // Start is called before the first frame update
    void Start()
    {
        winner = GameplayManager.Instance.winner;
        nameDisplay = transform.Find("NameDisplay").GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        nameDisplay.text = winner;
    }
}
