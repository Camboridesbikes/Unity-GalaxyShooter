using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private int powerUpId; //0 = tripleShot, 1 = Speed, 2 = Shields
    [SerializeField]
    private AudioClip _clip;
    


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
    }

    private void Movement()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if(transform.position.y < -7)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if(player != null)
            {
                AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position);
                //enable tripleShot
                if(powerUpId == 0)
                {
                    player.TripleShotPowerupOn();
                }
                else if(powerUpId == 1) 
                {
                    //enable speedBoost
                    player.SpeedBoostPowerupOn();
                }
                else if (powerUpId == 2)
                {
                    //enable shield
                    player.ShieldPowerupOn();
                }

                Destroy(this.gameObject);
            }
           
        }
        
    }

}
