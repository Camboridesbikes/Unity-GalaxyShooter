using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    [SerializeField]
    private float _moveSpeed = 4.0f;
    [SerializeField]
    private GameObject _explosion = null;

    private UIManager _uiManager;
    private GameManager _gameManager;

    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update () {

        Movement();
        
        if(_gameManager != null)
        {
            if(!_gameManager.gameOn)
            {
                Destroy(this.gameObject);
            }
        }
        
	}

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                //take player life away
                player.Damage();

                //instantiate explosion animation
                Instantiate(_explosion, transform.position, Quaternion.identity);
                //destroy self
                Destroy(this.gameObject);
            }
        }
        else if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            //instantiate explosion animation
            Instantiate(_explosion, transform.position, Quaternion.identity);

            if(_uiManager != null)
            {
                _uiManager.UpdateScore();
            }
            //destroy self
            Destroy(this.gameObject);
        }
        
    }

    void Movement()
    {
        float _randomX = Random.Range(-9f, 9f);
        transform.Translate(Vector3.down * _moveSpeed * Time.deltaTime);

        if (transform.position.y < -7)
        {
            transform.position = new Vector3(_randomX, 6.66f, 0);
        }

    }
}
