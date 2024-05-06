using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private float weaponForce;

    // Start is called before the first frame update

    public float ShowWeaponForce()
    {
        return weaponForce;
    }

    
}
