using UnityEngine;
using System.Collections;

public class StartStopHitCollider : MonoBehaviour {


    GameObject thisGameObject;

    void Start()
    {
        thisGameObject = gameObject;
        thisGameObject.SetActive(false);
    }

    void Awake()
    {
        EventManager.EventStartedMoving += () => {thisGameObject.SetActive(true);};
        EventManager.EventStoppedMoving += () => { thisGameObject.SetActive(false); };
    }

    void OnDestroy()
    {
        EventManager.EventStartedMoving -= () => { thisGameObject.SetActive(true); };
        EventManager.EventStoppedMoving -= () => { thisGameObject.SetActive(false); };
    }
    

}
