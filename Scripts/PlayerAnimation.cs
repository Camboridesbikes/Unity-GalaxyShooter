using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    [SerializeField]
    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //if w key is pressed
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            _anim.SetBool("Turn_Right", true);
            _anim.SetBool("Turn_Left", false);
        }

        //if w key is lifted
        if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            _anim.SetBool("Turn_Right", false);
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _anim.SetBool("Turn_Left", true);
            _anim.SetBool("Turn_Right", false);
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _anim.SetBool("Turn_Left", false);
        }
    }
}
