using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "GameplayManager", menuName = "Managers/GameplayManager")]
public class GameplayManager : ManagerSO<GameplayManager>
{
    // -------------------------------------------------------------------------- STATIC MEMBERS
    #region STATIC MEMBERS
    #endregion

    // -------------------------------------------------------------------------- SERIALIZABLE INSPECTOR
    #region SERIALIZABLE INSPECTOR
    #endregion

    // -------------------------------------------------------------------------- INSTANCE PROPERTIES
    #region INSTANCE PROPERTIES
    [HideInInspector] public Rat[] allPlayers;
    [HideInInspector] public string winner;
    #endregion

    // -------------------------------------------------------------------------- GETTERS AND SETTERS
    #region GETTERS AND SETTERS
    #endregion

    // -------------------------------------------------------------------------- INITIALIZATION
    #region INITIALIZATION
    public override void Initialize()
    {
        Instance = this;
        FindPlayers();
        //SetMapBounds(35,25);//hardcoded from UnityManager
    }
    #endregion

    // -------------------------------------------------------------------------- METHODS AND ROUTINES
    #region METHODS AND ROUTINES

    public void FindPlayers() 
    {
        allPlayers = FindObjectsOfType<Rat>();
    }

    public void SetMapBounds(int mapWidth, int mapHeight)
    {
        GameObject mapBounds = new GameObject("MapBounds", typeof(BoxCollider2D), typeof(Rigidbody2D), typeof(EndOfMap));
        mapBounds.transform.position = Vector3.zero;
        BoxCollider2D boundsCollider = mapBounds.GetComponent<BoxCollider2D>();
        boundsCollider.isTrigger = true;
        boundsCollider.size = new Vector2(mapWidth, mapHeight);
        Rigidbody2D boundsBody = mapBounds.GetComponent<Rigidbody2D>();
        boundsBody.bodyType = RigidbodyType2D.Static;
    }
    #endregion

    // -------------------------------------------------------------------------- UNITY EVENT FUNCTIONS
    #region UNITY EVENT FUNCTIONS
    public override void Update() { }
    #endregion

    // -------------------------------------------------------------------------- CASTING
    #region CASTING
    #endregion

    // -------------------------------------------------------------------------- HELPER CLASSES
    #region HELPER CLASSES
    public void DecideVictor() //If only one rat has >0 lives, the game ends with this rat as winner
    {
        Debug.Log("Test");
        Rat survivor = null;
        foreach (Rat rat in allPlayers)
        {
            if (rat.lives > 0)
            {
                if (survivor == null)
                {
                    survivor = rat;
                }
                else
                {
                    return;
                }
            }
        }
        //We have a winner
        winner = survivor.name;
        UnityManager.Instance.StartCoroutine(FlashVictor(winner));
    }

    private static IEnumerator FlashVictor(string winner)
    {
        const float enterExitTime = 0.8f;
        const float holdTime = 2.0f;
        //UIManager.Instance.ScrollText(winner + " is Victorious!", enterExitTime, holdTime);
        yield return new WaitForSeconds(2 * enterExitTime + holdTime);
        
        CameraManager.Instance.FixCameraPos();
        SceneManager.LoadScene("Winscreen");
        //load scene decalring [survivor] as the winner
    }

    #endregion
}