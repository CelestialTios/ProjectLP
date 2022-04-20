using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.System
{
    public class LevelManager : MonoBehaviour
    {
        #region Singleton
        public static LevelManager instance;

        private void Awake()
        {
            instance = this;
        }
        #endregion

        public Transform DefaultSpawnPoint;

        [SerializeField]
        public RespawnPoint[] spawnAvailable;

        public void SetUsable(Transform point)
        {
            int i = 0;
            while(i < spawnAvailable.Length && !spawnAvailable[i].point.position.Equals(point.position)) { i++; }
            if(!spawnAvailable[i].usable)spawnAvailable[i].usable = true;
        }

        public bool HasUsable()
        {
            int i = 0;
            while( i < spawnAvailable.Length)
            {
                if( spawnAvailable[i].usable) return true;
                i++;
            }
            return false;
        }

        public Transform GetPoint()
        {
            int i = spawnAvailable.Length;
            while (i > 0)
            {
                i--;
                if (spawnAvailable[i].usable) return spawnAvailable[i].point;
            }
            return null;
        }
    }

    [Serializable]
    public class RespawnPoint
    {
        public Transform point;
        public bool usable = false;
    }
}