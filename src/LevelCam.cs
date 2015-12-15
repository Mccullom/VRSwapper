using UnityEngine;
using System.Collections;

public class LevelCam : MonoBehaviour
{


  public float speed;
  public float turboMultiplier;
  public KeyCode TurboKey;
  public GameObject cameraRig;

  // Update is called once per frame
  void FixedUpdate()
  {
    float horiz = Input.GetAxis("Horizontal");
    float vert = Input.GetAxis("Vertical");

    Vector3 forward = cameraRig.transform.forward;
    forward.y = 0.0f;
    forward.Normalize();

    Vector3 side = Vector3.Cross(forward, Vector3.up);
    Vector3 dir = (vert * forward) - (horiz * side);
    dir.Normalize();

    float mult = speed * Time.deltaTime;

    if (Input.GetKey(TurboKey))
    {
      mult *= turboMultiplier;
    }

    dir.y = 0.0f;

    transform.position += (dir * mult);
  }
}
