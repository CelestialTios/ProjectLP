using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZone : MonoBehaviour
{

    [SerializeField]private Sprite WinSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Gus_WinLevel");
            var gamObj = collision.gameObject.GetComponent<PlayerMovement>();
            gamObj.WinState(WinSprite);

            //FindObjectOfType<AudioManager>().Play("Win");

        }
    }
}
