using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu]
public class GimmickDataBase : ScriptableObject
{
    public List<LiftMove> _gameObjectsList = new();
}
