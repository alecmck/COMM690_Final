using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryControl : MonoBehaviour
{

    public static InventoryControl control;

    public Transform ContenPanel; //Where inventory items appear
    public GameObject InventoryButton;
    private List<InventoryItem> Inventory = new List<InventoryItem>();

    public GameObject InventoryUI;

    public GameObject fpsConrtoller;
    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpsMove;
    private dragRigidbody2 fpsPickup;

    public void Start()
    {
        fpsMove = fpsConrtoller.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        fpsPickup = fpsConrtoller.GetComponent<dragRigidbody2>();
        control = this;
    }

   void Awake()
    {//This makes only one inventory control that is accisible from other scripts. 
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }

    public void ShowInventory()
    {
         InventoryUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        fpsMove.enabled = false;
        fpsPickup.enabled = false;        
    }

    public void CloseInventory()
    {
        InventoryUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        fpsMove.enabled = true;
        fpsPickup.enabled = true;
    }

    public void Collect(InventoryItem o) //Called by InventoryItem.cs
    {
        Inventory.Add(o);
        GameObject button = (GameObject)GameObject.Instantiate(InventoryButton);
        button.GetComponent<IButton>().SetUp(o, this);
        button.transform.SetParent(ContenPanel);
      
    }

    public void Use(InventoryItem o)
    {
        o.Remove(Camera.main.ScreenToWorldPoint(new Vector3(0,0,1)), new Quaternion(0, 0, 0, 0));
        Inventory.Remove(o);
        CloseInventory();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ShowInventory();
        }
    }
}
