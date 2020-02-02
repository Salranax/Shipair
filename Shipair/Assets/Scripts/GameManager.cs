using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject crewPrefab;
    public GameObject repairPartPrefab;

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
}
