using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public bool isLocalPlayer;

    [Header("UI")]
    public TextMeshProUGUI healthText;

    [PunRPC]
    public void TakeDamage(int damage)
    {
        health -= damage;

        healthText.text = health.ToString();

        if(health <= 0)
        {
            if (isLocalPlayer)
            {
                RoomManager.instance.RespawnPlayer();
            }
                   
            Destroy(gameObject);
        }
    }
}
