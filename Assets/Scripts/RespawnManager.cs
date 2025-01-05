using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public static List<RespawnObject> respawnObjects = new List<RespawnObject>();

    private void Update()
    {
        foreach (RespawnObject respawnObject in respawnObjects.ToList())
        {
            StartCoroutine(Respawn(respawnObject));
            respawnObjects.Remove(respawnObject);
        }
    }

    private IEnumerator Respawn(RespawnObject respawnObject)
    {
        respawnObject.gameObject.SetActive(false);
        respawnObject.transform.position = respawnObject.respawnPoint;
        respawnObject.rb.linearVelocity = Vector2.zero;
        
        yield return new WaitForSeconds(respawnObject.respawnDelay);

        respawnObject.gameObject.SetActive(true);
    }
}
