
using System.Collections.Generic;
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
    public GameObject CanvasPrefab;
    public GameObject MainMenuPrefab;
    public GameObject PauseMenuPrefab;
    public GameObject ScrollTextPrefab;
    
    public GameObject BattleUIPrefab;
    #endregion

    // -------------------------------------------------------------------------- INSTANCE PROPERTIES
    #region INSTANCE PROPERTIES
    [ReadOnly] public Canvas Canvas;
    private GUIStyle hpStyle = new GUIStyle();
    public Stack<UIElement> uiStack;
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
        uiStack = new Stack<UIElement>();
        UnityManager.Instance.InstantiatePrefab(BattleUIPrefab);
        Canvas = Instantiate(CanvasPrefab).GetComponent<Canvas>();
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

    public void PushUI(UIElement ui)
    {
        uiStack.Push(ui);
    }

    public void PopUI(UIElement ui)
    {
        UIElement currUI = uiStack.Pop();
        while (currUI != ui)
        {
            Destroy(currUI.gameObject);
            currUI = uiStack.Pop();
        }
        Destroy(currUI.gameObject);
    }
    
    // SPECIFIC UIS
    
    public void MainMenu()
    {
        PushUI(Instantiate(MainMenuPrefab, UIManager.Instance.Canvas.transform).GetComponent<MainMenu>());
    }
    
    public void Pause()
    {
        PushUI(Instantiate(PauseMenuPrefab, UIManager.Instance.Canvas.transform).GetComponent<PauseMenu>());
    }
    
    public void ScrollText(string text)
    {
        ScrollText scrollText = Instantiate(ScrollTextPrefab, UIManager.Instance.Canvas.transform)
            .GetComponent<ScrollText>();
        scrollText.text.text = text;
        PushUI(scrollText);
    }
    
    public void ScrollFight()
    {
        ScrollText scrollText = Instantiate(ScrollTextPrefab, UIManager.Instance.Canvas.transform)
            .GetComponent<ScrollText>();
        scrollText.text.text = "FIGHT!!!";
        scrollText.text.fontSize = 60;
        scrollText.text.color = Color.red;
        PushUI(scrollText);
    }

    // -------------------------------------------------------------------------- UNITY EVENT FUNCTIONS
    #region UNITY EVENT FUNCTIONS
    public override void Update()
    {
        bool blocked = false;
        foreach (UIElement m in uiStack.ToArray())
        {
            m.SetInteractable(!blocked);
            if (!blocked)
            {
                m.BlockedUpdate();
            }
            if (m.Blocking())
            {
                blocked = true;
            }
        }
        Time.timeScale = blocked ? 0.0f : 1.0f;
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale > 0.0f)
        {
            Pause();
        }
    }
    #endregion

    // -------------------------------------------------------------------------- CASTING
    #region CASTING
    #endregion

    // -------------------------------------------------------------------------- HELPER CLASSES
    #region HELPER CLASSES
    #endregion
}