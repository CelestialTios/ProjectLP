using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    static class UtilsMath
    {
        public static Vector3 RandomVector()
        {
            return new Vector3(UnityEngine.Random.Range(-1f,1f),UnityEngine.Random.Range(-1f,1f)).normalized;
        }


        public static Vector3 AngleToVector(float _angle)
        {
            //angle = 0 -> 360
            float angleRad = _angle * (Mathf.PI / 180f);
            return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
        }

        public static float VectorToAngle(Vector3 _vector)
        {
            _vector = _vector.normalized;
            float angle = Mathf.Atan2(_vector.y, _vector.x) * Mathf.Rad2Deg;
            if (angle < 0) angle += 360;
            return angle;
        }
    }
}
