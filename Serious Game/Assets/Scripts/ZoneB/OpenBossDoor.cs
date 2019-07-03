using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBossDoor : MonoBehaviour
{
    [SerializeField] private Collider _doorCollider;
    void Start()
    {
        if (Globals.bossesBeaten == 0) {
            _doorCollider.enabled = false;
        }
        else {
            _doorCollider.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
