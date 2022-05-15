using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Canvas menu;


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
            menu.enabled = true;
        }
    }

    //CONTINUE BUTTON
    public void HideMenu()
    {
        if (menu)
        {
            menu.enabled = false;
        }
    }

    //QUIT BUTTON
    public void Quit()
    {

    }

    //OPTION BUTTON
    public void Options()
    {

    }
}
