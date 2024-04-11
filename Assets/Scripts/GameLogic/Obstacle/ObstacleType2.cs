using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class ObstacleType2 : Obstacle
{
    public EndLocationEvent tileEndSignal;
    void OnEnable()
    {
        GameObject[] emitters = GameObject.FindGameObjectsWithTag("TileEnd");
        //поиск ближайшего объекта обозначающего конец локации у которого z больше чем у созданного obstacle
        emitters = emitters.Where(o => o.transform.position.z > transform.position.z).OrderBy(o => o.transform.position.z).ToArray();
        GameObject closestObject = emitters[0];
        if (closestObject != null)
        {
            tileEndSignal = closestObject.GetComponent<EndLocationEvent>();
            tileEndSignal.tileEndSignal += Destroy;
        }
    }
    private void Start()
    {
        //tileEndSignal.tileEndSignal += Destroy;
        playerObject = GameObject.FindWithTag("Player");
    }
    public override void Activate()
    {

    }
    public override void Destroy()
    {
        if (playerObject.transform.position.z > gameObject.transform.position.z)
        {
            gameObject.SetActive(false);
        }
    }
}