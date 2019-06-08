//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum RacursName { Corridor1WinL, Corridor2WinL, Corridor3WinL, Corridor1WinR, Corridor2WinR, Corridor3WinR,
                         Table, Window, Floor, Corpse, Room,
                         Windows1, Windows2, Windows3, Windows4, Doors1, Doors2, Doors3, Doors4 };

public class GameController : MonoBehaviour
{
    public static GameController instance = null;

    public static int racursCount = System.Enum.GetValues(typeof(RacursName)).Length;

    public Dictionary<RacursName, IRacurs> racurses = new Dictionary<RacursName, IRacurs>(racursCount);

    public InteractableToRacurs doorToRoom;
    public InteractableToRacurs roomToTable;
    public InteractableToRacurs roomToFloor;
    public InteractableToRacurs roomToCorpse;
    public InteractableToRacurs tableToWindow;

    public IRacurs currentRacurs;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            var racurs = Racurs.CreateRacurs(transform.GetChild(i).gameObject);
            racurses[(RacursName)i] = racurs;

            if (i > 0) racurs.DeactivateRacurs();
        }

        racurses[(RacursName)10] = RacursRoom.CreateRacurs(transform.GetChild(10).gameObject);
        racurses[RacursName.Room].DeactivateRacurs();

        for (int i = 11; i < racursCount; i++)
        {
            var racurs = RacursSides.CreateRacurs(transform.GetChild(i).gameObject);
            racurses[(RacursName)i] = racurs;

            if (i > 0) racurs.DeactivateRacurs();
        }

        racurses[RacursName.Corridor1WinL].SetForw(racurses[RacursName.Corridor2WinL]);
        racurses[RacursName.Corridor1WinL].SetPrev(racurses[RacursName.Corridor1WinR]);
        racurses[RacursName.Corridor1WinL].SetLeft(racurses[RacursName.Windows2]);
        racurses[RacursName.Corridor1WinL].SetRight(racurses[RacursName.Doors2]);
        racurses[RacursName.Corridor1WinL].SetButtons();

        racurses[RacursName.Corridor2WinL].SetForw(racurses[RacursName.Corridor3WinL]);
        racurses[RacursName.Corridor2WinL].SetPrev(racurses[RacursName.Corridor1WinL]);
        racurses[RacursName.Corridor2WinL].SetLeft(racurses[RacursName.Windows1]);
        racurses[RacursName.Corridor2WinL].SetRight(racurses[RacursName.Doors1]);

        racurses[RacursName.Corridor3WinL].SetPrev(racurses[RacursName.Corridor2WinL]);

        racurses[RacursName.Corridor1WinR].SetForw(racurses[RacursName.Corridor2WinR]);
        racurses[RacursName.Corridor1WinR].SetPrev(racurses[RacursName.Corridor1WinL]);
        racurses[RacursName.Corridor1WinR].SetLeft(racurses[RacursName.Doors3]);
        racurses[RacursName.Corridor1WinR].SetRight(racurses[RacursName.Windows3]);

        racurses[RacursName.Corridor2WinR].SetForw(racurses[RacursName.Corridor3WinR]);
        racurses[RacursName.Corridor2WinR].SetPrev(racurses[RacursName.Corridor1WinR]);
        racurses[RacursName.Corridor2WinR].SetLeft(racurses[RacursName.Doors4]);
        racurses[RacursName.Corridor2WinR].SetRight(racurses[RacursName.Windows4]);

        racurses[RacursName.Corridor3WinR].SetPrev(racurses[RacursName.Corridor2WinR]);

        racurses[RacursName.Windows1].SetPrev(racurses[RacursName.Corridor2WinL]);
        racurses[RacursName.Windows1].SetLeft(racurses[RacursName.Windows2]);

        racurses[RacursName.Windows2].SetPrev(racurses[RacursName.Corridor1WinL]);
        racurses[RacursName.Windows2].SetLeft(racurses[RacursName.Windows3]);
        racurses[RacursName.Windows2].SetRight(racurses[RacursName.Windows1]);

        racurses[RacursName.Windows3].SetPrev(racurses[RacursName.Corridor1WinR]);
        racurses[RacursName.Windows3].SetLeft(racurses[RacursName.Windows4]);
        racurses[RacursName.Windows3].SetRight(racurses[RacursName.Windows2]);

        racurses[RacursName.Windows4].SetPrev(racurses[RacursName.Corridor2WinR]);
        racurses[RacursName.Windows4].SetRight(racurses[RacursName.Windows3]);

        racurses[RacursName.Doors1].SetPrev(racurses[RacursName.Corridor2WinL]);
        racurses[RacursName.Doors1].SetRight(racurses[RacursName.Doors2]);

        racurses[RacursName.Doors2].SetPrev(racurses[RacursName.Corridor1WinL]);
        racurses[RacursName.Doors2].SetLeft(racurses[RacursName.Doors1]);
        racurses[RacursName.Doors2].SetRight(racurses[RacursName.Doors3]);

        racurses[RacursName.Doors3].SetPrev(racurses[RacursName.Corridor1WinR]);
        racurses[RacursName.Doors3].SetLeft(racurses[RacursName.Doors2]);
        racurses[RacursName.Doors3].SetRight(racurses[RacursName.Doors4]);

        racurses[RacursName.Doors4].SetPrev(racurses[RacursName.Corridor2WinR]);
        racurses[RacursName.Doors4].SetLeft(racurses[RacursName.Doors3]);

        racurses[RacursName.Room].SetPrev(racurses[RacursName.Doors2]);

        racurses[RacursName.Table].SetPrev(racurses[RacursName.Room]);

        racurses[RacursName.Floor].SetPrev(racurses[RacursName.Room]);

        racurses[RacursName.Corpse].SetPrev(racurses[RacursName.Room]);

        racurses[RacursName.Window].SetPrev(racurses[RacursName.Table]);

        doorToRoom.racurs = racurses[RacursName.Room];
        roomToTable.racurs = racurses[RacursName.Table];
        roomToFloor.racurs = racurses[RacursName.Floor];
        roomToCorpse.racurs = racurses[RacursName.Corpse];
        tableToWindow.racurs = racurses[RacursName.Window];

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
