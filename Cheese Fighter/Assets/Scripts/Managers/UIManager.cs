
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "UIManager", menuName = "Managers/UIManager")]
public class UIManager : ManagerSO<UIManager>
{
    // -------------------------------------------------------------------------- STATIC MEMBERS
    #region STATIC MEMBERS
    #endregion

    // -------------------------------------------------------------------------- SERIALIZABLE INSPECTOR
    #region SERIALIZABLE INSPECTOR
    public GameObject BattleUIPrefab;
    #endregion

    // -------------------------------------------------------------------------- INSTANCE PROPERTIES
    #region INSTANCE PROPERTIES
    private GUIStyle hpStyle = new GUIStyle();
    #endregion

    // -------------------------------------------------------------------------- GETTERS AND SETTERS
    #region GETTERS AND SETTERS
    #endregion

    // -------------------------------------------------------------------------- INITIALIZATION
    #region INITIALIZATION

    public override void Initialize()
    {
        Instance = this;
        hpStyle.fontSize = 80;
        UnityManager.Instance.InstantiatePrefab(BattleUIPrefab);
    }
    #endregion

    // -------------------------------------------------------------------------- METHODS AND ROUTINES
    #region METHODS AND ROUTINES
    public TextMesh AttachText(Transform parent, Vector2 offset)
    {
        return new GameObject("uiText", typeof(TextMesh))
        {
            transform =
            {
                parent = parent,
                localPosition = offset
            }
        }.GetComponent<TextMesh>();
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