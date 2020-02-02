using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deactiveAuto : MonoBehaviour
{
    public float deactivetime;
    private float timePassed;

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if(timePassed >= deactivetime){
            timePassed = 0;
            gameObject.SetActive(false);
        }
    }
}
