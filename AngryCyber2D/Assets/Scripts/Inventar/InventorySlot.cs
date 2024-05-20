using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public ScriptableObject slot;
    public ItemTipe _itemTipe;
    [SerializeField]List <Sprite> sprites = new List<Sprite>();
    public Image _image;
    [SerializeField] private bool isEmprty;   
    [SerializeField] private GameObject Yellow;
    [SerializeField] private GameObject Red;
    [SerializeField] private GameObject Blue;
    [SerializeField] private Transform origin;
    public void Awake()
    {
        if(_itemTipe == ItemTipe.Yellow)
        {
            _image.sprite = sprites[1];
        }
        if (_itemTipe == ItemTipe.Red)
        {
            _image.sprite = sprites[0];
        }
        if (_itemTipe == ItemTipe.Blue)
        {
            _image.sprite = sprites[2];
        }
        if (_itemTipe == ItemTipe.black)
        {
            _image.color = new Color(1, 1, 1, 0);
        }
        if (_itemTipe == ItemTipe.Yellow || _itemTipe == ItemTipe.Red || _itemTipe == ItemTipe.Blue)
        {
            STaticInventory.slots++;           
        }       
    }
    private void OnMouseOver()
    {       
        isEmprty = true;
    }
    private void OnMouseExit()
    {       
        isEmprty = false;
    }
    private void Update()
    {
        if (isEmprty & Input.GetKeyDown(KeyCode.E))
        {
            if (_itemTipe == ItemTipe.Yellow)
            {
                _image.color = new Color(1,1,1,0);
                Instantiate(Yellow, origin.position, Quaternion.identity);
                isEmprty = false;
                _itemTipe = ItemTipe.black;
                
            }
            if (_itemTipe == ItemTipe.Red)
            {
                _image.color = new Color(1, 1, 1, 0);
                Instantiate(Red, origin.position, Quaternion.identity);
                isEmprty = false;
                _itemTipe = ItemTipe.black;
               
            }
            if (_itemTipe == ItemTipe.Blue)
            {
                _image.color = new Color(1, 1, 1, 0);
                Instantiate(Blue, origin.position, Quaternion.identity);
                isEmprty = false;
                _itemTipe = ItemTipe.black;               
            }
        }
    }
}
