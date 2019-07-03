using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject _inventory;
    [SerializeField] private Button _onOpenInventory;
    [SerializeField] private Transform _letterOutput;
    [SerializeField] private GameObject _letterPrefab;

    private void Awake()
    {
        //_onOpenInventory.onClick.AddListener(OpenInventory);
    }
    private void Start()
    {
        foreach (var letter in Globals.letters)
        {
            IntantiatLetter(letter);
        }
    }

    private void IntantiatLetter(string letter)
    {
        GameObject go;
        go = Instantiate(_letterPrefab,_letterOutput);

        var letters = go.GetComponent<Letter>();
        letters.SetData(letter);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            OpenInventory();
        }
    }
    private void OpenInventory()
    {
        if(_inventory.activeSelf)
            _inventory.SetActive(false);
        else
            _inventory.SetActive(true);

 

    }


}
