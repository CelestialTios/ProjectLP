using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Player
{
    public class Character : MonoBehaviour
    {
        public Dictionary<string, bool> level;
        public List<Sprite> skins;
        public string[] skinsAvailable;
        public int selectedSkin = 0;
        public int currency;



        public void AddCurrency(int value)
        {
            currency += value;
        }
    }
}