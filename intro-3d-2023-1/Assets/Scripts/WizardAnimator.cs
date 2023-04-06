using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAnimator : MonoBehaviour
{
    [SerializeField]
    private Animator _anim;

    private bool _isAttacking = false;

    void Update()
    {
        //Logic
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isAttacking = true;
        }
        
        //Update animations
        _anim.SetBool("IsAttacking1", _isAttacking);
        _anim.SetBool("IsAttacking2", _isAttacking);
        //_anim.SetFloat("Velocity", 0);

        if (_isAttacking)
        {
            _anim.SetTrigger("Attack");
            _isAttacking = false;
        }
        
    }
}
