using System;
using Newtonsoft.Json.Serialization;

namespace Content.Shared.GameObjects
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class IgnoreOnServerAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class IgnoreOnClientAttribute : Attribute { }
}
