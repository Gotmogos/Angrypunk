using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventroyManager : MonoBehaviour
{
    public Transform InventoryPanel;
    public List <InventorySlot> Slots = new List<InventorySlot>();
    private bool isOpen;
    [SerializeField]private GameObject UIPanel;
    void Start()
    {
        UIPanel.SetActive(true);
        UIPanel.SetActive(false);
        for (int i = 0; i < InventoryPanel.childCount; i++)
        {
            if(InventoryPanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                Slots.Add(InventoryPanel.GetChild(i).GetComponent<InventorySlot>());
                Debug.Log("Yes");
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {
            UIPanel.SetActive(!isOpen);
            isOpen = !isOpen;           
        }
    }
}
