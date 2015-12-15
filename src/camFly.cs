using UnityEngine;
using System.Collections;

namespace VRSwapper
{

  public class camFly : MonoBehaviour
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

      Vector3 side = Vector3.Cross(cameraRig.transform.forward, Vector3.up);
      Vector3 dir = (vert * cameraRig.transform.forward) - (horiz * side);
      dir.Normalize();

      float mult = speed * Time.deltaTime;

      if (Input.GetKey(TurboKey))
      {
        mult *= turboMultiplier;
      }

      transform.position += (dir * mult);
    }

  }

}
