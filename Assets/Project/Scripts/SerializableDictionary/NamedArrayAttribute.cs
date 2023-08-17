using UnityEngine;

namespace RedPanda.Project.SerializableDictionary
{
    public class NamedArrayAttribute : PropertyAttribute
    {
        public readonly string FieldName;

        public NamedArrayAttribute(string fieldName)
        {
            FieldName = fieldName;
        }
    }
}