using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    private float moveSpeed = 5;
    [SerializeField]
    private AudioClip _clip;

    private void Start()
    {
        AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position);
    }

    // Update is called once per frame
    void Update () {

        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

        if (transform.position.y < -7)
        {
            Destroy(this.gameObject);
        }
	}


}
