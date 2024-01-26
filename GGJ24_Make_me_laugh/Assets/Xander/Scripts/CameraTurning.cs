using System.Collections;
using UnityEngine;

public class CameraTurning : MonoBehaviour
{
   private readonly float rotationSpeed = 2.75f;

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.D))
      {
         RotateCamera(90f);   
      }
   }

   private void RotateCamera(float angle)
   {
      Quaternion targetRotation = transform.rotation * Quaternion.Euler(0, angle, 0);

      StartCoroutine(SmoothRotate(targetRotation));
   }

   IEnumerator SmoothRotate(Quaternion targetRotation)
   {
      float elapsedTime = 0f;
      float duration = 2f;

      Quaternion startRotation = transform.rotation;
      
      while (elapsedTime < duration)
      {
         transform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime / duration);

         elapsedTime += Time.deltaTime * rotationSpeed;

         yield return null;
      }
      
      transform.rotation = targetRotation;
   }
}
