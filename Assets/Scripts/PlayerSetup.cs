using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    public PlayerMovement playerMovement;

    public GameObject playerCamera;

    public void isLocalPlayer()
    {
        playerMovement.enabled = true;
        playerCamera.SetActive(true);
    }
}
