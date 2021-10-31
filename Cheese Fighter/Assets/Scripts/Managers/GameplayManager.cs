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

// -------------------------------------------------------------------------- STATIC MEMBERS
#region STATIC MEMBERS
#endregion
    
// -------------------------------------------------------------------------- SERIALIZABLE INSPECTOR
#region SERIALIZABLE INSPECTOR
#endregion
    
// -------------------------------------------------------------------------- INSTANCE PROPERTIES
#region INSTANCE PROPERTIES
#endregion
    
// -------------------------------------------------------------------------- GETTERS AND SETTERS
#region GETTERS AND SETTERS
#endregion
    
// -------------------------------------------------------------------------- INITIALIZATION
#region INITIALIZATION
#endregion
    
// -------------------------------------------------------------------------- METHODS AND ROUTINES
#region METHODS AND ROUTINES
#endregion
    
// -------------------------------------------------------------------------- UNITY EVENT FUNCTIONS
#region UNITY EVENT FUNCTIONS
#endregion
    
// -------------------------------------------------------------------------- CASTING
#region CASTING
#endregion
    
// -------------------------------------------------------------------------- HELPER CLASSES
#region HELPER CLASSES
#endregion