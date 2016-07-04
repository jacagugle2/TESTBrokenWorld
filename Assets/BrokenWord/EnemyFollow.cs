using UnityEngine;
using System.Collections;

public class EnemyFollow : MonoBehaviour {

    Transform myTransform;
    Transform player;
    Rigidbody2D myRigidBody;
    public float speed = 10;
	// Use this for initialization
	void Start () {
        myTransform = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        myRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        myTransform.LookAt(player.position);
        myTransform.position += myTransform.forward * speed;
       // myRigidBody.AddForce(myTransform.forward * speed);
        
	}
}
