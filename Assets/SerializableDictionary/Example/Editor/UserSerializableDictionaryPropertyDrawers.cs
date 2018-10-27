using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(StringStringDictionary))]
[CustomPropertyDrawer(typeof(ObjectColorDictionary))]
[CustomPropertyDrawer(typeof(StringColorArrayDictionary))]
public class AnySerializableDictionaryPropertyDrawer : SerializableDictionaryPropertyDrawer {}
[CustomPropertyDrawer(typeof(TerrainVisualsDictionary))]
public class TerrainVisualsDictionaryPropertyDrawer : SerializableDictionaryPropertyDrawer { }


[CustomPropertyDrawer(typeof(GameObjectListStorage))]
public class GameObjectListStoragePropertyDrawer : SerializableDictionaryStoragePropertyDrawer { }

[CustomPropertyDrawer(typeof(ColorArrayStorage))]
public class AnySerializableDictionaryStoragePropertyDrawer: SerializableDictionaryStoragePropertyDrawer {}
