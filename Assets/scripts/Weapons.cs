using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    // Start is called before the first frame update
    /*[SerializeField]
    private PlayerController player;
    [SerializeField]
    private float weaponForce;
    [SerializeField]
    private float attackForce;*/
    [SerializeField]
    private int index;
    [SerializeField]
    private bool isFound = false;
    /*[SerializeField]
    private bool Catch = false;*/

    /* void Start()
     {
         GameObject playerObj = GameObject.FindWithTag("Player");
         player = playerObj.GetComponent<PlayerController>();

     }


     private void WeaponAttack()
     {

     }

     public float ShowAttackForce()
     {
         attackForce = player.AttackForce() + weaponForce;
         return attackForce;
     }*/
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isFound = true;
        }
    }

    public bool ShowIsFound()
    {
        return isFound;
    }
    public int ShowIndex()
    {
        return index;
    }

  

    /*public void AttackStarted()
    {

    }*/
}
