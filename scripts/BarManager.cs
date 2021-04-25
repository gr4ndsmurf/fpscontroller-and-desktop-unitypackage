using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarManager : MonoBehaviour
{
    public GameObject tab1Button;
    public GameObject tab1;
    public GameObject tab2;
    public void tab2Acma()
    {
        tab1Button.SetActive(false);
        tab2.SetActive(true);
    }
}
