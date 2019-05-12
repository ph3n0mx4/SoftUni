namespace GenericArrayCreator
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class ArrayCreator<T>
    {
        public static T[] Create(int lenght, T item)
        {
            T[] arr = new T [lenght];

            for (int i = 0; i < lenght; i++)
            {
                arr[i] = item;
            }
            return arr;
        }
    }
}
