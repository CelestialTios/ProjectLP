using UnityEngine;
using System.Collections;
using Assets.Scripts.System;

namespace Assets.Scripts.Environment
{
    public class RespawnZone : MonoBehaviour
    {

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "Player")
            {
                Debug.Log("Point added to saved point");
                LevelManager.instance.SetUsable(transform);
                Disappear();
            }
        }

        public bool Disappear()
        {
            try
            {
                Destroy(GetComponent<BoxCollider2D>());
                Destroy(GetComponent<SpriteRenderer>());
                Destroy(this);
            }
            catch (UnityException)
            {
                return false;
            }
            return true;
            
        }
    }
}