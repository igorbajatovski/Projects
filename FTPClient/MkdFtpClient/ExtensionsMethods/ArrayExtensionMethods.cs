using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MkdFtpClient
{
    public static class ArrayExtensionMethods
    {
        public static T[] Insert<T>(this T[] array, T[] toInsert)
        {
            T[] tmp = null;
            if (array == null || array.Length == 0)
            {
                tmp = new T[toInsert.Length];
                for (int i = 0; i < toInsert.Length; ++i)
                    tmp.SetValue(toInsert[i], i);
                array = tmp;
            }
            else
            {
                tmp = new T[array.Length + toInsert.Length];
                for (int i = 0; i < array.Length + toInsert.Length; ++i)
                {
                    if (i < array.Length)
                        tmp.SetValue(array[i], i);
                    else
                        tmp.SetValue(toInsert[i - array.Length], i);
                }
                array = tmp;
            }
            return array;
        }

        public static T[] Insert<T>(this T[] array, T[] toInsert, int offset, int size)
        {
            T[] tmp = null;
            if (array == null || array.Length == 0)
            {
                tmp = new T[size];
                for (int i = offset; i < offset + size; ++i)
                    tmp.SetValue(toInsert[i], i - offset);
                array = tmp;
            }
            else
            {
                tmp = new T[array.Length + size];
                for (int i = 0; i < array.Length; ++i)
                    tmp.SetValue(array[i], i);
                for(int i = offset; i < offset + size; ++i)
                    tmp.SetValue(toInsert[i], array.Length + i - offset);
                array = tmp;
            }
            return array;
        }
    }
}
