using System;
using System.Collections.Generic;
using System.Text;

namespace GenericArrayCreator
{
    public class ArrayCreator
    {
        public static T[] Create<T>(int length, T defaultItem)
        {
            var arr = new T[length];

            for (int i = 0; i < length; i++)
            {
                arr[i] = defaultItem;
            }

            return arr;
        }
    }
}
