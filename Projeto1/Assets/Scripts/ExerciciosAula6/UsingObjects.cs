using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingObjects : MonoBehaviour {

    Turtle turtle1;
    Turtle turtle2;
    Vector2 position;

	// Use this for initialization
	void Start () {
        turtle1 = new Turtle("Donatello");
        turtle1.speed = 10;
        turtle1.fly();
        print(turtle1.ToString());

        turtle2 = new Turtle("Raphael");
        turtle2.speed = 20;
        turtle2.walk();
        print(turtle2.ToString());

        print(Turtle.turtleCounter);
        Vector2 position = new Vector2(1, 3);
 
    }

    private void Update()
    {
        //Debug.Log("Update " + Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate " + Time.deltaTime);
    }

    private void OnDisable()
    {
        
    }

    private void OnEnable()
    {
        
    }
}
