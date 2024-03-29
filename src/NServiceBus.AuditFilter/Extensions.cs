﻿static class Extensions
{
    public static T GetAttribute<T>(this Type type)
        where T : Attribute =>
        (T)Attribute.GetCustomAttribute(type, typeof(T), true)!;
}