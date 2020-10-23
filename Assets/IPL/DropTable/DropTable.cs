using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace IPL.DropTable
{
    [CreateAssetMenu(menuName = "Drop Table")]
    public class DropTable : ScriptableObject
    {
        [SerializeField] private List<WeightedItem> table;
        private int totalWeight;

        private void Awake()
        {
            totalWeight = 0;
            foreach (var item in table)
            {
                totalWeight += item.weight;
            }
        }

        public GameObject Drop()
        {
            GameObject result = null;
            var roll = Random.Range(0, totalWeight + 1);
            var cursor = 0;
            for (int i = 0; i < table.Count; i++)
            {
                cursor += table[i].weight;
                if (cursor < roll) continue;
                result = table[i].item;
                break;
            }
            return result;
        }
    }

    [System.Serializable]
    public struct WeightedItem
    {
        public int weight;
        public GameObject item;
    }
}