using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeType
{
    Anchor,// constant node
    Node   // flexible node
}

public class SpringNode : MonoBehaviour
{
    public NodeType nodeType;
    // 相关被影响的弹簧
    //
    //
    //
    public List<SpringNode> StructSpring;// 结构弹簧   
    public List<SpringNode> SheerSpring;// 剪切弹簧
    public List<SpringNode> Blendingpring;// 拉伸弹簧

    public Vector3 GetForce()
    {
        return Vector3.zero;
    }

    [ContextMenu("Update Spring")]
    public void UpdateSpring()
    {
        foreach (var item in StructSpring)
        {
            if (!item.StructSpring.Contains(this))
            {
                item.StructSpring.Add(this);
            }
        }
        foreach (var item in SheerSpring)
        {
            if (!item.SheerSpring.Contains(this))
            {
                item.SheerSpring.Add(this);
            }
        }
        foreach (var item in Blendingpring)
        {
            if (!item.Blendingpring.Contains(this))
            {
                item.Blendingpring.Add(this);
            }
        }
    }
}
