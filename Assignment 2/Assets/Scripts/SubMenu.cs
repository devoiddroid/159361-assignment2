using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMenu : MonoBehaviour
{
    public GameObject subMenu;
    public GameObject menu;
    public GameObject title;

    // check if menu or submenu is active then switch them, turning off or on title if it exists as required
    public void switchMenu(){
        if (menu.activeSelf){
            if(title != null){
                title.SetActive(false);
            }
            subMenu.SetActive(true);
            menu.SetActive(false);
        } else {
            if(title != null){
                title.SetActive(true);
            }
            menu.SetActive(true);
            subMenu.SetActive(false);
            
        }
    }

}
