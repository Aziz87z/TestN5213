using UnityEngine;

public class MainPanel : MonoBehaviour
{
    public GameObject objectToToggle; // Объект, который мы будем включать/выключать

    public void TurnOnObject()
    {
        objectToToggle.SetActive(true);
        
    }

    public void TurnOffObject()
    {
        objectToToggle.SetActive(false);
         
    }
}
