using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairStage : MonoBehaviour
{
    public GameObject timeSliderObj;
    private Slider timeSlider;
    private bool isRepairing = false;
    private float repairTime;
    private float timePassed;
    private CrewMember assignedCrew;
    private float damagesSecons = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        timeSlider = timeSliderObj.GetComponent<Slider>();
        repairTime = Random.Range(5,8);
        timeSlider.maxValue = repairTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(isRepairing){
            timePassed += Time.deltaTime;
            timeSlider.value = timePassed;
            if(timePassed >= repairTime){
                isRepairing = false;
                assignedCrew.retireCrew();
                Destroy(this.gameObject);
            }
        }
        else{
           GameManager.instance.giveDamage(damagesSecons * Time.deltaTime); 
        }

    }

    public void startRepair(){
        timeSliderObj.SetActive(true);
        isRepairing = true;
        timeSlider.value = 0;
    }

    public Vector2 getPosition(){
        return transform.position;
    }

    void OnMouseDown()
    {
        assignedCrew = CrewController.instance.getAvailableCrewMember();
       
        if(assignedCrew != null){
            assignedCrew.assignRepair(this);
        }
        else{
            UIManager.instance.noCrewError();
        }
    }
}
