using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    [SerializeField] RedLight redLight;

    NPCController[] npcControllers;
    GameObject[] bots;
    Queue<OtherController> otherControllers = new Queue<OtherController>();

    bool control;

    void Start()
    {
        npcControllers = GetComponentsInChildren<NPCController>();
        bots = GameObject.FindGameObjectsWithTag("Bot");

        for (int i = 0; i < bots.Length; i++)
        {
            otherControllers.Enqueue(bots[i].GetComponent<OtherController>());
        }
    }

    void Update()
    {
        if (redLight.OnLight)
        {
            if (!control)
            {
                control = true;
                BotControl();
            }
        }
        else
        {
            if (control)
            {
                control = false;
            }
        }
    }

    void BotControl()
    {
        int index = 0;

        foreach (OtherController other in otherControllers)
        {
            if (other.IsRun && !other.IsPassed)
            {
                npcControllers[index].ShotOn(other.transform);               
            }

            index++;
        }

        index = 0;
    }
}
