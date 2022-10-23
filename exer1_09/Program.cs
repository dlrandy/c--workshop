static int[] BubbleSort(int[] array){
    int temp;

    for (int i = 0; i < array.Length; i++)
    {
        for (int j = 0; j < array.Length - i - 1; j++)
        {
            if (array[j] < array[j + 1])
            {
                temp = array[j];
                array[j] = array[j + 1];
                array[j + 1] = temp;
            }
        }
    }
    return array;
}
int[] nums = {4,2,3,2,4,5,67,34,3,2,3,23,2,344};
int[] snums = BubbleSort(nums);
 

for (int i = 0; i < snums.Length; i++)
{
 Console.Write(snums[i] + " ");
}

foreach (int ele in nums)
{
    Console.WriteLine(ele);
}