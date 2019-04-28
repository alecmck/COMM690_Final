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

    public bool inventoryContains(string itemName)
    {
        return false;
    }

    public InventoryItem getInventoryItem(string itemName)
    {
        return null;
    }

    public bool destroyInventoryItem(string itemName)
    {
        return false;
    }

    public bool updateManual(string manualCode)
    {
        return false;
    }

    public bool combineInventoryItems(string[] itemsToCombine, InventoryItem itemToPlace)
    {
        return false;
    }

    public void segmentComplete(int segmentNumber)
    {

    }
}
