using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Brain : MonoBehaviour
{
    public bool hunger = false;
    public bool thirst = true;
    public GameObject Milk;
    public GameObject Cookies;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(thirst == true)
        {
            //Get milk
            //print("get milk");
            agent.destination = Milk.transform.position;
        }

        if (hunger == true && thirst == !true)
        {
            //Get Cookie
            //print("Get Cookie");
            agent.destination = Cookies.transform.position;
        }

    }
}
