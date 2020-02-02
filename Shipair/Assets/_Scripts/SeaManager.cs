using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaManager : MonoBehaviour
{
    public float speed;
    public GameObject[] seaObjects;
    public float seaSpriteHeight;

    private void Update()
    {
        GoForwardEffect();
    }
    public void GoForwardEffect()
    {
        for (int i = 0; i < seaObjects.Length; i++)
        {
            seaObjects[i].transform.localPosition += new Vector3(0,-(speed * Time.deltaTime),0);
        }
        if(seaObjects[0].transform.localPosition.y < -(seaSpriteHeight / 100f))
        {
            for (int i = 0; i < seaObjects.Length; i++)
            {
                seaObjects[i].transform.localPosition += new Vector3(0, +(seaSpriteHeight / 100f), 0);
            }
        }

    }
}
