using System;
using System.Collections.Generic;
using UnityEngine;
using Wcng;

namespace GameMain.GameLogic.System.Data
{
    public class DataReSetSystem : MonoBehaviour
    {
        [SerializeField] private List<EntityData> datas = new List<EntityData>();

        private void Awake()
        {
            Application.quitting += ReSetData;
        }


        public void ReSetData()
        {
            foreach (var data in datas)
            {
                data.ReSet();
            }
        }
    }
}
