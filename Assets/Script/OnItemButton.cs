using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OnItemButton : MonoBehaviour
{
    public UIManager UIMG;
    public GameObject itemTMP;
    public Button button;
    public TextMeshProUGUI ItemButtonText;
    // Start is called before the first frame update

    void Start()
    {
        button.GetComponent<Button>();
    }
    public void OnClickItemButton()
    {
        UIMG.PushItemButton();
        button.interactable = false;
        if(button.interactable == false)
        {
            ItemButtonText.text = "Not available";
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
