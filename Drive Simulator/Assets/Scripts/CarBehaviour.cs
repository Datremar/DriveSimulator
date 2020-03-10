using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour
{
    public float speed = 10f;
    public float reactionRadius = 5f;
    public float rotationSmoothness = 5f;

    public Vector3[] waypoints;
    public GameObject player;
    int current = 0;
    float WPradius = 1;

    private Collider[] colliders;
    private int command = 0;
    private Quaternion toRight;
    private Quaternion toLeft;
    private Node currentPosition;
    private Node destination;

    private Node[] temp;

    void Start()
    {
        toRight = Quaternion.Euler(0, 90f, 0);
        toLeft = Quaternion.Euler(0, -90f, 0);
    }

    void Update()
    {
        //colliders = Physics.OverlapSphere(transform.position, reactionRadius);

        //transform.Translate(0, 0, speed * -1);


        //transform.Rotate(0, 1f, 0);

        //temp = Pathfinding.GetPath().ToArray();

        for (int i = 0; i < temp.Length; i++)
        {
            waypoints[i] = temp[i].WorldPosition;
        }

        if (Vector3.Distance(waypoints[current], transform.position) < WPradius)
        {
            current = Random.Range(0, waypoints.Length);
            if (current >= waypoints.Length)
            {
                current = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current], Time.deltaTime * speed);
    }

    private void executeCommand(int num_o_command)
    {
        switch (num_o_command)
        {
            case 0:
                moveForward();
                break;
            case 1:
                stop();
                break;
            case 2:
                turnRight();
                break;
            case 3:
                turnLeft();
                break;
            case 4:
                turnAround();
                break;
        }
    }

    private void moveForward()
    {
        transform.Translate(0, 0, speed * -1);
        transform.Rotate(0, 1f, 0);
    }

    private void stop()
    {
        transform.Translate(0, 0, 0);
    }

    private void turnRight()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, toRight, 0.1f);
    }

    private void turnLeft()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, toLeft, 0.1f);
    }

    private void turnAround() {
        turnLeft();
        moveForward();
        turnLeft();
    }

    public void giveCommand(int num_o_command)
    {
        command = num_o_command;
    }

    public Collider[] reportSituation()
    {
        return colliders;
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);
    }
}
