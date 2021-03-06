﻿using System.Collections;
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

    public GameObject itemCounter;
    private Text itemCountText;
    private static int maxItemCount = 5;
    private GameObject[] inventoryCells = new GameObject[maxItemCount];
    private int freeCell;

    public bool menuIsOpen = false;

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
        gameMenuAnimator.SetBool("isOpen", menuIsOpen);

        exitButton.onClick.AddListener(() => Application.Quit());

        inventoryCells[0] = GameObject.Find("/Canvas/Panel_GameMenu/Inventory/Image_Cell1");
        inventoryCells[1] = GameObject.Find("/Canvas/Panel_GameMenu/Inventory/Image_Cell2");
        inventoryCells[2] = GameObject.Find("/Canvas/Panel_GameMenu/Inventory/Image_Cell3");
        inventoryCells[3] = GameObject.Find("/Canvas/Panel_GameMenu/Inventory/Image_Cell4");
        inventoryCells[4] = GameObject.Find("/Canvas/Panel_GameMenu/Inventory/Image_Cell5");
        // = GameObject.FindGameObjectsWithTag(tagCell);
        freeCell = 0;

        itemCountText = itemCounter.transform.GetChild(0).GetComponent<Text>();
        itemCounter.SetActive(false);
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
            if (results2D[0].gameObject.CompareTag(tagMagnifier)) SetCursorMagnifier();
            else if (results2D[0].gameObject.CompareTag(tagLeft)) SetCursorLeft();
            else if (results2D[0].gameObject.CompareTag(tagRight)) SetCursorRight();
            else if (results2D[0].gameObject.CompareTag(tagForward)) SetCursorForward();
            else if (results2D[0].gameObject.CompareTag(tagBackward)) SetCursorBackward();
            else if (results2D[0].gameObject.CompareTag(tagOpen)) SetCursorOpen();
            else SetCursorMain();
        }
        else SetCursorMain();

        if (resultsUI.Count > 0)
        {
            if (resultsUI[0].gameObject.CompareTag(tagLeft)) SetCursorLeft();
            else if (resultsUI[0].gameObject.CompareTag(tagRight)) SetCursorRight();
            else if (resultsUI[0].gameObject.CompareTag(tagForward)) SetCursorForward();
            else if (resultsUI[0].gameObject.CompareTag(tagBackward)) SetCursorBackward();
            else if (resultsUI[0].gameObject.CompareTag(tagTake)) SetCursorTake();
            else SetCursorMain();
        }

        resultsUI.Clear();
        results2D.Clear();
    }

    private void OpenMenu()
    {
        menuIsOpen = !menuIsOpen;
        gameMenuAnimator.SetBool("isOpen", menuIsOpen);
    }

    public void ShowItem(Sprite item, GameObject text, GameObject objToDeactivate)
    {
        if (objToDeactivate != null)
        {
            objToActivate = objToDeactivate;
            objToDeactivate.SetActive(false);
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
        itemCountText.text = (freeCell + 1).ToString();
        cell = inventoryCells[freeCell++].GetComponent<Image>();
        cell.sprite = item;
        cell.color = Color.white;

    }

    public void Back()
    {
        if (objToActivate != null) objToActivate.SetActive(true);

        itemText.SetActive(false);
        itemPanel.SetActive(false);
        GameController.instance.currentRacurs.SetButtons();
        objToActivate = null;
    }

    public void ShowCharacterSheet(Sprite characterSheetSprite)
    {
        if (closedNote.activeInHierarchy) closedNote.SetActive(false);

        if (!characterSheet.activeInHierarchy) characterSheet.SetActive(true);
        
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
        if(forward.onClick.GetPersistentEventCount() > 0) forward.gameObject.SetActive(true);
        if (backward.onClick.GetPersistentEventCount() > 0) backward.gameObject.SetActive(true);
        if (left.onClick.GetPersistentEventCount() > 0) left.gameObject.SetActive(true);
        if (right.onClick.GetPersistentEventCount() > 0) right.gameObject.SetActive(true);
    }

    private void SetCursorMain() { Cursor.SetCursor(cursorMain, hotSpot, cursorMode); }

    private void SetCursorPoint() { Cursor.SetCursor(cursorPoint, hotSpot, cursorMode); }

    private void SetCursorTake() { Cursor.SetCursor(cursorTake, hotSpot, cursorMode); }

    private void SetCursorLeft() { Cursor.SetCursor(cursorLeft, hotSpot, cursorMode); }

    private void SetCursorRight() { Cursor.SetCursor(cursorRight, hotSpot, cursorMode); }

    private void SetCursorForward() { Cursor.SetCursor(cursorForward, hotSpot, cursorMode); }

    private void SetCursorBackward() { Cursor.SetCursor(cursorBackward, hotSpot, cursorMode); }

    private void SetCursorMagnifier() { Cursor.SetCursor(cursorMagnifier, hotSpot, cursorMode); }

    private void SetCursorOpen() { Cursor.SetCursor(cursorPoint, hotSpot, cursorMode); }
}
