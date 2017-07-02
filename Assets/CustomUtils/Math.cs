using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomUtilities
{
    public class Math
    {
        ///<summary>
        ///Clamps an angle using -180 to 180 non-wrapping angle space.
        ///</summary>
        public static float ClampAngle(float angle, float minAngle, float maxAngle)
        {
            if(angle > 180)
            {
                angle = 360 - angle;
            }
            angle = Mathf.Clamp(angle, minAngle, maxAngle);
            if(angle < 0)
            {
                angle = 360 + angle;
            }
            return angle;
        }
    }
}