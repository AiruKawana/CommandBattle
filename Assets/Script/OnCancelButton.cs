using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCancelButton : MonoBehaviour
{
    public UIManager UIMG;
    // Start is called before the first frame update

    public void OnClickCancelButton()
    {
        UIMG.PushCancelButton();
    }
}
