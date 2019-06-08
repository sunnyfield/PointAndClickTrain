

using UnityEngine;

public class RacursSides : Racurs
{
    protected RacursSides()
    { }


    public static new RacursSides CreateRacurs(GameObject obj)
    {
        RacursSides racurs = new RacursSides { gameObject = obj };
        return racurs;
    }

    protected override void Left()
    {
        if (leftRacurs == null) return;

        DeactivateRacurs();
        leftRacurs.ActivateRacurs();
        leftRacurs.SetPrev(prevRacurs);
    }

    protected override void Right()
    {
        if (rightRacurs == null) return;

        DeactivateRacurs();
        rightRacurs.ActivateRacurs();
        rightRacurs.SetPrev(prevRacurs);
    }
}
