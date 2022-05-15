using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Player
{
    public class Character : MonoBehaviour
    {
        [Header("Currency")]
        [SerializeField]private Text currencyText;
        public int currency;


        public Dictionary<string, bool> level;
        public List<Sprite> skins;
        public string[] skinsAvailable;
        public int selectedSkin = 0;


        private void Start()
        {
            if (currencyText)
            {
                currencyText.text = currency.ToString();
            }
        }



        public void AddCurrency(int value)
        {
            currency += value;
            currencyText.text = currency.ToString();
        }
    }
}