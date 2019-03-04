using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class ARappScript : MonoBehaviour, IVirtualButtonEventHandler
{
    private GameObject vbButtonObject;
    private GameObject zombie;
    private GameObject Robo;
    private GameObject toon;
    private GameObject vbButtonObject2;
    private List<GameObject> gameObjectsList;
    private int iterator;
    // Start is called before the first frame updates
    void Start()
    {
        vbButtonObject = GameObject.Find("Previous");
        vbButtonObject2 = GameObject.Find("Next");
        iterator = -1;
        zombie = GameObject.Find("Zombie");
        Robo = GameObject.Find("Robo");
        toon = GameObject.Find("toon");
        gameObjectsList = new List<GameObject>();
        gameObjectsList.Add(zombie);
        gameObjectsList.Add(Robo);
        gameObjectsList.Add(toon);
        foreach (var item in gameObjectsList)
        {
            item.SetActive(false);
        }
        //zombie.SetActive(false);
        vbButtonObject.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        vbButtonObject2.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {   if (vb.name == "Previous")
        {
            Debug.Log("Button Pressed button Previous clicked!!!");
            if (iterator >= 0 && iterator < gameObjectsList.Count)
            {
                gameObjectsList[iterator].SetActive(false);
            }

            iterator--;
            if(iterator == -1)
            {
                iterator = gameObjectsList.Count - 1;
            }
            if (iterator >= 0)
            {
                var item = gameObjectsList[iterator];
                item.SetActive(true);
            }
            //zombie.SetActive(true);
            //if (iterator <= 0)
            //{
            //    iterator = -1;
            //}

        }
        if(vb.name == "Next")
        {
            if (iterator > gameObjectsList.Count || iterator < 0 )
            {
                iterator = -1;
            }
            Debug.Log("Button Pressed button Next clicked!!!");
            if (iterator >= 0)
            {
                gameObjectsList[iterator].SetActive(false);
            }
            else
            {
                iterator = -1;
            }
            iterator++;
            if (iterator > gameObjectsList.Count-1)
            {
                iterator = 0;
            }
            if(iterator >= 0)
            {
                var item = gameObjectsList[iterator];
                item.SetActive(true);

            }

           if (iterator > gameObjectsList.Count)
            {
                iterator = -1;
            }
            
           // zombie.SetActive(false);
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {

    }
    // Update is called once per frame

}
