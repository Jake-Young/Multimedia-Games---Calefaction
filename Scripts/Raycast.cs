using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour {

    public float MaxRayDistance;
    public float ViewAngle; 
    public static bool CanSeePlayer;
    public LayerMask TargetLayerMask;
    public LayerMask WallLayerMask;
    CircleCollider2D ThisCircleCollider;


	// Use this for initialization
	void Start () {
        ThisCircleCollider = GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //Ray ray = new Ray2D;
        //finds the angle between the player and the missile launcher
        Vector3 direction = transform.position;
        float angle = Vector3.Angle(direction, transform.right);
        //if the angle is less than half of the Launchers view angle then the player can be seen by the missile launcher
        if (angle < ViewAngle*0.5)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction.normalized, ThisCircleCollider.radius, 9);
            if (hit.collider == null)
            {
                CanSeePlayer = true;
            }
            else
            {
                CanSeePlayer = true;
            }
            Vector3 forward = transform.TransformDirection(Vector3.right) * 10;
            Debug.DrawRay(transform.position, direction, Color.red);

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
          
            
        }
    }

}
