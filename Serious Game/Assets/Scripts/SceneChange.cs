using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] Material _night;
    public GameObject player;
    public Collider coll;
    public string sceneToChange;

    public Vector3 setPos;

    static Vector3 posNow = new Vector3(0,0,0);
    static bool sceneChanged = false;

    // Start is called before the first frame update
    void Start()
    {
        //if (sceneChanged)
        //{
        //    player.transform.position = posNow;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider coll) {

        //posNow = setPos;
        //sceneChanged = true;

        if(coll.tag == "Player" && RenderSettings.skybox!=_night)
        {
            SceneManager.LoadScene(sceneToChange);
            //player.transform.position = tempPos;
        }

    }
}
