using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewController : MonoBehaviour
{
    public static CrewController instance;
    private List<CrewMember> crewMembers = new List<CrewMember>();
    private List<CrewMember> availableCrewMember = new List<CrewMember>();

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
        
    }

    public void addAvailableCrew(CrewMember cr){
        availableCrewMember.Add(cr);
    }

    public void addCrewMember(CrewMember cr){
        crewMembers.Add(cr);
        addAvailableCrew(cr);
    }

    public CrewMember getAvailableCrewMember(){
        if(availableCrewMember.Count > 0){
            CrewMember tmp = crewMembers[0];
            availableCrewMember.RemoveAt(0);
            return tmp;
        }
        else{
            return null;
        }
    }
}
