using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif


[CreateAssetMenu(fileName = "Child Destroyer Name", menuName = "New Child Destroyer")]
public class Item : ScriptableObject
{
    public string Name;
    [TextArea]
    public string Description;
    public GameObject PhysicalItem;
    public Sprite IconImage;
}
