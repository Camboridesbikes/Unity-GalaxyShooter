using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private float _moveSpeed = 5.0f;
    [SerializeField]
    private int _lives = 3;
    [SerializeField]
    private float _fireRate = 0.25f;
    private float _nextFire = 0;

    [SerializeField]
    private GameObject _laserPrefab = null;
    [SerializeField]
    private GameObject _tripleShot = null;
    [SerializeField]
    private GameObject _explosion = null;
    [SerializeField]
    private GameObject _shield = null;
    [SerializeField]
    private GameObject[] _engines;

    private UIManager _uiManager;
    private GameManager _gameManager;
    private AudioSource _audioSource;


    public bool canTripleShot = false;
    public bool canSpeedBoost = false;
    public bool shieldOn = false;

    void Start () {
        transform.position = new Vector3(0, 0, 0);
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _audioSource = GetComponent<AudioSource>();
        if(_uiManager != null)
        {
            _uiManager.UpdateLives(_lives);
        }
	}
	
	void Update () {

        Movement();

        ShootLaser();

    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (canSpeedBoost)
        {
            transform.Translate(Vector3.right * _moveSpeed * 1.75f * horizontalInput * Time.deltaTime);
            transform.Translate(Vector3.up * _moveSpeed * 1.75f * verticalInput * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * _moveSpeed * horizontalInput * Time.deltaTime);
            transform.Translate(Vector3.up * _moveSpeed * verticalInput * Time.deltaTime);
        }

        transform.Translate(Vector3.right * _moveSpeed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * _moveSpeed * verticalInput * Time.deltaTime);

        if (transform.position.y > 0)
        {
            
            transform.position = new Vector3(transform.position.x, 0, 0);

        }
        else if (transform.position.y < -4.82)
        {
            transform.position = new Vector3(transform.position.x, -4.82f, 0);
        }

        if (transform.position.x > 10)
        {
            transform.position = new Vector3(-10f, transform.position.y, 0);
        }
        else if (transform.position.x < -10)
        {
            transform.position = new Vector3(10f, transform.position.y, 0);
        }
    }

    private void ShootLaser()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0) )
        {
            if(Time.time > _nextFire)
            {
                _audioSource.Play();
                _nextFire = Time.time + _fireRate;
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);

                if (canTripleShot)
                {
                    Instantiate(_tripleShot, transform.position, Quaternion.identity);
                }
            }
                
        }

    }

    private void CheckEngine()
    {
        if(_lives == 2)
        {
            _engines[Random.Range(0, 2)].SetActive(true);
        }
        else if(_lives == 1)
        {
            foreach(GameObject engine in _engines)
            {
                engine.SetActive(true);
            }
        }
        
    }

    public void Damage()
    {
        if (shieldOn)
        {
            shieldOn = false;
            _shield.SetActive(false);
            return;
           
        }
       
         --_lives;
        CheckEngine();
        if (_uiManager != null)
        {
            _uiManager.UpdateLives(_lives);
        }

        if (_lives == 0)
         {
             //instantiate death animation
             Instantiate(_explosion, transform.position, Quaternion.identity);
             Destroy(this.gameObject);
            _gameManager.EndGame();

         }
        

    }

    public void TripleShotPowerupOn()
    {
        canTripleShot = true;
        StartCoroutine(TripleShotPowerdownRoutine());
    }
    
    IEnumerator TripleShotPowerdownRoutine()
    {
        yield return new WaitForSeconds(5.0f);

        canTripleShot = false;
    }

    public void SpeedBoostPowerupOn()
    {
        canSpeedBoost = true;
        StartCoroutine(SpeedBoostPowerdownRoutine());
    }

    IEnumerator SpeedBoostPowerdownRoutine()
    {
        yield return new WaitForSeconds(5.0f);

        canSpeedBoost = false;
    }

    public void ShieldPowerupOn()
    {
        shieldOn = true;

        _shield.SetActive(true);
        
    }
}
