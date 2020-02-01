using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUi : MonoBehaviour
{
    // Start is called before the first frame update
    public void EnableScreen(){
        this.gameObject.SetActive(true);
    }
    public void DisableScreen(){
        this.gameObject.SetActive(false);
    }
}
