using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building_Storage : MonoBehaviour
{
    private static List<Building_Storage> instanceList;



    public static Building_Storage GetClosest(Vector3 position) {

        Building_Storage closest = null;
        for (int i = 0; i < instanceList.Count; i++)
        {
            if(closest == null)
            {
                closest = instanceList[i];
            }
            else
            {
                if(Vector3.Distance(position,instanceList[i].GetPosition())< Vector3.Distance(position, closest.GetPosition()))
                {
                    closest = instanceList[i];
                }
            }

        }
        return closest;
    }
    private void Awake()
    {
        if (instanceList == null) instanceList = new List<Building_Storage>();
        instanceList.Add(this);
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
   
}
