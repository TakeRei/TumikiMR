using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine.Events;


public class OpenMenu : MonoBehaviour
{
    [SerializeField, Header("Target")]
    Handedness handType;

    [SerializeField, Range(0, 90)]
    private float indexThreshold = 5;
                                                                                    
    [SerializeField, Range(0, 90)]
    private float middleThreshold = 5;

    [SerializeField]
    UnityEvent Open_Menu;

    [SerializeField]
    UnityEvent Close_Menu;

    private bool? handdetected;


    void Update()
    {
        handdetected = HandJointUtils.FindHand(handType)?.TryGetJoint(TrackedHandJoint.Palm, out MixedRealityPose PalmPose);
        if (handdetected != null && handdetected == true)
        {
            if (openmenu())
            {
                Open_Menu.Invoke();
            }
            else
            {
                Close_Menu.Invoke();
            }
        }
    }

   
    private bool openmenu()
    {
        var jointedHand = HandJointUtils.FindHand(handType);
        if (jointedHand.TryGetJoint(TrackedHandJoint.Palm, out MixedRealityPose PalmPose))
        {
            //äeä÷êﬂÇÃpose
            MixedRealityPose indexTipPose, indexDistalPose, IndexKnucklePose, indexMiddlePose, middleTipsPose, middleDistalPose, middleKnucklePose, middleMiddlePose;
            if (jointedHand.TryGetJoint(TrackedHandJoint.IndexTip, out indexTipPose) &&
                jointedHand.TryGetJoint(TrackedHandJoint.IndexDistalJoint, out indexDistalPose) &&
                jointedHand.TryGetJoint(TrackedHandJoint.IndexMiddleJoint, out indexMiddlePose) &&
                jointedHand.TryGetJoint(TrackedHandJoint.IndexKnuckle, out IndexKnucklePose) &&
                jointedHand.TryGetJoint(TrackedHandJoint.MiddleTip, out middleTipsPose) &&
                jointedHand.TryGetJoint(TrackedHandJoint.MiddleDistalJoint, out middleDistalPose) &&
                jointedHand.TryGetJoint(TrackedHandJoint.MiddleKnuckle, out middleKnucklePose) &&
                jointedHand.TryGetJoint(TrackedHandJoint.MiddleMiddleJoint, out middleMiddlePose))
            {
                Vector3 f1 = IndexKnucklePose.Position - PalmPose.Position;
                Vector3 f2 = indexMiddlePose.Position - IndexKnucklePose.Position;
                Vector3 f3 = indexDistalPose.Position - indexMiddlePose.Position;
                Vector3 f4 = indexTipPose.Position - indexDistalPose.Position;
                Vector3 f5 = middleKnucklePose.Position - PalmPose.Position;
                Vector3 f6 = middleMiddlePose.Position - middleKnucklePose.Position;
                Vector3 f7 = middleDistalPose.Position - middleMiddlePose.Position;
                Vector3 f8 = middleTipsPose.Position - middleDistalPose.Position;

                float c = Vector3.Angle(PalmPose.Position, f1);
                float d = Vector3.Angle(f1, f2);
                float e = Vector3.Angle(f2, f3);
                float f = Vector3.Angle(f3, f4);
                float g = Vector3.Angle(PalmPose.Position, f1);
                float h = Vector3.Angle(f5, f6);
                float i = Vector3.Angle(f6, f7);
                float j = Vector3.Angle(f7, f8);

                float aba = (Mathf.Abs(d) + Mathf.Abs(e) + Mathf.Abs(f)) / 3;
                float bcb = (Mathf.Abs(h) + Mathf.Abs(i) + Mathf.Abs(j)) / 3;

                if (aba < indexThreshold && bcb < middleThreshold)
                {
                    return true;
                }
            }
        }
        return false;
    }
}