using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputManager", menuName = "Managers/InputManager")]
public class InputManager : ManagerSO<InputManager>
{
    // -------------------------------------------------------------------------- STATIC MEMBERS
    #region STATIC MEMBERS
    #endregion

    // -------------------------------------------------------------------------- SERIALIZABLE INSPECTOR
    #region SERIALIZABLE INSPECTOR
    public GameObject PlayerInputManagerPrefab;
    #endregion

    // -------------------------------------------------------------------------- INSTANCE PROPERTIES
    #region INSTANCE PROPERTIES
    [ReadOnly] public List<User> users;
    #endregion

    // -------------------------------------------------------------------------- GETTERS AND SETTERS
    #region GETTERS AND SETTERS
    #endregion

    // -------------------------------------------------------------------------- INITIALIZATION
    #region INITIALIZATION
    #endregion

    // -------------------------------------------------------------------------- METHODS AND ROUTINES
    #region METHODS AND ROUTINE
    #endregion

    // -------------------------------------------------------------------------- UNITY EVENT FUNCTIONS
    #region UNITY EVENT FUNCTIONS
    public override void Initialize()
    {
        Instance = this;
        Instantiate(PlayerInputManagerPrefab);
    }

    public override void Update() { }

    #endregion

    // -------------------------------------------------------------------------- CASTING
    #region CASTING
    #endregion

    // -------------------------------------------------------------------------- HELPER CLASSES
    #region HELPER CLASSES
    #endregion
    
}