using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour {

    GameObject player, objectToSpawn;

    public enum spawnType {enemyFlag, obsHI, obsLO, coin };

    public spawnType flag;

    private Vector3 spawnPoint;

    private bool  canSpawn = true, switchFlag = false;

    public float hiObsPoint = 0.8f,
                 lowObsPoint = -1.06f;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");

    }
    
    // Update is called once per frame
    void Update () {

        //In Range
        if (Vector3.Distance(transform.position, player.transform.position) <= 10 && switchFlag)
        {
            canSpawn = true;
            switchFlag = false;
        }

        //Out of Range
        if (Vector3.Distance(transform.position, player.transform.position) >= 10)
        {
            switchFlag = true;
            canSpawn = false;
        }


        if (canSpawn)
        {
            switch (flag)
            {
                case spawnType.enemyFlag:
                    {
                        //Change when we get the final enemy model
                        objectToSpawn = (GameObject)Resources.Load("tempEnemy");
                        spawnPoint = transform.position;
                    }
                    break;

                case spawnType.obsHI:
                    {
                        //Change when we get the final enemy model
                        objectToSpawn = (GameObject)Resources.Load("OBS_hi");
                        spawnPoint = new Vector3(transform.position.x, hiObsPoint, transform.position.z);
                    }
                    break;

                case spawnType.obsLO:
                    {
                        //Change when we get the final enemy model
                        objectToSpawn = (GameObject)Resources.Load("OBS_low");
                        spawnPoint = new Vector3(transform.position.x, lowObsPoint, transform.position.z);
                    }
                    break;

                case spawnType.coin:
                    {
                        //Change when we get the final enemy model
                        objectToSpawn = (GameObject)Resources.Load("Temp Coin Hold");

                        //Left
                        spawnPoint = new Vector3(transform.position.x - 2, transform.position.y, transform.position.z);
                        Instantiate(objectToSpawn, spawnPoint, transform.rotation);

                        //Right
                        spawnPoint = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
                        Instantiate(objectToSpawn, spawnPoint, transform.rotation);

                        //Center
                        spawnPoint = transform.position;
                    }
                    break;

                default:
                    {
                        spawnPoint = transform.position;
                    }
                    break;
            }
            Instantiate(objectToSpawn, spawnPoint, transform.rotation);
            canSpawn = false;
        }

	}
}
