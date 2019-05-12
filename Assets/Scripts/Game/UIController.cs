using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Texture2D cursorMain;
    public Texture2D cursorPoint;
    public Texture2D cursorTake;
    public Texture2D cursorForward;
    public Texture2D cursorBackward;
    public Texture2D cursorLeft;
    public Texture2D cursorRight;
    public Texture2D cursorMagnifier;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public Button forward;
    public Button backward;
    public Button left;
    public Button right;

    public Button gameMenuButton;
    public Animator gameMenuAnimator;

    public Button exitButton;

    //public Button backFromCloseupButton;
    [SerializeField]
    private GameObject itemPanel;
    private GameObject objToActivate;

    private bool isOpen = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        gameMenuButton.onClick.AddListener(() => OpenMenu());
        gameMenuAnimator.SetBool("isOpen", isOpen);

        exitButton.onClick.AddListener(() => Application.Quit());
        //backFromCloseupButton.gameObject.SetActive(false);
        
        itemPanel.SetActive(false);

        Cursor.SetCursor(cursorMain, hotSpot, cursorMode);
    }

    private void OpenMenu()
    {
        isOpen = !isOpen;
        gameMenuAnimator.SetBool("isOpen", isOpen);
    }

    public void ShowItem(Sprite item, Sprite text, GameObject obj)
    {
        //backFromCloseupButton.gameObject.SetActive(true);
        //backFromCloseupButton.onClick.AddListener(Back);
        if (obj != null)
        {
            objToActivate = obj;
            obj.SetActive(false);
        }
        itemPanel.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = item;
        itemPanel.transform.GetChild(2).gameObject.GetComponent<Image>().sprite = text;
        itemPanel.SetActive(true);
        instance.DeactivateButtons();
    }

    public void Back()
    {
        if (objToActivate != null)
            objToActivate.SetActive(true);

        itemPanel.SetActive(false);
        //backFromCloseupButton.gameObject.SetActive(false);
        GameController.instance.currentRacurs.SetButtons();
        objToActivate = null;
    }

    public void DeactivateButtons()
    {
        forward.gameObject.SetActive(false);
        backward.gameObject.SetActive(false);
        left.gameObject.SetActive(false);
        right.gameObject.SetActive(false);
    }

    public void AtivateButtons()
    {
        if(forward.onClick.GetPersistentEventCount() > 0)
            forward.gameObject.SetActive(true);
        if (backward.onClick.GetPersistentEventCount() > 0)
            backward.gameObject.SetActive(true);
        if (left.onClick.GetPersistentEventCount() > 0)
            left.gameObject.SetActive(true);
        if (right.onClick.GetPersistentEventCount() > 0)
            right.gameObject.SetActive(true);
    }

    public void SetCursorMain()
    {
        Cursor.SetCursor(cursorMain, hotSpot, cursorMode);
    }

    public void SetCursorPoint()
    {
        Cursor.SetCursor(cursorPoint, hotSpot, cursorMode);
    }

    public void SetCursorTake()
    {
        Cursor.SetCursor(cursorTake, hotSpot, cursorMode);
    }

    public void SetCursorLeft()
    {
        Cursor.SetCursor(cursorLeft, hotSpot, cursorMode);
    }

    public void SetCursorRight()
    {
        Cursor.SetCursor(cursorRight, hotSpot, cursorMode);
    }

    public void SetCursorForward()
    {
        Cursor.SetCursor(cursorForward, hotSpot, cursorMode);
    }

    public void SetCursorBackward()
    {
        Cursor.SetCursor(cursorBackward, hotSpot, cursorMode);
    }

    public void SetCursorMagnifier()
    {
        Cursor.SetCursor(cursorMagnifier, hotSpot, cursorMode);
    }

    public void SetCursorOpen()
    {
        Cursor.SetCursor(cursorPoint, hotSpot, cursorMode);
    }
}
