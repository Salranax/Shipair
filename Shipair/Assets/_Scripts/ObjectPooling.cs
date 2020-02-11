using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling instance;
    public GameObject objectPrefab;

    private List<GameObject> objectList = new List<GameObject>();

    private void Awake() {
       if(instance == null){
           instance = this;
       } 
    }

    public GameObject getObject(){
       if(objectList.Count > 0){
            GameObject _tmp = objectList[0];
            objectList.RemoveAt(0);
            return _tmp;
       } 
       else{
           GameObject _tmp = Instantiate(objectPrefab);
           _tmp.transform.SetParent(this.gameObject.transform);
           _tmp.transform.position = this.transform.position;
           return _tmp;
       }
    }

    public void retireObject(GameObject obj){
        obj.transform.position = this.transform.position;
        obj.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        obj.SetActive(false);
        objectList.Add(obj);
    }
}

public enum ObjectType
{
    wood,
    rope,
    metal
}
