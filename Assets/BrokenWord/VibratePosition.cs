using UnityEngine;
using System.Collections;

public class VibratePosition : MonoBehaviour {

    Transform myTransform;
    Vector3 myFirstPosition;
    const float positionRange = 0.01f;
	// Use this for initialization
	void Start () {
        myTransform = GetComponent<Transform>();
        myFirstPosition = myTransform.localPosition;
	}
	
	 void Awake()
    {
        EventManager.EventStartedMoving += StartVibration;
        EventManager.EventStoppedMoving += StopVibration;
    }

     void OnDestroy()
     {
         EventManager.EventStartedMoving -= StartVibration;
         EventManager.EventStoppedMoving -= StopVibration;
     }

     void StartVibration()
     {
         myTransform.localPosition += new Vector3(Random.Range(-positionRange, positionRange), Random.Range(-positionRange,positionRange), 0);
     }

     void StopVibration()
     {
         myTransform.localPosition = myFirstPosition;
     }
}
