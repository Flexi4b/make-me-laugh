using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CameraTurning : MonoBehaviour
{
   private readonly float rotationSpeed = 2.75f;
   private bool stopInput;
   private float waitTime;
   [SerializeField] float cameraDelay;
   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.D) && stopInput == false)
      {
         RotateCamera(90f);
         stopInput = true;
      }

      if (Input.GetKeyDown(KeyCode.A) &&  stopInput == false)
      {
         RotateCamera(-90f);
         stopInput = true;
      }

      if (stopInput == true)
      {
         waitTime += Time.deltaTime;
      }
      
      if (waitTime >= cameraDelay)
      {
         stopInput = false;
         waitTime = 0;
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
