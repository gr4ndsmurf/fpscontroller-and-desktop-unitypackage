using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppBar : MonoBehaviour
{
    public GameObject Browser;
    public GameObject Notepad;
    public GameObject Mfn;
    public GameObject MusicPlayer;
    public void OpenBrowser()
    {
        Browser.SetActive(true);
        Browser.transform.SetAsLastSibling();
    }
    public void OpenNotepad()
    {
        Notepad.SetActive(true);
        Notepad.transform.SetAsLastSibling();
    }
    public void OpenMfn()
    {
        Mfn.SetActive(true);
        Mfn.transform.SetAsLastSibling();
    }
    public void OpenMusicPlayer()
    {
        MusicPlayer.SetActive(true);
        MusicPlayer.transform.SetAsLastSibling();
    }
}
