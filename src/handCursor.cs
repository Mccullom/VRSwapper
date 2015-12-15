using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace VRSwapper
{

  [ExecuteInEditMode]
  public class handCursor : MonoBehaviour
  {

    public enum Gender
    {
      male,
      female
    }

    public enum SkinTone
    {
      Dark,
      Medium,
      Light
    }

    public enum Handedness
    {
      right,
      left
    }

    public Gender gender;
    public SkinTone tone;
    public Handedness handedness;

    [System.Serializable]
    public struct HandType
    {
      // should be 2 here: matching the Handedness enum
      public List<GameObject> prefabs;
      // should match the SkinTone enum
      public List<Material> tone;
    }

    // should match the Gender enum
    public List<HandType> genderedHandData;

    GameObject mHand;

    int mGender;
    int mTone;
    int mSide;

    void FixupModel()
    {
      mGender = (int)gender;
      mSide = (int)handedness;

      if (mHand != null)
      {
        GameObject.DestroyImmediate(mHand);
      }

      if (genderedHandData != null && mGender < genderedHandData.Count && mSide < genderedHandData[mGender].prefabs.Count)
      {
        mHand = GameObject.Instantiate(genderedHandData[mGender].prefabs[mSide]);
        if (mHand != null)
        {
          mHand.transform.SetParent(transform);
          mHand.transform.localPosition = Vector3.zero;
          mHand.transform.localRotation = Quaternion.identity;
          FixupSkinTone();
        }
      }
    }

    void FixupSkinTone()
    {
      mTone = (int)tone;
      if (mHand != null && genderedHandData != null && mGender < genderedHandData.Count && mTone < genderedHandData[mGender].tone.Count)
      {
        Renderer model = mHand.GetComponentInChildren<Renderer>();
        if (model != null)
        {
          model.material = genderedHandData[mGender].tone[mTone];
        }
      }
      if (mHand == null)
      {
        FixupModel();
      }
    }

    void CheckForDifferences()
    {
      if (mSide != (int)handedness || mGender != (int)gender)
      {
        FixupModel();
      }
      else if (mTone != (int)tone)
      {
        FixupSkinTone();
      }
    }

    // Use this to force the mesh and texture data to rebuild
    public void Fixup()
    {
      FixupModel();
    }

    // Use this for initialization
    void Start()
    {
      mGender = -1; // force the model to refresh on the first loop
    }

    // Update is called once per frame
    void Update()
    {
      CheckForDifferences();
    }
  }

}