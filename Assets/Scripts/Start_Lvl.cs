using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Lvl : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void Awake()
    {
        player.position = transform.position;
        Time.timeScale = 1.0f;
    }
}
