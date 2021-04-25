using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facebook : MonoBehaviour
{
    public GameObject loginScreen;
    public bool loginSuccessful = false;
    public string[] akinAccount = new string[] { "gr4ndsmurf@gmail.com", "harun272" };
    public GameObject akinAcGO;
    public bool[] akinControl = new bool[2];
    public GameObject failText;
    private void LateUpdate()
    {
        loginScreen = GameObject.FindGameObjectWithTag("login");
        if (loginSuccessful)
        {
            loginScreen.SetActive(false);
        }
    }
    public void GetEmailInput(string email)
    {
        if (email == akinAccount[0])
        {
            akinControl[0] = true;
        }
        else
        {
            akinControl[0] = false;
        }
    }

    public void GetPasswordInput(string password)
    {
        if (password == akinAccount[1])
        {
            akinControl[1] = true;
        }
        else
        {
            akinControl[1] = false;
        }
    }
    public void canLogin()
    {
        if (akinControl[0] && akinControl[1])
        {
            loginScreen.SetActive(false);
            akinAcGO.SetActive(true);
            loginSuccessful = true;
            failText.SetActive(false);
        }
        else
        {
            failText.SetActive(true);
        }
    }

    //chat management
    public GameObject chatbox1;
    public Collider2D[] buttoncolliders = new Collider2D[2];

    public void openChatbox1()
    {
        chatbox1.SetActive(true);
        buttoncolliders[0].enabled = false;
        buttoncolliders[1].enabled = false;
        buttoncolliders[2].enabled = false;
    }
    public void closeChatbox1()
    {
        chatbox1.SetActive(false);
        buttoncolliders[0].enabled = true;
        buttoncolliders[1].enabled = true;
        buttoncolliders[2].enabled = true;
    }
}
