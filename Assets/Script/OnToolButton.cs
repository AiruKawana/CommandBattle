using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnToolButton : MonoBehaviour
{
    // Start is called before the first frame update

    //public GameManager GM;
    public UIManager UIMG;
    public void OnClickToolButton()
    {
        UIMG.PushToolButton();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
