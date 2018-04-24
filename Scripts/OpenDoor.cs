using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    Collider2D DoorCollider;
    private bool IsOpen = false;

    private void Start()
    {
        DoorCollider = GetComponent<Collider2D>();
    }
    public void OpenTheDoor()
    {
        IsOpen = true;
        DoorCollider.enabled = false;
        Debug.Log("The Door is open");

    }

}

