using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Weapons weapons;
    [SerializeField]
    private WeaponController[] playerweapon;
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float attackForce;
    [SerializeField]
    private float force = 10f;
    [SerializeField]
    private float kd = 0;
    [SerializeField]
    private int i = 0;
    [SerializeField]
    private GameObject Attack;
    [SerializeField]
    private GameObject[] tmpWeapon;

    private float movementX;
    private float movementZ;   
    private Rigidbody rb;
    private bool isAttack = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();       
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(movementX * speed, 0, movementZ * speed);

        kd -= Time.deltaTime;
        if (kd <= 0)
        {
            kd = 0;
        }
        if (kd>0 && kd <=1)
        {
            Attack.SetActive(false);
        }


    }

    public void OnMove(InputValue inputValue)
    {
        Vector2 movementValue = inputValue.Get<Vector2>();
        movementX = movementValue.x;
        movementZ = movementValue.y;
    }

    public void OnFire()
    {
        //weapons.AttackStarted();

        if(kd == 0 || kd >1)
        {
            print("ok");
            Attack.SetActive(true);
            kd = 2;
        }
      
    }

   /* private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            tmpWeapon[i].SetActive(false);
            weapons = collision.gameObject.GetComponent<Weapons>();
            i = weapons.ShowIndex();
            tmpWeapon[i].SetActive(true);
            //playerweapon = gameObject.GetComponent<WeaponController>();
            attackForce = force + playerweapon[i].ShowWeaponForce();
            print(attackForce);

        }
    }*/

    public float AttackForce()
    {
        return attackForce;
    }


}
