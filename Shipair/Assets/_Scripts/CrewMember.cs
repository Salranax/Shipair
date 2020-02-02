using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewMember : MonoBehaviour
{
    public static CrewMember instance;
    private RepairStage assignedRepair;
    private Vector2 assignmentPosition;
    private bool moveAssignment;
    private float speed = 2f;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null){
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(moveAssignment){
            if(Vector2.Distance(transform.position, assignmentPosition) < 0.2f){
                moveAssignment = false;
                startRepair();
            }
            else{
                transform.position = Vector2.MoveTowards(transform.position, assignmentPosition, speed * Time.deltaTime);
            }
            
        }
    }

    public void assignRepair(RepairStage rp){
        assignedRepair = rp;
        assignmentPosition = assignedRepair.getPosition();
        goToAssignment();
    }

    private void goToAssignment(){
        moveAssignment = true;
    }

    private void startRepair(){
        assignedRepair.startRepair();
    }

    public void retireCrew(){
        assignedRepair = null;
        CrewController.instance.addAvailableCrew(this);
    }

}
