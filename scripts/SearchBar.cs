using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchBar : MonoBehaviour
{
    public string[] citeName = new string[] { "throne.com", "facehook.com", "twitter.com" };
    public GameObject[] prefabs;
    public List<GameObject> history;
    public GameObject desktopCanvas;
    public GameObject searchcontroller;
    public GameObject localPosition;
    public int pageNumber;

    public void GetInput(string search)
    {
        if (search != citeName[0] && search != citeName[1] && search != citeName[2])
        {
            GameObject notFound = Instantiate(prefabs[0], desktopCanvas.transform.position, Quaternion.identity);
            notFound.transform.SetParent(searchcontroller.transform, false);
            notFound.transform.localPosition = localPosition.transform.localPosition;
            history.Add(notFound);
        }
        if (search == citeName[0])
        {
            GameObject throne = Instantiate(prefabs[1], desktopCanvas.transform.position, Quaternion.identity);
            throne.transform.SetParent(searchcontroller.transform, false);
            throne.transform.localPosition = localPosition.transform.localPosition;
            history.Add(throne);
        }
        if (search == citeName[1])
        {
            GameObject facehook = Instantiate(prefabs[2], desktopCanvas.transform.position, Quaternion.identity);
            facehook.transform.SetParent(searchcontroller.transform, false);
            facehook.transform.localPosition = localPosition.transform.localPosition;
            history.Add(facehook);
        }
        if (search == citeName[2])
        {
            GameObject twitter = Instantiate(prefabs[3], desktopCanvas.transform.position, Quaternion.identity);
            twitter.transform.SetParent(searchcontroller.transform, false);
            twitter.transform.localPosition = localPosition.transform.localPosition;
            history.Add(twitter);
        }
    }
    public void GoBack()
    {  
        if (pageNumber < history.Count)
        {
            history[history.Count - pageNumber].SetActive(false);
            pageNumber++;
        }
        if (pageNumber == history.Count)
        {
            pageNumber = history.Count - 1;
        }
    }
    public void GoNext()
    {
        if (pageNumber > 0)
        {
            history[history.Count - pageNumber].SetActive(true);
            pageNumber--;
        }
        if (pageNumber == 0)
        {
            pageNumber = 1;
        }
    }
    public void CloseTab()
    {
        foreach (GameObject item in history)
        {
            Destroy(item);
        }
        for (int i = 0; i < history.Count; i++)
        {
            history.RemoveAt(i);
        }
    }
}
