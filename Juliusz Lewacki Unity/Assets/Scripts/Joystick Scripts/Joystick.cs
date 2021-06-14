using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private PlayerMoveJoystick playerMove;
    // Start is called before the first frame update
    void Start()
    {
        playerMove = GameObject.Find ("Player").GetComponent<PlayerMoveJoystick> ();
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (gameObject.name == "Left") {
            playerMove.SetMoveLeft(true);
        } else {
            playerMove.SetMoveLeft(false);
    }
    }
    // Update is called once per frame
    public void OnPointerUp(PointerEventData data)
    {
        playerMove.StopMoving ();
    }
}
