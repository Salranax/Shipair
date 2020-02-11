using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject errorMessage;
    public Slider healthBar;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null){
            instance = this;
        }
    }

    public void noCrewError(){
        errorMessage.SetActive(true);
    }

    public void updateHealthBar(){
        healthBar.value = GameManager.instance.getHealth();
    }
}
