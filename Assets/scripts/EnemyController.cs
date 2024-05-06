using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;
    [SerializeField]
    private Weapons weapons;
    [SerializeField]
    private float enemyHealth = 50f;
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private Transform triggerPoint;
    [SerializeField]
    private GameObject DamageZone;
    [SerializeField]
    private Slider enemySliderHp;
    [SerializeField]
    private bool isTriggered = false;
    private Rigidbody rb;
    
    private int cnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        GameObject playerObj = GameObject.FindWithTag("Player");
        player = playerObj.GetComponent<PlayerController>();
        GameObject weaponObj = GameObject.FindWithTag("Weapon");
        weapons = weaponObj.GetComponent<Weapons>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isTriggered == true)
        {
            //gameObject.transform.position = speed * triggerPoint.transform.position;
            gameObject.transform.position =  Vector3.MoveTowards(transform.position, triggerPoint.position, speed * Time.deltaTime);
        }
        if (enemyHealth <= 0)
        {
            Death();
        }
        enemySliderHp.value = enemyHealth;
    }

    //метод, который отбрасывает противника
    public void Jump()
    {
        rb.AddForce(transform.position *1f, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Trigger Zone"))
        {
            isTriggered = true;
        }
        if (collision.gameObject.CompareTag("melee attack"))
        {
            enemyHealth -= player.AttackForce();
            rb.AddForce(Vector3.forward * 2, ForceMode.Impulse);
            Jump();
        }
        if (collision.gameObject.CompareTag("Player") && cnt == 0)
        {
            DamageZone.SetActive(true);
            cnt += 1;
        }
        if (cnt > 1)
        {
            DamageZone.SetActive(false);
            cnt = 0;
        }
    }
    private void Death()
    {
        this.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }
}
