using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager instance;

    private Dictionary<GameObject, List<GameObject>> pools = new Dictionary<GameObject, List<GameObject>>();

    private void Awake()
    {
        instance = this;
    }

    public GameObject Get(GameObject findObj, Vector3 setPos)
    {
        GameObject selectObj = null;

        if (pools.ContainsKey(findObj))
        {
            foreach (GameObject poolObj in pools[findObj])
            {
                if (poolObj.activeSelf == false)
                {
                    selectObj = poolObj;
                    break;
                }
            }

            if (selectObj == null)
            {
                selectObj = Instantiate(findObj, transform);
                pools[findObj].Add(selectObj);
            }
        }
        else
        {
            pools.Add(findObj, new List<GameObject>());
            selectObj = Instantiate(findObj, transform);
            pools[findObj].Add(selectObj);
        }

        selectObj.transform.position = setPos;
        selectObj.SetActive(true);
        return selectObj;
    }
}
