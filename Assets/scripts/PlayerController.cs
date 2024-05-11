using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    private float hp= 500f;
    [SerializeField]
    private GameObject Attack;
    [SerializeField]
    private GameObject weaponModelObj;
    [SerializeField]
    private GameObject[] tmpWeapon;
    [SerializeField]
    private Slider playerSliderHp;


    private Transform playerTransform;
    private float movementX;
    private float movementZ;   
    private Rigidbody rb;
    private bool isAttack = false;
    [SerializeField]
    private bool isdialog = false;
    private AudioManager audioManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();   
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
        if (kd>0 && kd <=1.5)
        {
            Attack.SetActive(false);
        }

        playerSliderHp.value = hp;
        if(hp <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);            
        }

        playerTransform = transform;
        if(transform != playerTransform)
        {
            audioManager.Play("walk"); 
        }
        else
        {
            audioManager.Stop("walk");
        }
    }

    private void MovementSound()
    {
        //if(transform.h)
        //audioManager.Stop("walk");
    }

    public void OnMove(InputValue inputValue)
    {
        Vector2 movementValue = inputValue.Get<Vector2>();
        movementX = movementValue.x;
        movementZ = movementValue.y;
        //audioManager.Play("walk");
    }

    public void OnFire()
    {
        //weapons.AttackStarted();

        if(kd == 0 || kd ==2)
        {
            print("ok");
            Attack.SetActive(true);
            kd = 2;
            /*GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
            enemy.GetComponent<EnemyController>().Jump();*/
        }
        
        //Мы вызвали тут метод отбрасывания, чтобы проверить его работу
        //MoveTowards действительно мешает увидеть эффект отбрасывания
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            
            tmpWeapon[i].SetActive(false);
            weapons = collision.gameObject.GetComponent<Weapons>();
            i = weapons.ShowIndex();
            if(weaponModelObj.transform.position.z - transform.position.z <= 2 && weaponModelObj.transform.position.z - transform.position.z >= -2)
            {
                if (transform.position.x - weaponModelObj.transform.position.x <= 2 && transform.position.x - weaponModelObj.transform.position.x >= -2)
                {
                    tmpWeapon[i].SetActive(true);
                    //playerweapon = gameObject.GetComponent<WeaponController>();
                    attackForce = force + playerweapon[i].ShowWeaponForce();
                    weaponModelObj.SetActive(false);
                    print(attackForce);
                }
            }           
        }
        if (collision.gameObject.CompareTag("Damage"))
        {
            hp -= 25f;
        }
    }

    public float AttackForce()
    {
        return attackForce;
    }

    private void OnDialog()
    {    
      print("dialog");
      isdialog = true;
     
    }

    public bool ShowDialog()
    {
        return isdialog;
    }

    public void DialogIsFinished()
    {
        isdialog = false;
    }
}
