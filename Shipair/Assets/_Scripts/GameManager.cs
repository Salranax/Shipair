using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject crewPrefab;
    public GameObject repairPartPrefab;

    private float shipHealth = 100;

    void Awake()
    {
        if(instance == null){
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject tmp = Instantiate(crewPrefab, new Vector2(0,0), Quaternion.identity);
        CrewController.instance.addCrewMember(tmp.GetComponent<CrewMember>());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void giveDamage(float dmg){
        shipHealth -= dmg;
        //UIManager.instance.updateHealthBar();
    }

    public float getHealth(){
        return shipHealth;
    }
}
