using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**********************************************************************************
***********************************************************************************
* @file ce100_hw2_algo_lib_cs *
* @author Tayfun CANSIZ *
* @date 31 March 2022 * 
*
* @brief <b> hw-2 Functions </b> *
*
* HW-2 Sample Lib Functions *
*
* @see http://bilgisayar.mmf.erdogan.edu.tr/en/
*
***********************************************************************************
***********************************************************************************/

namespace ce100_hw2_algo_lib_cs
{
    public class Class1
    {
        //MATRİX MULTIPLICATION RECURSIVE:

        /**
        *
        *	  @name   MATRİX MULTIPLICATION RECURSIVE
        *
        *	  @brief  MATRİX MULTIPLICATION RECURSIVE Function
        *
        *	  Matrix Multiplication is a binary operation and it produces a matrix from two or more matrices. But for matrix multiplication, 
        *	  the number columns of the first matrix should be equal to the number of rows of the 2nd matrix.
        *
        *	  @param  [in] mass [\i row1, col1, A, row2, col2, B, C int]   MATRİX MULTIPLICATION RECURSIVE in the serie
        *
        *	  @retval [\row1, col1, A, row2, col2, B, C int] MATRİX MULTIPLICATION RECURSIVE
        **/

        public static int MAX = 100;

        // Note that below variables
        // are static i and j are used
        // to know current cell of result
        // matrix C[][]. k is used to
        // know current column number of
        // A[][] and row number of B[][]
        // to be multiplied
        public static int i = 0, j = 0, k = 0;

        public static void multiplyMatrixRec(int row1, int col1,
                                        int[,] A, int row2,
                                        int col2, int[,] B,
                                        int[,] C)
        {
            // If all rows traversed
            if (i >= row1)
                return;

            // If i < row1
            if (j < col2)
            {
                if (k < col1)
                {
                    C[i, j] += A[i, k] * B[k, j];
                    k++;

                    multiplyMatrixRec(row1, col1, A,
                                        row2, col2, B, C);
                }

                k = 0;
                j++;
                multiplyMatrixRec(row1, col1, A,
                                    row2, col2, B, C);
            }

            j = 0;
            i++;
            multiplyMatrixRec(row1, col1, A,
                                row2, col2, B, C);
        }


        //MATRİX MULTIPLICATION STRASSEN:

        /**
        *
        *	  @name   MATRİX MULTIPLICATION STRASSEN
        *
        *	  @brief  MATRİX MULTIPLICATION STRASSEN Function
        *
        *	  Given two square matrices A and B of size n x n each, find their multiplication matrix.
        *
        *	  @param  [in] mass [\n int]   MATRİX MULTIPLICATION STRASSEN in the serie
        *
        *	  @retval [\n int] MATRİX MULTIPLICATION STRASSEN
        **/

        static void calculate(int n)
        {
            Random rng = new Random();
            float[,] m1 = new float[n, n];
            float[,] m2 = new float[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    m1[i, j] = (float)rng.NextDouble();
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    m2[i, j] = (float)rng.NextDouble();
                }
            }

            float[,] m3 = strassen(m1, m2, n);
        }

        public static float[,] strassen(float[,] a, float[,] b, int n)
        {
            if (n == 2)
            {
                var m1 = (a[0, 0] + a[1, 1]) * (b[0, 0] + b[1, 1]);
                var m2 = (a[1, 0] + a[1, 1]) * b[0, 0];
                var m3 = a[0, 0] * (b[0, 1] - b[1, 1]);
                var m4 = a[1, 1] * (b[1, 0] - b[0, 0]);
                var m5 = (a[0, 0] + a[0, 1]) * b[1, 1];
                var m6 = (a[1, 0] - a[0, 0]) * (b[0, 0] + b[0, 1]);
                var m7 = (a[0, 1] - a[1, 1]) * (b[1, 0] + b[1, 1]);
                a[0, 0] = m1 + m4 - m5 + m7;
                a[0, 1] = m3 + m5;
                a[1, 0] = m2 + m4;
                a[1, 1] = m1 - m2 + m3 + m6;
                return a;
            }
            else
            {
                float[,] a11 = matrixDivide(a, n, 11);
                float[,] a12 = matrixDivide(a, n, 12);
                float[,] a21 = matrixDivide(a, n, 21);
                float[,] a22 = matrixDivide(a, n, 22);

                float[,] b11 = matrixDivide(b, n, 11);
                float[,] b12 = matrixDivide(b, n, 12);
                float[,] b21 = matrixDivide(b, n, 21);
                float[,] b22 = matrixDivide(b, n, 22);

                float[,] p1 = strassen(a11, matrixDiff(b12, b22, n / 2), n / 2);
                float[,] p2 = strassen(matrixSum(a11, a12, n / 2), b22, n / 2);
                float[,] p3 = strassen(matrixSum(a21, a22, n / 2), b11, n / 2);
                float[,] p4 = strassen(a22, matrixDiff(b21, b11, n / 2), n / 2);
                float[,] p5 = strassen(matrixSum(a11, a22, n / 2), matrixSum(b11, b22, n / 2), n / 2);
                float[,] p6 = strassen(matrixDiff(a12, a22, n / 2), matrixSum(b21, b22, n / 2), n / 2);
                float[,] p7 = strassen(matrixDiff(a11, a21, n / 2), matrixSum(b11, b12, n / 2), n / 2);

                float[,] c11 = matrixDiff(matrixSum(p5, p4, n / 2), matrixDiff(p2, p6, n / 2), n / 2);
                float[,] c12 = matrixSum(p1, p2, n / 2);
                float[,] c21 = matrixSum(p3, p4, n / 2);
                float[,] c22 = matrixDiff(matrixSum(p1, p5, n / 2), matrixSum(p3, p7, n / 2), n / 2);

                for (int i = 0; i < n / 2; i++)
                {
                    for (int j = 0; j < n / 2; j++)
                    {
                        a[i, j] = c11[i, j];
                        a[i, j + n / 2] = c12[i, j];
                        a[i + n / 2, j] = c21[i, j];
                        a[i + n / 2, j + n / 2] = c22[i, j];
                    }
                }
                return a;
            }
        }

        static float[,] matrixSum(float[,] a, float[,] b, int n)
        {
            float[,] c = new float[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    c[i, j] = a[i, j] + b[i, j];
            return c;
        }


        static float[,] matrixDiff(float[,] a, float[,] b, int n)
        {
            float[,] c = new float[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    c[i, j] = a[i, j] - b[i, j];
            return c;
        }

        static float[,] matrixCombine(float[,] a11, float[,] a12, float[,] a21, float[,] a22, int n)
        {
            float[,] a = new float[n, n];
            for (int i = 0; i < n / 2; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    a[i, j] = a11[i, j];
                    a[i, j + n / 2] = a12[i, j];
                    a[i + n / 2, j] = a21[i, j];
                    a[i + n / 2, j + n / 2] = a22[i, j];
                }
            }
            return a;
        }

        static float[,] matrixDivide(float[,] a, int n, int region)
        {
            float[,] c = new float[n / 2, n / 2];
            if (region == 11)
            {
                for (int i = 0, x = 0; x < n / 2; i++, x++)
                {
                    for (int j = 0, y = 0; y < n / 2; j++, y++)
                    {
                        c[i, j] = a[x, y];
                    }
                }
            }
            else if (region == 12)
            {
                for (int i = 0, x = 0; x < n / 2; i++, x++)
                {
                    for (int j = 0, y = n / 2; y < n; j++, y++)
                    {
                        c[i, j] = a[x, y];
                    }
                }
            }
            else if (region == 21)
            {
                for (int i = 0, x = n / 2; x < n; i++, x++)
                {
                    for (int j = 0, y = 0; y < n / 2; j++, y++)
                    {
                        c[i, j] = a[x, y];
                    }
                }
            }
            else if (region == 22)
            {
                for (int i = 0, x = n / 2; x < n; i++, x++)
                {
                    for (int j = 0, y = n / 2; y < n; j++, y++)
                    {
                        c[i, j] = a[x, y];
                    }
                }
            }
            return c;
        }

        //MATRİX MULTIPLICATION ITERATIVE:

        /**
        *
        *	  @name   MATRİX MULTIPLICATION ITERATIVE
        *
        *	  @brief  MATRİX MULTIPLICATION ITERATIVE Function
        *
        *	  The definition of matrix multiplication is that if C = AB for an n × m matrix A and an m × p matrix B, then C is an n × p matrix with entries
        *
        *	  @param  [in] mass [\mat1, mat2, res int]   MATRİX MULTIPLICATION ITERATIVE in the serie
        *
        *	  @retval [\mat1, mat2, rec int] MATRİX MULTIPLICATION ITERATIVE
        **/

        static int N = 4;

        // This function multiplies mat1[][]
        // and mat2[][], and stores the result
        // in res[][]
        public static int[,] multiply(int[,] mat1,
                             int[,] mat2, int[,] res)
        {
            int i, j, k;
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < N; j++)
                {
                    res[i, j] = 0;
                    for (k = 0; k < N; k++)
                        res[i, j] += mat1[i, k]
                                     * mat2[k, j];
                }
            }
            return res;
        }

        //QUICKSORT LOMUTO:

       /**
       *
       *	  @name   QUICKSORT LOMUTO
       *
       *	  @brief  QUICKSORT LOMUTO Function
       *
       *	  The algorithm maintains index i as it scans the array using another index j such that the elements at lo through i-1 (inclusive) are less than the pivot,
       *	  and the elements at i through j (inclusive) are equal to or greater than the pivot.
       *
       *	  @param  [in] mass [\array, position1, position2 int]   QUICKSORT LOMUTO in the serie
       *
       *	  @retval [\array, position1, posititon2 int] QUICKSORT LOMUTO
       **/

        static void Swap(int[] array,
                            int position1,
                            int position2)
         {
            // Swaps elements in an array

            // Copy the first position's element
            int temp = array[position1];

            // Assign to the second element
            array[position1] = array[position2];

            // Assign to the first element
            array[position2] = temp;
         }

        /* This function takes last element as
        pivot, places the pivot element at its
        correct position in sorted array, and
        places all smaller (smaller than pivot)
        to left of pivot and all greater elements
        to right of pivot */
        static int partition(int[] arr, int low,
                                        int high)
        {
            int pivot = arr[high];

            // Index of smaller element
            int i = (low - 1);

            for (int j = low; j <= high - 1; j++)
            {
                // If current element is smaller
                // than or equal to pivot
                if (arr[j] <= pivot)
                {
                    i++; // increment index of
                            // smaller element
                    Swap(arr, i, j);
                }
            }
            Swap(arr, i + 1, high);
            return (i + 1);
        }

        /* The main function that
            implements QuickSort
        arr[] --> Array to be sorted,
        low --> Starting index,
        high --> Ending index */
        public static void quickSort(int[] arr, int low,
                                            int high)
        {
            if (low < high)
            {
                /* pi is partitioning index,
                arr[p] is now at right place */
                int pi = partition(arr, low, high);

                // Separately sort elements before
                // partition and after partition
                quickSort(arr, low, pi - 1);
                quickSort(arr, pi + 1, high);
            }
        }




        //QUICKSORT HOURE:

       /**
       *
       *	  @name   QUICKSORT HOURE
       *
       *	  @brief  QUICKSORT HOURE Function
       *
       *	  Two pointers (indices into the range) that start at both ends of the array being partitioned,
       *	  then move toward each other, until they detect an inversion: a pair of elements, one greater than the bound
       *	  (Hoare's terms for the pivot value) at the first pointer, and one less than the bound at the second pointer; 
       *	  if at this point the first pointer is still before the second, these elements are in the wrong order relative to each other, and they are then exchanged.
       *
       *	  @param  [in] mass [\arr, low, high int]   QUICKSORT HOURE in the serie
       *
       *	  @retval [\arr, low, high int] QUICKSORT HOURE
       **/

        /* This function takes first element as pivot, and
            places all the elements smaller than the pivot on the
            left side and all the elements greater than the pivot
            on the right side. It returns the index of the last
            element on the smaller side*/
        static int partitionn(int[] arr, int low, int high)
        {
            int pivot = arr[low];
            int i = low - 1, j = high + 1;

            while (true)
            {
                // Find leftmost element greater
                // than or equal to pivot
                do
                {
                    i++;
                } while (arr[i] < pivot);

                // Find rightmost element smaller
                // than or equal to pivot
                do
                {
                    j--;
                } while (arr[j] > pivot);

                // If two pointers met.
                if (i >= j)
                    return j;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
                // swap(arr[i], arr[j]);
            }
        }

        /* The main function that
            implements QuickSort
        arr[] --> Array to be sorted,
        low --> Starting index,
        high --> Ending index */
        public static void quickSortHo(int[] arr, int low, int high)
        {
            if (low < high)
            {
                /* pi is partitioning index,
                arr[p] is now at right place */
                int pi = partitionn(arr, low, high);

                // Separately sort elements before
                // partition and after partition
                quickSortHo(arr, low, pi);
                quickSortHo(arr, pi + 1, high);
            }
        }




        //RANDOMIZED QUICKSORT LAMUTO:

        /**
        *
        *   @name   RANDOMIZED QUICKSORT LAMUTO
        *
        *	@brief  RANDOMIZED QUICKSORT LAMUTO Function
        *
        *   In QuickSort we first partition the array in place such that all elements to the left of the pivot element are smaller,
        *   while all elements to the right of the pivot are greater than the pivot.
        *
        *	@param  [in] mass [\arr, low, high int]   RANDOMIZED QUICKSORT LAMUTO in the serie
        *
        *	@retval [\arr, low, high int] RANDOMIZED QUICKSORT LAMUTO
        **/

        /* This function takes last element as pivot,
            places the pivot element at its correct
            position in sorted array, and places all
            smaller (smaller than pivot) to left of
            pivot and all greater elements to right
            of pivot */
        static int partitioon(int[] arr, int low, int high)
        {

            // pivot is chosen randomly
            random(arr, low, high);
            int pivot = arr[high];

            int i = (low - 1); // index of smaller element
            for (int j = low; j < high; j++)
            {

                // If current element is smaller than or
                // equal to pivot
                if (arr[j] < pivot)
                {
                    i++;

                    // swap arr[i] and arr[j]
                    int tempp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tempp;
                }
            }

            // swap arr[i+1] and arr[high] (or pivot)
            int tempp2 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = tempp2;

            return i + 1;
        }

        // This Function helps in calculating
        // random numbers between low(inclusive)
        // and high(inclusive)
        public static int random(int[] arr, int low, int high)
        {

            Random rand = new Random();
            int pivot = rand.Next(low, high) % (high - low) + low;

            int tempp1 = arr[pivot];
            arr[pivot] = arr[high];
            arr[high] = tempp1;

            return partition(arr, low, high);
        }

        /* The main function that implements Quicksort()
            arr[] --> Array to be sorted,
            low --> Starting index,
            high --> Ending index */
        public static void QuickSoLo(int[] arr, int low, int high)
        {
            if (low < high)
            {
                /* pi is partitioning index, arr[pi] is
                        now at right place */
                int pi = partition(arr, low, high);

                // Recursively sort elements before
                // partition and after partition
                QuickSoLo(arr, low, pi - 1);
                QuickSoLo(arr, pi + 1, high);
            }
        }




        //RANDOMIZED QUICKSORT HOURE:

        /**
        *
        *   @name   RANDOMIZED QUICKSORT HOURE
        *
        *	@brief  RANDOMIZED QUICKSORT HOURE Function
        *
        *   In QuickSort we first partition the array in place such that all elements to the left of the pivot element are smaller,
        *   while all elements to the right of the pivot are greater than the pivot.
        *
        *	@param  [in] mass [\arr, low, high int]   RANDOMIZED QUICKSORT HOURE in the serie
        *
        *	@retval [\arr, low, high int] RANDOMIZED QUICKSORT HOURE
        **/

        public static int randomhoarepartition(int[] arr, int low, int high)
        {
            int pivot = arr[low];
            int i = low - 1, j = high + 1;

            while (true)
            {

                // Find leftmost element greater than
                // or equal to pivot
                do
                {
                    i++;
                } while (arr[i] < pivot);

                // Find rightmost element smaller than
                // or equal to pivot
                do
                {
                    j--;
                } while (arr[j] > pivot);

                // If two pointers met
                if (i >= j)
                    return j;

                int tempp = arr[i];
                arr[i] = arr[j];
                arr[j] = tempp;
            }
        }
        public static int Random(int[] arr, int low, int high)
        {
            // Generate a random number in between
            // low .. high
            Random rand = new Random();
            int pivot = rand.Next() % (high - low) + low;

            int tempp1 = arr[pivot];
            arr[pivot] = arr[high];
            arr[high] = tempp1;

            return randomhoarepartition(arr, low, high);
        }
        public static void randomQuicksortHoare(int[] array, int lw, int high)
        {
            if (lw < high)
            {
                /* pi is partitioning index, arr[pi] is
                      now at right place */
                int pi = Random(array, lw, high);

                // Recursively sort elements before
                // partition and after partition
                randomQuicksortHoare(array, lw, pi);
                randomQuicksortHoare(array, pi + 1, high);
            }
        }



        //SELECTION PROBLEM:

        /**
      *
      *	  @name   findMedian (Selection Problem)
      *
      *	  @brief Selection Problem
      *
      *	  Selection Problem
      *
      *	  @param  [in] arr [\b int]  arr
      *	  
      *	  @param  [in] i [\b int]  i
      *	  
      *	  @param  [in] n [\b int]  n
      *	  
      *	   
      *	  
      **/


        static int findMedian(int[] arr, int i, int n)
        {
            if (i <= n)
                Array.Sort(arr, i, n); // Sort the array
            else
                Array.Sort(arr, n, i);
            return arr[n / 2]; // Return middle element
        }

        // Returns k'th smallest element
        // in arr[l..r] in worst case
        // linear time. ASSUMPTION: ALL
        // ELEMENTS IN ARR[] ARE DISTINCT
        public static int kthSmallest(int[] arr, int l,
                                    int r, int k)
        {
            // If k is smaller than
            // number of elements in array
            if (k > 0 && k <= r - l + 1)
            {
                int n = r - l + 1; // Number of elements in arr[l..r]

                // Divide arr[] in groups of size-* 5,
                // calculate median of every group
                // and store it in median[] array.
                int i;

                // There will be floor((n+4)/5) groups;
                int[] median = new int[(n + 4) / 5];
                for (i = 0; i < n / 5; i++)
                    median[i] = findMedian(arr, l + i * 5, 5);

                // For last group with less than 5 elements
                if (i * 5 < n)
                {
                    median[i] = findMedian(arr, l + i * 5, n % 5);
                    i++;
                }

                // Find median of all medians using recursive call.
                // If median[] has only one element, then no need
                // of recursive call
                int medOfMed = (i == 1) ? median[i - 1] :
                                        kthSmallest(median, 0, i - 1, i / 2);

                // Partition the array around a random element and
                // get position of pivot element in sorted array
                int pos = partition(arr, l, r, medOfMed);

                // If position is same as k
                if (pos - l == k - 1)
                    return arr[pos];
                if (pos - l > k - 1) // If position is more, recur for left
                    return kthSmallest(arr, l, pos - 1, k);

                // Else recur for right subarray
                return kthSmallest(arr, pos + 1, r, k - pos + l - 1);
            }

            // If k is more than number of elements in array
            return int.MaxValue;
        }

        static int[] swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
            return arr;
        }

        // It searches for x in arr[l..r], and
        // partitions the array around x.
        static int partition(int[] arr, int l,
                                int r, int x)
        {
            // Search for x in arr[l..r] and move it to end
            int i;
            for (i = l; i < r; i++)
                if (arr[i] == x)
                    break;
            swap(arr, i, r);

            // Standard partition algorithm
            i = l;
            for (int j = l; j <= r - 1; j++)
            {
                if (arr[j] <= x)
                {
                    swap(arr, i, j);
                    i++;
                }
            }
            swap(arr, i, r);
            return i;
        }





        //HEAPSORT:

        /**
        *
        *   @name   HEAPSORT
        *
        *	@brief  HEAPSORT Function
        *
        *   Heap sort is a comparison-based sorting technique based on Binary Heap data structure. 
        *   It is similar to selection sort where we first find the minimum element and place the minimum element at the beginning.
        *
        *	@param  [in] mass [\arr, n int]   HEAPSORT in the serie
        *
        *   @retval [\arr, n int] HEAPSORT
        **/

        public static void heapSort(int[] arr, int n)
        {
            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(arr, n, i);
            for (int i = n - 1; i >= 0; i--)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                heapify(arr, i, 0);
            }
        }
        static void heapify(int[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < n && arr[left] > arr[largest])
                largest = left;
            if (right < n && arr[right] > arr[largest])
                largest = right;
            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;
                heapify(arr, n, largest);
            }
        }




        //PRIOTY QUEUE WITH HEAP:

        /**
        *
        *   @name   PRIOTY QUEUE WITH HEAP
        *
        *	@brief  PRIOTY QUEUE WITH HEAP Function
        *
        *   1.Every item has a priority associated with it.
        *    2.An element with high priority is dequeued before an element with low priority.
        *    3.If two elements have the same priority, they are served according to their order in the queue.
        *
        *	@param  [in] mass [\i, p int]   PRIOTY QUEUE WITH HEAP in the serie
        *
        *   @retval [\i, p int] PRIOTY QUEUE WITH HEAP
        **/

        static int[] H = new int[50];
        static int size = -1;

        // Function to return the index of the
        // parent node of a given node
        static int parent(int i)
        {
            return (i - 1) / 2;
        }

        // Function to return the index of the
        // left child of the given node
        static int leftChild(int i)
        {
            return ((2 * i) + 1);
        }

        // Function to return the index of the
        // right child of the given node
        static int rightChild(int i)
        {
            return ((2 * i) + 2);
        }

        // Function to shift up the
        // node in order to maintain
        // the heap property
        static void shiftUp(int i)
        {
            while (i > 0 &&
                   H[parent(i)] < H[i])
            {

                // Swap parent and current node
                swapheap(parent(i), i);

                // Update i to parent of i
                i = parent(i);
            }
        }

        // Function to shift down the node in
        // order to maintain the heap property
        static void shiftDown(int i)
        {
            int maxIndex = i;

            // Left Child
            int l = leftChild(i);

            if (l <= size &&
                H[l] > H[maxIndex])
            {
                maxIndex = l;
            }

            // Right Child
            int r = rightChild(i);

            if (r <= size &&
                H[r] > H[maxIndex])
            {
                maxIndex = r;
            }

            // If i not same as maxIndex
            if (i != maxIndex)
            {
                swapheap(i, maxIndex);
                shiftDown(maxIndex);
            }
        }

        // Function to insert a
        // new element in
        // the Binary Heap
       public static void insert(int p)
        {
            size = size + 1;
            H[size] = p;

            // Shift Up to maintain
            // heap property
            shiftUp(size);
        }

        // Function to extract
        // the element with
        // maximum priority
      public static int extractMax()
        {
            int result = H[0];

            // Replace the value
            // at the root with
            // the last leaf
            H[0] = H[size];
            size = size - 1;

            // Shift down the replaced
            // element to maintain the
            // heap property
            shiftDown(0);
            return result;
        }

        // Function to change the priority
        // of an element
        static void changePriority(int i,
                                   int p)
        {
            int oldp = H[i];
            H[i] = p;

            if (p > oldp)
            {
                shiftUp(i);
            }
            else
            {
                shiftDown(i);
            }
        }

        // Function to get value of
        // the current maximum element
        static int getMaxheap()
        {
            return H[0];
        }

        // Function to remove the element
        // located at given index
        static void Remove(int i)
        {
            H[i] = getMaxheap() + 1;

            // Shift the node to the root
            // of the heap
            shiftUp(i);

            // Extract the node
            extractMax();
        }

        static void swapheap(int i, int j)
        {
            int temp = H[i];
            H[i] = H[j];
            H[j] = temp;
        }




        //COUNTING SORT:

        /**
        *
        *   @name   COUNTING SORT
        *
        *	@brief  COUNTING SORT Function
        *
        *   Counting sort is a sorting algorithm that sorts the elements of an array by counting the number of occurrences of each unique element in the array.
        *   The count is stored in an auxiliary array and the sorting is done by mapping the count as an index of the auxiliary array.
        *
        *	@param  [in] mass [\arr int]   COUNTING SORT in the serie
        *
        *   @retval [\arr int] COUNTING SORT
        **/

        public static void CountingSort(int[] arr)
        {
            int max = arr.Max();
            int min = arr.Min();
            int range = max - min + 1;
            int[] count = new int[range];
            int[] output = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                count[arr[i] - min]++;
            }
            for (int i = 1; i < count.Length; i++)
            {
                count[i] += count[i - 1];
            }
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                output[count[arr[i] - min] - 1] = arr[i];
                count[arr[i] - min]--;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = output[i];
            }
        }

        public static void RadixSort(int[] arr)
        {
            int i, j;
            int[] tmp = new int[arr.Length];
            for (int shift = 31; shift > -1; --shift)
            {
                j = 0;
                for (i = 0; i < arr.Length; ++i)
                {
                    bool move = (arr[i] << shift) >= 0;
                    if (shift == 0 ? !move : move)
                        arr[i - j] = arr[i];
                    else
                        tmp[j++] = arr[i];
                }
                Array.Copy(tmp, 0, arr, arr.Length - j, j);

            }

        }




        //RADIX SORT:

        /**
        *
        *   @name   RADIX SORT
        *
        *   @brief  RADIX SORT Function
        *
        *   Sorting by digit is a sorting algorithm in computer science that sorts numbers by operating on their digits.
        *
        *   @param  [in] mass [\arr, n int]   RADIX SORT in the serie
        *
        *   @retval [\arr, n int] RADIX SORT
        **/

        public static int getMax(int[] arr, int n)
        {
            int mx = arr[0];
            for (int i = 1; i < n; i++)
                if (arr[i] > mx)
                    mx = arr[i];
            return mx;
        }

        // A function to do counting sort of arr[] according to
        // the digit represented by exp.
        public static void countSort(int[] arr, int n, int exp)
        {
            int[] output = new int[n]; // output array
            int i;
            int[] count = new int[10];

            // initializing all elements of count to 0
            for (i = 0; i < 10; i++)
                count[i] = 0;

            // Store count of occurrences in count[]
            for (i = 0; i < n; i++)
                count[(arr[i] / exp) % 10]++;

            // Change count[i] so that count[i] now contains
            // actual
            //  position of this digit in output[]
            for (i = 1; i < 10; i++)
                count[i] += count[i - 1];

            // Build the output array
            for (i = n - 1; i >= 0; i--)
            {
                output[count[(arr[i] / exp) % 10] - 1] = arr[i];
                count[(arr[i] / exp) % 10]--;
            }

            // Copy the output array to arr[], so that arr[] now
            // contains sorted numbers according to current
            // digit
            for (i = 0; i < n; i++)
                arr[i] = output[i];
        }

        // The main function to that sorts arr[] of size n using
        // Radix Sort
        public static void radixsort(int[] arr, int n)
        {
            // Find the maximum number to know number of digits
            int m = getMax(arr, n);

            // Do counting sort for every digit. Note that
            // instead of passing digit number, exp is passed.
            // exp is 10^i where i is current digit number
            for (int exp = 1; m / exp > 0; exp *= 10)
                countSort(arr, n, exp);
        }
    }
}

