using System;


//This utility created to work with arrays rank up to 3
public static class ArrayUtility
{
    public static bool FindArrayElement(Array array, IAbility ability, out int index)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array.GetValue(i) == ability)
            {
                index = i;
                return true;
            }
        }
        index = -1;
        return false;
    }

    public static int GetFreeIndex(Array array)
    {
        for (int i = 0, length = array.Length; i < length; i++)
        {
            switch (array.Rank)
            {
                case 0: 
                    throw new Exception($"{array} is broken");
                case 1: 
                    { 
                        if (array.GetValue(i) == null) return i;
                        break;
                    }
                case 2:
                    {
                        if (array.GetValue(i, 0) == null) return i;
                        break;
                    }
                case 3:
                    {
                        if (array.GetValue(i, 0, 0) == null) return i;
                        break;
                    }
                default: 
                    throw new ArgumentException($"To much ranks assigned to {array}, contact to software developer");
            }
            
        }
        return -1;
    }

    public static void ClearIndex(Array array, int index) => array.SetValue(null, index);
    public static void ClearIndex(Array array, int index0, int index1) => array.SetValue(null, index0, index1);
    public static void ClearIndex(Array array, int index0, int index1, int index2) => array.SetValue(null, index0, index1, index2);
}
