﻿

using System.Collections.Generic;

namespace UdonSharp
{
    [System.Serializable]
    public class FieldDefinition
    {
        public FieldDefinition(SymbolDefinition symbol)
        {
            fieldSymbol = symbol;
            fieldAttributes = new List<System.Attribute>();
        }

        public SymbolDefinition fieldSymbol;

        public List<System.Attribute> fieldAttributes;
        
        public UnityEditor.MonoScript userBehaviourSource;

        public T GetAttribute<T>() where T : System.Attribute
        {
            System.Type attributeType = typeof(T);

            foreach (var attribute in fieldAttributes)
            {
                if (attribute.GetType() == attributeType)
                    return attribute as T;
            }

            return null;
        }

    }

    public class ClassDefinition
    {
        // Methods and fields should *not* be reflected off of this type, it is not guaranteed to be up to date
        public System.Type userClassType;
        public UnityEditor.MonoScript classScript;

        public List<FieldDefinition> fieldDefinitions = new List<FieldDefinition>();
        public List<MethodDefinition> methodDefinitions = new List<MethodDefinition>();
    }
}