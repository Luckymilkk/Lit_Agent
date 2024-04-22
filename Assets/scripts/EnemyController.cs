using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

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
    private bool isTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
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
        }
    }
    private void Death()
    {
        this.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }
}
