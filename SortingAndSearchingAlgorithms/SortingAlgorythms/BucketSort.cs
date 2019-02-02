namespace SortingAlgorythms
{
    using System.Collections.Generic;

    public static class BucketSort
    {
        public static void Sort(ref int[] data)
        {
            int minValue = data[0];
            int maxValue = data[0];

            for (int i = 1; i < data.Length; i++)
            {
                if (data[i] > maxValue)
                    maxValue = data[i];
                if (data[i] < minValue)
                    minValue = data[i];
            }

            LinkedList<int>[] bucket = new LinkedList<int>[maxValue - minValue + 1];

            //a sorting algorithm that works by partitioning an array into a number buckets
           
            //move items to bucket
            for (int i = 0; i < data.Length; i++)
            {
                if (bucket[data[i] - minValue]==null)
                {
                    bucket[data[i] - minValue]=new LinkedList<int>();
                }

                bucket[data[i] - minValue].AddLast(data[i]);
            }
	
            //Each bucket then sorted individually, either using a different sorting algorithm, or by recursively applying the bucket sorting algorithm.
            //Move items in the bucket back to the original array in order
            int k = 0;
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i] != null)
                {
                    LinkedListNode<int> node = bucket[i].First; //start add head of linked list

                    while (node != null)
                    {
                        data[k] = node.Value; //get value of current linked node
                        node = node.Next; //move to next linked node
                        k++;
                    }
                }
            }
        }
    }
}
