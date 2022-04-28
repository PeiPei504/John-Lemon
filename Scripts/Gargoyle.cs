using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gargoyle : MonoBehaviour
{
    public GameObject player;
    bool isPlayerInRange;
    public GameEndTrigger gameEndTrigger;

    void Update()
    {
        if (isPlayerInRange)
            gameEndTrigger.CaughtPlayer();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
            isPlayerInRange = true;
    }

    
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
            isPlayerInRange = false;
    }
}
