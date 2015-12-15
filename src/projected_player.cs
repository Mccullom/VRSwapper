using UnityEngine;
using System.Collections;

namespace VRSwapper
{

  public class projected_player : MonoBehaviour
  {

    public Transform Cam;
    public Transform Feet;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if (Cam != null && Feet != null)
      {
        Feet.position = new Vector3(Cam.position.x, 0.0f, Cam.position.z);
      }
    }

  }

}
