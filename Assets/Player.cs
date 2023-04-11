using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //variable to store targetDestinatio
    public static Vector3 _targetDestination;

    private void Start()
    {
        _targetDestination = transform.position;
    }

    void Update()
    {
        //move towards target destination
        _targetDestination.y = 1f;
       transform.position = Vector3.MoveTowards(transform.position, _targetDestination, 5 * Time.deltaTime);
    }
}
