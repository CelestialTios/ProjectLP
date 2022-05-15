using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class MenuManager : MonoBehaviour
    {
        public GameObject menu;
        public static bool GameIsPaused = false;

        // Start is called before the first frame update
        void Start()
        {
            HideMenu();
        }

        // PAUSE BUTTON
        public void ShowMenu()
        {
            if (menu)
            {
                menu.SetActive(true);
                Time.timeScale = 0f;
                GameIsPaused = true;
            }
        }

        //CONTINUE BUTTON
        public void HideMenu()
        {
            if (menu)
            {
                menu.SetActive(false);
                Time.timeScale = 1f;
                GameIsPaused = false;
            }
        }

        //QUIT BUTTON
        public void Quit()
        {
            Debug.Log("Quit menu...");
            Application.Quit();
        }

        //OPTION BUTTON
        public void Options()
        {
            Debug.Log("Options menu...");
        }
    }
}


