using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManualControler : MonoBehaviour
{

    public Sprite[] pages = new Sprite[10];
    public Image pageView;
    public Button nextButton;
    public Button backButton;
    public ArrayList brokenPage = new ArrayList();
    public GameObject fpsConrtoller;
    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpsMove;
    private dragRigidbody2 fpsPickup;
    public GameObject ManualUI;

    private int currentPage = 0;
    // Start is called before the first frame update
    void Start()
    {
        fpsMove = fpsConrtoller.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        fpsPickup = fpsConrtoller.GetComponent<dragRigidbody2>();
    }

    public void nextPage()
    {
        currentPage++;
        if (currentPage > 0)
        {
            backButton.gameObject.SetActive(true);
        }

        if (currentPage >= 9)
        {
            nextButton.gameObject.SetActive(false);
        }
        pageView.sprite = pages[currentPage];
    }

    public void backPage()
    {
        currentPage--;
        if (currentPage < 1)
        {
            backButton.gameObject.SetActive(false);
        }
        if (currentPage <= 9)
        {
            nextButton.gameObject.SetActive(true);
        }
        pageView.sprite = pages[currentPage];
    }
    public void OpenManual()
    {
        ManualUI.SetActive(true);
        fpsMove.enabled = false;
        fpsPickup.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;        
    }

    public void CloseManual()
    {
        ManualUI.SetActive(false);
        fpsMove.enabled = true;
        fpsPickup.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            OpenManual();
        }
    }
}
