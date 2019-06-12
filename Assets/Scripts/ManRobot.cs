using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ManRobot : MonoBehaviour {

    private NavMeshAgent agent;
    Camera robotCamera;
    public void setAgetnDestination(Vector3 des)
    {
        agent.destination = des;
    }

    public void stopAgent()
    {
        agent.isStopped = true;
    }

    public void runAgent()
    {
        agent.isStopped = false;
    }

    public bool objectInCamera(GameObject gameObject)
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        return IsVisibleFrom(renderer, robotCamera);
    }

    private bool IsVisibleFrom(Renderer renderer, Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }

	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();

        robotCamera = GetComponentInChildren<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
	}
}
