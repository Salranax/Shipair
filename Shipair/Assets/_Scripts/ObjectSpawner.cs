using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public float spawnRate = 35;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 0.3f){
            int _rnd = Random.Range(0,101);
            if(_rnd <= spawnRate){
                spawnObject();
            }
            timer = 0;
        }
    }

    private void spawnObject(){
        GameObject _obj = ObjectPooling.instance.getObject();
        _obj.SetActive(true);
        _obj.GetComponent<ObjectScript>().contruct();
    }
}
