using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehavior : MonoBehaviour {

    [SerializeField]
    private float _speed = 10f;

	void Update () {
        //move at speed        
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        if(transform.position.y > 6)
        {
            Destroy(this.gameObject);
        }
	}
}
