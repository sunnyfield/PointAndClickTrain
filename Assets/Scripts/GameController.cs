using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public Button forward;
    public Button backward;
    public Button left;
    public Button right;
    public Interactable doorToBegin;
    public IRacurs cor1L;
    public IRacurs cor2L;
    public IRacurs cor3L;
    public IRacurs cor1R;
    public IRacurs cor2R;
    public IRacurs cor3R;
    public IRacurs win1;
    public IRacurs win2;
    public IRacurs win3;
    public IRacurs win4;
    public IRacurs door1;
    public IRacurs door2;
    public IRacurs door3;
    public IRacurs door4;
    public IRacurs room;
    public IRacurs table;
    public IRacurs floor;
    public IRacurs corpse;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        print("Game controller Start");
        cor1L = Racurs.CreateRacurs(transform.GetChild(1).gameObject);
        cor2L = Racurs.CreateRacurs(transform.GetChild(2).gameObject);
        cor3L = Racurs.CreateRacurs(transform.GetChild(3).gameObject);
        cor1R = Racurs.CreateRacurs(transform.GetChild(4).gameObject);
        cor2R = Racurs.CreateRacurs(transform.GetChild(5).gameObject);
        cor3R = Racurs.CreateRacurs(transform.GetChild(6).gameObject);
        win1 = RacursSides.CreateRacurs(transform.GetChild(7).gameObject);
        win2 = RacursSides.CreateRacurs(transform.GetChild(8).gameObject);
        win3 = RacursSides.CreateRacurs(transform.GetChild(9).gameObject);
        win4 = RacursSides.CreateRacurs(transform.GetChild(10).gameObject);
        door1 = RacursSides.CreateRacurs(transform.GetChild(11).gameObject);
        door2 = RacursSides.CreateRacurs(transform.GetChild(12).gameObject);
        door3 = RacursSides.CreateRacurs(transform.GetChild(13).gameObject);
        door4 = RacursSides.CreateRacurs(transform.GetChild(14).gameObject);
        room = Racurs.CreateRacurs(transform.GetChild(15).gameObject);
        table = Racurs.CreateRacurs(transform.GetChild(16).gameObject);
        floor = Racurs.CreateRacurs(transform.GetChild(17).gameObject);
        corpse = Racurs.CreateRacurs(transform.GetChild(18).gameObject);


        cor1L.SetForw(cor2L);
        cor1L.SetPrev(cor1R);
        cor1L.SetLeft(win2);
        cor1L.SetRight(door2);
        cor1L.SetButtons();

        cor2L.SetForw(cor3L);
        cor2L.SetPrev(cor1L);
        cor2L.SetLeft(win1);
        cor2L.SetRight(door1);
        
        cor3L.SetPrev(cor2L);

        cor1R.SetForw(cor2R);
        cor1R.SetPrev(cor1L);
        cor1R.SetLeft(door3);
        cor1R.SetRight(win3);

        cor2R.SetForw(cor3R);
        cor2R.SetPrev(cor1R);
        cor2R.SetLeft(door4);
        cor2R.SetRight(win4);
        
        cor3R.SetPrev(cor2R);
        
        win1.SetLeft(win2);
        win1.SetPrev(cor2L);
        
        win2.SetLeft(win3);
        win2.SetRight(win1);
        win2.SetPrev(cor1L);
        
        win3.SetLeft(win4);
        win3.SetRight(win2);
        win3.SetPrev(cor1R);
        
        win4.SetRight(win3);
        win4.SetPrev(cor2R);

        door1.SetRight(door2);
        door1.SetPrev(cor2L);

        door2.SetLeft(door1);
        door2.SetRight(door3);
        door2.SetPrev(cor1L);

        door3.SetLeft(door2);
        door3.SetRight(door4);
        door3.SetPrev(cor1R);

        door4.SetLeft(door3);
        door4.SetPrev(cor2R);

        room.SetPrev(door2);
        room.SetLeft(corpse);
        room.SetForw(table);

        table.SetPrev(room);
        table.SetLeft(corpse);

        floor.SetPrev(room);
        floor.SetLeft(corpse);

        corpse.SetPrev(room);
        corpse.SetRight(room);

        doorToBegin.room = room;

        ////forward = GameObject.Find("/Canvas/Button_GoForward").GetComponent<Button>();
        //forward.onClick.AddListener(() => firstRacurs.Forward());
        ////backward = GameObject.Find("/Canvas/Button_GoBackward").GetComponent<Button>();
        //backward.onClick.AddListener(() => firstRacurs.Backward());
        ////left = GameObject.Find("/Canvas/Button_GoLeft").GetComponent<Button>();
        //left.onClick.AddListener(() => firstRacurs.Left());
        ////right = GameObject.Find("/Canvas/Button_GoRight").GetComponent<Button>();
        //right.onClick.AddListener(() => firstRacurs.Right());
    }  
}
