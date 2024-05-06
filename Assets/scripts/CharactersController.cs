using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject player;
    private Vector3 offset;
    
    void Start()
    {
        offset = transform.position - player.transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;        
    }
}
