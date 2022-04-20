using Assets.Scripts.System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private Transform point;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Destroy(collision.gameObject);

            //TODO : animation | particles

            var _levelManager = LevelManager.instance;
            if (_levelManager.HasUsable()) point = _levelManager.GetPoint();
            else point = _levelManager.DefaultSpawnPoint;
            collision.gameObject.transform.position = point.position;
        }
    }
}
