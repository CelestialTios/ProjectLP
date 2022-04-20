using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Player;

namespace Assets.Scripts.Utils
{
    [Serializable]
    public class PlayerData
    {
        public string[] level;
        public bool[] completed;
        public int skin;
        private string[] bought;

        public PlayerData(Character player)
        {
            completed = new bool[player.level.Count];
            int i = 0;
            var values = player.level.Values.GetEnumerator();
            while(i < player.level.Count)
            {
                completed[i] = values.Current;
                i++;
                values.MoveNext();
            }

            skin = player.selectedSkin;
            bought = new string[player.skinsAvailable.Length];
            for (int j = 0; j < player.skinsAvailable.Length; j++)
            {
                bought[j] = player.skinsAvailable[j];
            }

        }
    }
}
