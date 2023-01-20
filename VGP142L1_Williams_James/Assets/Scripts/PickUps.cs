using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class PickUp : MonoBehaviour
{
    public enum PickupType
    {
        jump = 0,
        speed = 1,
        score = 2
    }

    public PickupType currentPickup;

    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (currentPickup)
            {
                case PickupType.speed:
                    break;
                case PickupType.jump:
                    break;
                case PickupType.score:
                    break;
            }

            Destroy(gameObject);
        }
    }
}
