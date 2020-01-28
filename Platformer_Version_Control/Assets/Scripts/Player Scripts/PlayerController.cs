using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private string inputAxis = "move";
    private string inputTurn = "turn";

    public float turnRotation = 360;
    public float speed = 10;

    private void Update()
    {
        float moveAxis = Input.GetAxis(inputAxis);
        float turnAxis = Input.GetAxis(inputTurn);

        CharacterMovement(moveAxis,turnAxis);
    }

    public void CharacterMovement (float moveInput, float turnInput) {

        Move(moveInput);
        Turn(turnInput);
    }

  

    private void Move( float Input)
    {
      
    }
    private void Turn(float Input)
    {

    }

    
}
