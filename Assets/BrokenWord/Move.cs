using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	// Use this for initialization
    bool isMoving = false;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftShift))
            EventManager.RaiseEventSpaceClicked();

        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)))
        {
            EventManager.RaiseEventStartedMoving();
            isMoving = true;
        }
        else
        {
            if (isMoving)
            {
                isMoving = false;
                EventManager.RaiseEventStoppedMoving();
            }
        }
	}
}
