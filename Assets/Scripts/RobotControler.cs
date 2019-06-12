using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotControler : MonoBehaviour {

    // Use this for initialization

    public ManRobot robot;
    public ManRobot cleaningRobot;
    public Transform[] targets;
    public GameObject przeszkoda;
    public Transform respawn;
    private int currentIndex = 0;
    private bool stop = false;
    private void setNextTarget()
    {   
        
        if(!stop)
        {
            if (currentIndex <= targets.Length - 1)
            {
                float dist = Vector3.Distance(targets[currentIndex].position, robot.transform.position);
                if (dist <= 4)
                {
                    currentIndex++;
                    robot.setAgetnDestination(targets[currentIndex].position);
                }
            }
            else
            {
                currentIndex = 0;
                robot.setAgetnDestination(targets[currentIndex].position);
            }
        }
        
    }
    void Start()
    {

        robot.setAgetnDestination(targets[currentIndex].position);
    }

    void sendCleanRobot()
    {
        float dist = Vector3.Distance(robot.transform.position, przeszkoda.transform.position);

        if(dist <= 20 && robot.objectInCamera(przeszkoda))
        {
            stop = true;
            robot.stopAgent();
            cleaningRobot.setAgetnDestination(przeszkoda.transform.position);
        }
    }

    void recalCleanRobot()
    {
        float dist = Vector3.Distance(cleaningRobot.transform.position, przeszkoda.transform.position);
        if(dist <= 5)
        {
            przeszkoda.transform.position = new Vector3(przeszkoda.transform.position.x, -100f, przeszkoda.transform.position.z);
            cleaningRobot.setAgetnDestination(respawn.position);
            stop = false;
            robot.runAgent();
        }
    }

	// Update is called once per frame

	void Update () {
        setNextTarget();
        if (przeszkoda != null)
        {
            sendCleanRobot();
            recalCleanRobot();
        }
    }
}
