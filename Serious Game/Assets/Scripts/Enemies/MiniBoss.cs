using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MiniBoss : MonoBehaviour
{

    [SerializeField] public Transform _target;
    NavMeshAgent _angent;

    void Start()
    {
        _angent = GetComponent<NavMeshAgent>();
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform == _target)
            SceneManager.LoadScene("GameOver"); 
         
    }
    // Update is called once per frame
    void Update()
    {
        _angent.SetDestination(_target.position);
    }
}
