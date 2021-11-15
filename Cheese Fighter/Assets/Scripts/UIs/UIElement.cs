using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIElement : MonoBehaviour
{
    // ---------------------------------------------- STATIC
        
    // ---------------------------------------------- SERIALIZABLE
        
    // ---------------------------------------------- PROPERTIES
    public abstract bool Blocking();
    private Selectable[] selectables;

    // ---------------------------------------------- METHODS AND ROUTINES
    public void SetInteractable(bool interactable)
    {
        foreach (Selectable selectable in selectables)
        {
            selectable.interactable = interactable;
        }
    }
    
    // ---------------------------------------------- UNITY EVENT FUNCTIONS
    public virtual void Awake()
    {
        selectables = GetComponentsInChildren<Selectable>() ?? Array.Empty<Selectable>();
    }

    public abstract void BlockedUpdate();

    // ---------------------------------------------- CASTING

    // ---------------------------------------------- HELPER CLASSES

}