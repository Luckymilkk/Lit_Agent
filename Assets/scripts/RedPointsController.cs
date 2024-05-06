using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPointsController : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
