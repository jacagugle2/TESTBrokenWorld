using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Vibration : MonoBehaviour {

    public class childObject
    {
        public childObject(Rigidbody2D rb, Vector2 fd)
        {
            rigidBody = rb;
            forceDirection = fd;
        }
        public Rigidbody2D rigidBody;
        public Vector2 forceDirection;
    }

    List<childObject> listOfChilds;
    public static bool isKinematic = true;

	// Use this for initialization
	void Start () {
        var num = gameObject.transform.childCount;
        Transform childTransform;

        listOfChilds = new List<childObject>();
        for (int i = 0; i < num; i++)
        {
            childTransform = gameObject.transform.GetChild(i).transform;           
            listOfChilds.Add(
                new childObject(
                childTransform.GetComponent<Rigidbody2D>(),
                Normalize(childTransform.localPosition)
                ));
        }
	}

    void Awake()
    {
        EventManager.EventStartedMoving += StartVibration;
        EventManager.EventStartedMoving += () => SetIsKinematic(false);

        EventManager.EventStoppedMoving += StopVibration;
        EventManager.EventStoppedMoving += () => SetIsKinematic(true);
    }

    void OnDestroy()
    {
        EventManager.EventStartedMoving -= StartVibration;
        EventManager.EventStartedMoving -= () => SetIsKinematic(false);

        EventManager.EventStoppedMoving -= StopVibration;
        EventManager.EventStoppedMoving -= () => SetIsKinematic(true);
    }

    Vector2 Normalize(Vector2 v)
    {
        return new Vector2( v.x / Mathf.Abs(v.x) , v.y / Mathf.Abs(v.y));
    }

    void StartVibration()
    {
        StartCoroutine(Vibrating());
    }

    void StopVibration()
    {
        StopCoroutine(Vibrating());
    }

    void Vibrate()
    {
        foreach (var obj in listOfChilds)
        {
            obj.rigidBody.AddForce(new Vector2(obj.forceDirection.x * Random.Range(10,11), obj.forceDirection.y * Random.Range(1,3)));
        }
    }

    IEnumerator Vibrating()
    {
        Vibrate();
        yield return new WaitForSeconds(0.1f);
    }

    void SetIsKinematic(bool var)
    {
            isKinematic = var;
            foreach (var obj in listOfChilds)
                obj.rigidBody.isKinematic = var;
    }

	
	// Update is called once per frame
	void Update () {
	    // po nacisnieciu klawisz
        //EventManager.RaiseEventMoving();
	}
}
