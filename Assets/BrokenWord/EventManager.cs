using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventManager
{
    // przed utworzeniem nowego poziomu (tutaj kasujemy rzeczy)
    /*public delegate void BeforeNewLevelHandler();
    public static event BeforeNewLevelHandler EventBeforeNewLevel;
    public static void RaiseEventBeforeNewLevel()
    {
        if (EventBeforeNewLevel != null) EventBeforeNewLevel();
    }
    */

    public delegate void StartedMoving();
    public static event StartedMoving EventStartedMoving;
    public static void RaiseEventStartedMoving()
    {
        if (EventStartedMoving != null) EventStartedMoving();
    }

    public delegate void StoppedMoving();
    public static event StoppedMoving EventStoppedMoving;
    public static void RaiseEventStoppedMoving()
    {
        if (EventStoppedMoving != null) EventStoppedMoving();
    }

    public delegate void SpaceClicked();
    public static event SpaceClicked EventSpaceClicked;
    public static void RaiseEventSpaceClicked()
    {
        if (EventSpaceClicked != null) EventSpaceClicked();
    }
}
