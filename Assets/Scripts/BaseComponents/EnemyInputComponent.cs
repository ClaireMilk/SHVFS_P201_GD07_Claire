using Hackman_GD07;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyInputComponent : MovementComponent
{
    protected override void Update()
    {
        if(transform.position == targetGridPosition.ToVector3())
        {
            var possibleDirections = new List<IntVector2>();
            foreach(var movementDirection in movementDirections)
            {
                var potentialTargetPosition = targetGridPosition + movementDirection;
                if (potentialTargetPosition.IsWall()) continue;
                if(movementDirection != -currentInputDirection)
                {
                    possibleDirections.Add(movementDirection);
                }
            }
            if(possibleDirections.Count < 1)
            {
                possibleDirections.Add(-currentInputDirection);
            }
            var direction = Random.Range(0, possibleDirections.Count);
            currentInputDirection = possibleDirections[direction];
        }
        base.Update();
    }
    private IntVector2[] movementDirections = new IntVector2[]
    {
        IntVector2.up,
        IntVector2.down,
        IntVector2.left,
        IntVector2.right,
    };
}
