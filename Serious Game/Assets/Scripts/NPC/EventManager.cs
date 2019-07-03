using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _npcDialog;
    [SerializeField] private GameObject _activateBoss;
    [SerializeField] private GameObject _npcs;
    [SerializeField] private GameObject _clues;
    [SerializeField] private Transform _npcDialogOutput;
    [SerializeField] private TextAsset _npcSpeech;
    [SerializeField] private ParticleSystem _particles;
    [SerializeField] private string _npcName;
    [SerializeField] private Material _day;
    [SerializeField] private Material _night;
    private GameObject _dialogGameObject;
    private float _playerSpeed;
    private void Awake()
    {
        
    }
    private void Start()
    {
        _playerSpeed = _player.GetComponent<PlayerController>().speed;
        _npcDialog.GetComponent<DialogManager>().SetData(_npcSpeech.name, _npcSpeech.text);

    }
    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject == _player)
        //{
        //    _dialogGameObject=Instantiate(_npcDialog, _npcDialogOutput);
        //}
    }
    private void OnTriggerExit(Collider other)
    {
        //Destroy(_dialogGameObject);
        other.GetComponent<PlayerController>().speed = _playerSpeed;

    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == _player)
        {
            if (Input.GetKeyDown(KeyCode.E)) {
                if (!_npcDialog.activeSelf) {
                    _npcDialog.SetActive(true);
                    other.GetComponent<PlayerController>().speed = 0;

                }
                else
                {

                    if (tag == "MissionNPC") { 
                        RenderSettings.skybox = _night;
                        _particles.Play(true);
                        _activateBoss.SetActive(true);
                        _npcs.SetActive(false);
                        _clues.SetActive(true);
                    }
                    other.GetComponent<PlayerController>().speed = _playerSpeed;

                    _npcDialogOutput.GetChild(0).gameObject.SetActive(false);

                }

            }

        }

    }

}
