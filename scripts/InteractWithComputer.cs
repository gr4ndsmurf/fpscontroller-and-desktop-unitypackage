using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithComputer : MonoBehaviour
{
    public float TheDistance;
    public GameObject OpenDisplay;
    public GameObject OpenText;
    public GameObject useDisplay;
    public GameObject useText;
    public GameObject getupText;
    public GameObject crosshair;
    public GameObject ExtraCursor;
    public GameObject desktop;
    public AudioSource CollectSound;
    public bool isOpen;
    public bool isUsing;
    public GameObject Screen;
    public Animator screenAnim;
    public Animator playerAnim;
    public GameObject player;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
        if (Input.GetKeyDown(KeyCode.C))
        {
            playerAnim.SetTrigger("situp");
            isUsing = false;
            StartCoroutine(GetActive());
        }
        if (!isOpen)
        {
            desktop.SetActive(false);
        }
        if (isOpen)
        {
            StartCoroutine(onDesktop());
        }
    }
    IEnumerator GetActive()
    {
        yield return new WaitForSecondsRealtime(2);
        playerAnim.SetTrigger("situp");
        player.GetComponent<Animator>().enabled = false;
    }
    IEnumerator onDesktop()
    {
        yield return new WaitForSecondsRealtime(2.50f);
        desktop.SetActive(true);
    }

    void OnMouseOver()
    {
        if (!isOpen)
        {
            if (TheDistance <= 3)
            {
                OpenDisplay.SetActive(true);
                OpenText.SetActive(true);
                ExtraCursor.SetActive(true);
            }
            else
            {
                OpenDisplay.SetActive(false);
                OpenText.SetActive(false);
                ExtraCursor.SetActive(false);
            }
            if (Input.GetButtonDown("Open"))
            {
                if (TheDistance <= 3)
                {
                    screenAnim.SetTrigger("screenOpening");
                    isOpen = true;
                    CollectSound.Play();
                    OpenDisplay.SetActive(false);
                    OpenText.SetActive(false);
                }
            }
        }
        if (isOpen)
        {
            if (TheDistance <= 3)
            {
                if (isUsing)
                {
                    useDisplay.SetActive(false);
                    useText.SetActive(false);
                    ExtraCursor.SetActive(false);
                    crosshair.SetActive(false);
                    getupText.SetActive(true);
                    player.GetComponent<FirstPersonAIO>().enabled = false;
                    player.GetComponent<Animator>().enabled = true;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.Confined;
                }
                if (!isUsing)
                {
                    useDisplay.SetActive(true);
                    useText.SetActive(true);
                    ExtraCursor.SetActive(true);
                    crosshair.SetActive(true);
                    getupText.SetActive(false);
                    player.GetComponent<FirstPersonAIO>().enabled = true;
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
            else
            {
                useDisplay.SetActive(false);
                useText.SetActive(false);
                ExtraCursor.SetActive(false);
            }
            if (Input.GetButtonDown("Use"))
            {
                if (TheDistance <= 3)
                {
                    useDisplay.SetActive(false);
                    useText.SetActive(false);
                    isUsing = true;
                }
            }
        }
    }

    void OnMouseExit()
    {
        OpenDisplay.SetActive(false);
        OpenText.SetActive(false);
        ExtraCursor.SetActive(false);
        useDisplay.SetActive(false);
        useText.SetActive(false);
    }
}
