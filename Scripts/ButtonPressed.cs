using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressed : MonoBehaviour
{
    Collider2D ButtonCollider;
    private bool IsPressed = false;
    public Component[] TheDoor; //The door attached to the button


    private void Start()
    {
        ButtonCollider = GetComponent<Collider2D>();
        TheDoor = GetComponentsInChildren<OpenDoor>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Missile")
        {
            ButtonCollider.enabled = false;
            IsPressed = true;
            Debug.Log("Did it");
            foreach (OpenDoor door in TheDoor)
            {
                door.OpenTheDoor();
            }
                

        }
    }



}
