using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MinigameStart : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _npcDialog;
    [SerializeField] private GameObject _clueObject;
    [SerializeField] private Transform _npcDialogOutput;
    [SerializeField] private TextAsset[] _tests;
    [SerializeField] private string[] _letter;
    //[SerializeField] private GameObject _boss;
    //NavMeshAgent _agent;
    //private GameObject _dialogGameObject;
    private float _playerSpeed;
    //private float _enemySpeed;

    private int count;
    static int nclue = 0;

    private void Start()
    {
        _playerSpeed = _player.GetComponent<PlayerController>().speed;
        //_agent = _boss.GetComponent<NavMeshAgent>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(nclue);
        if (other.gameObject == _player)
        {
            count = 0;
            //_dialogGameObject=Instantiate(_npcDialog, _npcDialogOutput);
            ChangeMessage(_tests[count].name, _tests[count].text);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //Destroy(_dialogGameObject);
        if (other.gameObject == _player)
        {
            other.GetComponent<PlayerController>().speed = _playerSpeed;
        }

    }
    private void ChangeMessage(string title, string content)
    {
        _npcDialog.GetComponent<DialogManager>().SetData(title, content);
    }
    IEnumerator Win()
    {
        ChangeMessage("Nice", "Good Job");
        yield return new WaitForSeconds(2);
        nclue++;
        _clueObject.SetActive(false);
        _player.GetComponent<PlayerController>().speed = _playerSpeed;
        if (nclue == 3)
        {
            Globals.bossesBeaten += 1;
            SceneManager.LoadScene("ZoneA");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == _player)
        {
            if (!_npcDialog.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _playerSpeed = _player.GetComponent<PlayerController>().speed;
                    _player.GetComponent<PlayerController>().speed = 0.0f;
                    //_enemySpeed = _agent.Steering;Speed;
                    //_agent.Steering.Speed = 0.0f;
                    _npcDialog.SetActive(true);
                    //_dialogGameObject.SetActive(true);
                }
            }
            else
            {
                if (count < _letter.Length)
                {
                    if (Input.GetKeyDown(_letter[count]))
                    {
                        Globals.letters.Add(_letter[count]);
                        count++;

                        if (count != _letter.Length)
                        {
                            ChangeMessage(_tests[count].name, _tests[count].text);
                        }
                        else
                        {
                            StartCoroutine(Win());
                            //_agent.Steering.Speed = _enemySpeed;
                        }
                    }
                    //else if(!Input.GetKeyDown("a"))
                    //{
                    //    Debug.Log("BAD");
                    //    ChangeMessage("Bad", "Game Over");
                    //}
                }
            }
        }


    }

}
