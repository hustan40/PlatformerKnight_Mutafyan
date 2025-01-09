using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public bool isAliveMov = true;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        float horizontalDirection = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
        bool jumpIsOn = Input.GetButtonDown(GlobalStringVars.JUMP);
        bool fireIsOn = Input.GetButtonDown(GlobalStringVars.FIRE_1);
        if (isAliveMov)
        {
            playerMovement.Move(horizontalDirection, jumpIsOn, fireIsOn);
        }
    }
}
