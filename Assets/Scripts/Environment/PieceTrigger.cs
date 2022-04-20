using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceTrigger : MonoBehaviour
{
    public int value = 10;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);

        if(collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Character>().AddCurrency(value);
        }
    }
}
