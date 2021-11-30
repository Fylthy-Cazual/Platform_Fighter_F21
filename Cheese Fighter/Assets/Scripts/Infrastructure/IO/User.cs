using UnityEngine;
using UnityEngine.InputSystem;

public class User : MonoBehaviour
{
    // ---------------------------------------------- STATIC
        
    // ---------------------------------------------- SERIALIZABLE

    // ---------------------------------------------- PROPERTIES

    [HideInInspector] public InputAction Right;
    [HideInInspector] public InputAction Up;
    [HideInInspector] public InputAction Left;
    [HideInInspector] public InputAction Down;
    [HideInInspector] public InputAction Jab;
    [HideInInspector] public InputAction Special;

    // ---------------------------------------------- METHODS AND ROUTINES

    public void RightCallback(InputAction.CallbackContext callback)
    {
        Right = callback.action;
    }
    
    public void UpCallback(InputAction.CallbackContext callback)
    {
        Up = callback.action;
    }
    
    public void LeftCallback(InputAction.CallbackContext callback)
    {
        Right = callback.action;
    }
    
    public void DownCallback(InputAction.CallbackContext callback)
    {
        Right = callback.action;
    }

    public void JabCallback(InputAction.CallbackContext callback)
    {
        Jab = callback.action;
    }
    
    public void SpecialCallback(InputAction.CallbackContext callback)
    {
        Special = callback.action;
    }

    // ---------------------------------------------- UNITY EVENT FUNCTIONS
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        InputManager.Instance.users.Add(this);
    }
    private void OnDestroy()
    {
        InputManager.Instance.users.Remove(this);
    }

    // ---------------------------------------------- CASTING

    // ---------------------------------------------- HELPER CLASSES
}