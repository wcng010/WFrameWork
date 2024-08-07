using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using Wcng.Library;

namespace GameScript.GameMain.Component
{
    public class DamageComponent : SerializedMonoBehaviour,IComponent
    {
        [SerializeField] private Dictionary<BodyPoint, Transform> checkPoint = new Dictionary<BodyPoint, Transform>();
        public void RangeDetection(BodyPoint bodyPoint, String characterTag, Action<Collider[]> checkAfter)
        {
            Transform point = checkPoint[bodyPoint];
            var colliders = Physics.OverlapBox(point.position,Vector3.one*5, Quaternion.identity,1 << LayerMask.NameToLayer(characterTag));
            Debug.Log("Check");
            if(colliders.Length > 0) checkAfter.Invoke(colliders);
        }
    }
}
