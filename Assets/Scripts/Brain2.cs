using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Brain2 : MonoBehaviour
{
    //gauge of hunger/thirst, higher is more.
    public float hunger = 0f;
    public float thirst = 1f;

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
        //increases hunger/ thirst by 1 per second.
        thirst += Time.deltaTime;
        hunger += Time.deltaTime;
        //print("thirst " + thirst + "hunger " + hunger);

        //if hunger is a higher number then thirst get cookie
        if (thirst >= hunger)
        {
            //Get milk
            //print("get milk");
            agent.destination = Milk.transform.position;
        }

        //if thirst is a higher number then hunger get milk
        if (hunger >= thirst)
        {
            //Get Cookie
            //print("Get Cookie");
            agent.destination = Cookies.transform.position;
        }

    }

    //when this object touches a trigger collider this method triggers and returns the other object’s collider as “other” 
    private void OnTriggerEnter(Collider other)
    {
        //check if “other” has a tag we want
        if (other.tag == "Drink")
        {
            thirst = 0;
        }

        if (other.tag == "Food")
        {
            hunger = 0f;
        }

        //Kill other's gameObject
        Destroy(other.gameObject);

        //calls method “FindNextFood” and sets Cookie to equal the output
        Cookies = FindNextFood();
        print("Cookies " + Cookies);

        Milk = FindNextDrink();
        print("Milk " + Milk);
        
       

    }

    // Makes a list of Food and sends one back to the method that called FindNextFood()
    public GameObject FindNextFood()
    {
        //a List of game objects 
        GameObject[] foods;

        //fills list with objects that have the correct tag
        foods = GameObject.FindGameObjectsWithTag("Food");

        //sends first object in list back to the method that called this
        return foods[0];
    }

    public GameObject FindNextDrink()
    {
        GameObject[] drinks;
        drinks = GameObject.FindGameObjectsWithTag("Drink");

        return drinks[0];
    }
}
