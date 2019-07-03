using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(changeScene());
    }

    IEnumerator changeScene()
    {
        while (true) {
            yield return new WaitForSeconds(3);
            SceneManager.LoadSceneAsync("ZoneA");
            yield break;
        }

    }
}
