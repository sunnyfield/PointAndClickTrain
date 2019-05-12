using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public const string tagLeft = "Left";
    public const string tagRight = "Right";
    public const string tagBackward = "Backward";
    public const string tagForward = "Forward";
    public const string tagTake = "Take";
    public const string tagMagnifier = "Magnifier";
    public const string tagOpen = "Open";
    public const string tagCell = "InventoryCell";

    public GraphicRaycaster raycasterUI;
    public Physics2DRaycaster raycaster2D;
    public PointerEventData pointerEventData;
    public EventSystem eventSystem;
    private List<RaycastResult> resultsUI = new List<RaycastResult>();
    private List<RaycastResult> results2D = new List<RaycastResult>();

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

    public GameObject itemPanel;
    private GameObject objToActivate;
    private GameObject itemText;


    public GameObject characterSheet;

    public GameObject closedNote;

    private GameObject[] inventoryCells;
    private int freeCell = 0;

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
        pointerEventData = new PointerEventData(eventSystem) { position = Input.mousePosition };

        gameMenuButton.onClick.AddListener(() => OpenMenu());
        gameMenuAnimator.SetBool("isOpen", isOpen);

        exitButton.onClick.AddListener(() => Application.Quit());

        inventoryCells = GameObject.FindGameObjectsWithTag(tagCell);

        itemPanel.SetActive(false);

        Cursor.SetCursor(cursorMain, hotSpot, cursorMode);
    }

    private void Update()
    {
        pointerEventData.position = Input.mousePosition;

        raycasterUI.Raycast(pointerEventData, resultsUI);
        raycaster2D.Raycast(pointerEventData, results2D);

        if (results2D.Count > 0)
        {
            if (results2D[0].gameObject.CompareTag(tagMagnifier))
                instance.SetCursorMagnifier();
            else if (results2D[0].gameObject.CompareTag(tagLeft))
                instance.SetCursorLeft();
            else if (results2D[0].gameObject.CompareTag(tagRight))
                instance.SetCursorRight();
            else if (results2D[0].gameObject.CompareTag(tagForward))
                instance.SetCursorForward();
            else if (results2D[0].gameObject.CompareTag(tagBackward))
                instance.SetCursorBackward();
            else if (results2D[0].gameObject.CompareTag(tagOpen))
                instance.SetCursorOpen();
            else
                instance.SetCursorMain();
        }
        else
            instance.SetCursorMain();

        if (resultsUI.Count > 0)
        {
            if (resultsUI[0].gameObject.CompareTag(tagLeft))
                instance.SetCursorLeft();
            else if (resultsUI[0].gameObject.CompareTag(tagRight))
                instance.SetCursorRight();
            else if (resultsUI[0].gameObject.CompareTag(tagForward))
                instance.SetCursorForward();
            else if (resultsUI[0].gameObject.CompareTag(tagBackward))
                instance.SetCursorBackward();
            else if (resultsUI[0].gameObject.CompareTag(tagTake))
                instance.SetCursorTake();
            else
                instance.SetCursorMain();
        }

        resultsUI.Clear();
        results2D.Clear();
    }

    private void OpenMenu()
    {
        isOpen = !isOpen;
        gameMenuAnimator.SetBool("isOpen", isOpen);
    }

    public void ShowItem(Sprite item, GameObject text, GameObject obj)
    {
        if (obj != null)
        {
            objToActivate = obj;
            obj.SetActive(false);
        }
        itemPanel.transform.GetChild(1).gameObject.SetActive(false);
        itemPanel.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = item;
        itemPanel.transform.GetChild(1).gameObject.SetActive(true);      
        itemPanel.SetActive(true);
        itemText = text;
        text.SetActive(true);
        instance.DeactivateButtons();
    }

    public void PlaceToInventory(Sprite item)
    {
        Image cell;
        cell = inventoryCells[freeCell++].GetComponent<Image>();
        cell.sprite = item;
        cell.color = Color.white;

    }

    public void Back()
    {
        if (objToActivate != null)
            objToActivate.SetActive(true);

        itemText.SetActive(false);
        itemPanel.SetActive(false);
        GameController.instance.currentRacurs.SetButtons();
        objToActivate = null;
    }

    public void ShowCharacterSheet(Sprite characterSheetSprite)
    {
        if (closedNote.activeInHierarchy)
            closedNote.SetActive(false);

        if (!characterSheet.activeInHierarchy)
            characterSheet.SetActive(true);
        
        characterSheet.GetComponent<Image>().sprite = characterSheetSprite;
    }

    public void CloseNote()
    {
        characterSheet.SetActive(false);
        closedNote.SetActive(true);
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

    private void SetCursorMain()
    {
        Cursor.SetCursor(cursorMain, hotSpot, cursorMode);
    }

    private void SetCursorPoint()
    {
        Cursor.SetCursor(cursorPoint, hotSpot, cursorMode);
    }

    private void SetCursorTake()
    {
        Cursor.SetCursor(cursorTake, hotSpot, cursorMode);
    }

    private void SetCursorLeft()
    {
        Cursor.SetCursor(cursorLeft, hotSpot, cursorMode);
    }

    private void SetCursorRight()
    {
        Cursor.SetCursor(cursorRight, hotSpot, cursorMode);
    }

    private void SetCursorForward()
    {
        Cursor.SetCursor(cursorForward, hotSpot, cursorMode);
    }

    private void SetCursorBackward()
    {
        Cursor.SetCursor(cursorBackward, hotSpot, cursorMode);
    }

    private void SetCursorMagnifier()
    {
        Cursor.SetCursor(cursorMagnifier, hotSpot, cursorMode);
    }

    private void SetCursorOpen()
    {
        Cursor.SetCursor(cursorPoint, hotSpot, cursorMode);
    }
}
