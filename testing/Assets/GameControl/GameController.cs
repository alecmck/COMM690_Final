using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController control;
    public InventoryControl inventory;
    public ManualControler manual;
    private PlotSegment[] plotSegments;
    private int currentPlotSegment = 0;

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
    // Start is called before the first frame update
    void Start()
    {
        plotSegments = GetComponentsInChildren<PlotSegment>();
        Debug.Log("Plot segment count: " + plotSegments.Length);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Input: string name of item
    //Returns bool of if item is in inventory
    public bool inventoryContains(string itemName)
    {
        return inventory.inventoryContains(itemName);
    }

    //Input: string name of item
    //Returns InventoryItem object of that name
    public InventoryItem getInventoryItem(string itemName)
    {
        return null;
    }

    //Input: string name of item
    //Returns bool if successful/failed
    //Removes item from inventory and does not return item to the world
    public bool destroyInventoryItem(string itemName)
    {
        if (!inventoryContains(itemName))
        {
            return false;
        }
        InventoryItem i = inventory.getInventoryItem(itemName);
        inventory.destroyInventoryItem(i);
        return true;
    }

    //This does not do anything yet
    public bool updateManual(string manualCode)
    {
        return false;
    }

    //I have written the Inventory code for this but I have not tested it yet so I am not connecting them yet.
    //If you need this method, call it as needed and everything should be fine once I write it. 
    //Input: -an array of strings of the items to be combined, these items will be destroyed.
    //       -the new InventoryItem to be added to the inventory
    public bool combineInventoryItems(string[] itemsToCombine, InventoryItem itemToPlace)
    {
        return false;
    }

    public void segmentComplete(int segmentNumber)
    {
        currentPlotSegment++;
    }

    public void DarkPhoneClicked()
    {
        Debug.Log("Sending select Dark Phone to plot segment " + currentPlotSegment);
        plotSegments[currentPlotSegment].selectDarkPhone();
    }
    public void LightPhoneClicked()
    {
        Debug.Log("Sending select Light Phone to plot segment " + currentPlotSegment);
        plotSegments[currentPlotSegment].selectLightPhone();
    }
}
