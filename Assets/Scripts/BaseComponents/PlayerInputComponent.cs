using Hackman_GD07;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputComponent : MovementComponent
{
    protected override void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentInputDirection = new IntVector2(0, -1);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentInputDirection = new IntVector2(0, 1);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentInputDirection = new IntVector2(-1, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentInputDirection = new IntVector2(1, 0);
        }
        base.Update();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyInputComponent>())
        {
            Lose();
        }

        if (other.GetComponent<Pills>())
        {
            Destroy(other.gameObject);
            if(FindObjectsOfType<Pills>().Length <= 1)
            {
                Debug.Log("You win");
            }
        }
    }

    public void Lose()
    {

    }

    public void Win()
    {

    }
}
