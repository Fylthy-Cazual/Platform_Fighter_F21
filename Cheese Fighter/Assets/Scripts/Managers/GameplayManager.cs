using UnityEngine;

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
    #endregion

    // -------------------------------------------------------------------------- GETTERS AND SETTERS
    #region GETTERS AND SETTERS
    #endregion

    // -------------------------------------------------------------------------- INITIALIZATION
    #region INITIALIZATION
    public override void Initialize()
    {
        Instance = this;
        allPlayers = FindObjectsOfType<Rat>();
    }
    #endregion

    // -------------------------------------------------------------------------- METHODS AND ROUTINES
    #region METHODS AND ROUTINES
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
    #endregion
}