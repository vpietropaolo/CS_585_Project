using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnParticleCollision(GameObject target)
    {
        if (target.tag == "Player")
        {
            Debug.Log("Player took damage");
        }
    }
}
