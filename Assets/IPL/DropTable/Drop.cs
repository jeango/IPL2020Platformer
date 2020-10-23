using System.Collections;
using System.Collections.Generic;
using IPL.DropTable;
using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] private DropTable dropTable;

    public void SpawnDrop()
    {
        var drop = dropTable.Drop();
        if (drop)
            Instantiate(drop, transform.position, Quaternion.identity);
    }
}
