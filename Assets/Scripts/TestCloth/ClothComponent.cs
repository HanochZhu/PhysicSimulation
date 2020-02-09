using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothComponent : MonoBehaviour
{

    public List<SpringNode> SpringNodes;

    [ContextMenu("Add Spring Node From Children")]
    public void UpdateSpringNodeFromChildren()
    {
        SpringNode[] nodes = this.GetComponentsInChildren<SpringNode>();
        SpringNodes = new List<SpringNode>(nodes);
    }

    private void Awake()
    {
        
    }


    private void FixedUpdate()
    {
        
    }
}
