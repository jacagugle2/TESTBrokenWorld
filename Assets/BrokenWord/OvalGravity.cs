using UnityEngine;
using System.Collections;

public class OvalGravity : MonoBehaviour {

    Rigidbody2D myRigidBody;
    CircleCollider2D myColider;
    PointEffector2D myPointEffector;
    TargetJoint2D myTargetJoint;
    

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
       /* CircleCollider2D[] coliderTab = GetComponents<CircleCollider2D>();
        if (!coliderTab[0].enabled)
            myColider = coliderTab[0];
        else
            myColider = coliderTab[1];*/
        myTargetJoint = GetComponent<TargetJoint2D>();
        myColider = GetComponent<CircleCollider2D>();
        myPointEffector = GetComponent<PointEffector2D>();
        DisableTargetJoint();
	}

    void Awake()
    {
        EventManager.EventStartedMoving += StartVibration;
        EventManager.EventStoppedMoving += StopVibration;
        EventManager.EventSpaceClicked += ChangeGravity;
        EventManager.EventStoppedMoving += EnableTargetJoint;
        EventManager.EventStartedMoving += DisableTargetJoint;
    }

    void OnDestroy()
    {
        EventManager.EventStartedMoving -= StartVibration;
        EventManager.EventStoppedMoving -= StopVibration;
        EventManager.EventSpaceClicked -= ChangeGravity;
        EventManager.EventStoppedMoving -= EnableTargetJoint;
        EventManager.EventStartedMoving -= DisableTargetJoint;
    }

    void StartVibration()
    {
        //myRigidBody.isKinematic = false;
        myColider.enabled = true;
        myPointEffector.enabled = true;
        StopAllCoroutines();
    }

    void StopVibration()
    {
       // myRigidBody.isKinematic = true;
        myColider.enabled = false;
        myPointEffector.enabled = false;
        myRigidBody.velocity = Vector2.zero;
    }

    void ChangeGravity()
    {
        myPointEffector.forceMagnitude *= (-1);
    }

    void DisableTargetJoint()
    {
        myTargetJoint.enabled = false;
    }

    void EnableTargetJoint()
    {
        myTargetJoint.enabled = true;
    }

 
}
