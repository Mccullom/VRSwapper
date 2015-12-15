using UnityEngine;
using System.Collections;

namespace VRSwapper
{

  public class camOrbit : MonoBehaviour
  {
    public enum ActivationKey
    {
      NoKey,
      RightMouse,
      LeftMouse,
      Space,
    }

    public GameObject pivot;
    //private Vector3 offset;
    private Vector3 prevMousePos;
    public ActivationKey keyToActivate;
    public float hSpeed;
    public float vSpeed;
    public float maxVerticalDegrees;
    public float minVerticalDegrees;
    public float maxRange;
    public float minRange;
    public float scrollSpeed;

    private float mTheta; // yaw 
    private float mPhi;   // pitch 
    private float mRange;

    private Vector3 mOffset;

    bool IsActivated()
    {
      switch (keyToActivate)
      {
        case ActivationKey.NoKey:
          return true;
        case ActivationKey.LeftMouse:
          return Input.GetMouseButton(0);
        case ActivationKey.RightMouse:
          return Input.GetMouseButton(1);
        case ActivationKey.Space:
          return Input.GetKey(KeyCode.Space);
      }
      return false;
    }

    // Use this for initialization
    void Start()
    {
      //offset = Vector3.back * minRange;
      prevMousePos = Input.mousePosition;
      mTheta = 0;
      mPhi = 10;
      mRange = maxRange - minRange;
      //mRange -= minRange;
      mRange *= 0.3f;
      mRange += minRange;

      mOffset = Quaternion.Euler(mPhi, mTheta, 0.0f) * Vector3.back;// *mRange;
      transform.rotation = Quaternion.LookRotation(-mOffset);
      mOffset *= mRange;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      Vector3 mouse_pos = Input.mousePosition;
      Vector3 mouse_delta = mouse_pos - prevMousePos;
      prevMousePos = mouse_pos;

      float wheel = Input.GetAxis("Mouse ScrollWheel");
      mRange -= wheel * scrollSpeed;
      if (mRange > maxRange)
        mRange = maxRange;
      else if (mRange < minRange)
        mRange = minRange;

      if (IsActivated())
      {

        mTheta += mouse_delta.x * hSpeed;
        mPhi += mouse_delta.y * vSpeed;

        if (mPhi > maxVerticalDegrees)
        { mPhi = maxVerticalDegrees; }
        else if (mPhi < minVerticalDegrees)
        { mPhi = minVerticalDegrees; }

        if (mTheta > 360)
        { mTheta -= 360; }
        if (mTheta < -360)
        { mTheta += 360; }

        Vector3 new_offset = Quaternion.Euler(mPhi, mTheta, 0.0f) * Vector3.back;

        transform.rotation = Quaternion.LookRotation(-new_offset);
        mOffset = new_offset * mRange; ;
      }

      transform.position = pivot.transform.position + mOffset;
    }

  }

}
