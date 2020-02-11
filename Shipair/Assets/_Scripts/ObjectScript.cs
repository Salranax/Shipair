using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    public GameObject wood;
    public GameObject rope;
    public GameObject metal;
    public ObjectType objType;

    public void contruct(){
        int _rnd = Random.Range(0,3);
        float _rndPosition = Random.Range(-5.0f, 5.0f);

        switch (_rnd)
        {
            case 0:
                objType = ObjectType.rope;
                rope.SetActive(true);
                break;
            case 1:
                objType = ObjectType.wood;
                wood.SetActive(true);
                break;
            case 2:
                objType = ObjectType.metal;
                metal.SetActive(true);
                break;
        }

        transform.position = new Vector2(_rndPosition, transform.position.y);
        GetComponent<Rigidbody2D>().velocity = Vector2.down * 3;
    }

    private void OnMouseDown() {
        ObjectPooling.instance.retireObject(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Despawner")){
            ObjectPooling.instance.retireObject(this.gameObject);
        }
        
    }
}
