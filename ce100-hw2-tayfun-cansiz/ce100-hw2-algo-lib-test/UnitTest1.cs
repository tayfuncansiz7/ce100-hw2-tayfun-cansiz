using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ce100_hw2_algo_lib_cs;
using ce100_hw2_algo_lib_test;


namespace ce100_hw2_algo_lib_test
{
    [TestClass]
    public class UnitTest1   
    {
        //MatrixMulRecTest
        [TestMethod]
        public void MatrixMulRecTest1()
        {
            int row1 = 2, col1 = 2,
            row2 = 2, col2 = 2;
            int[,] A = {{3, 2},
                       {4, 5} };
            Class1.i = 0; Class1.j = 0; Class1.k = 0;

            int[,] B = {{1, 7},
                       {3, 4} };

            int[,] C = new int[row1, col2];

            int[,] expected = { { 9, 29 },
                              { 19, 48 } };

            Class1.multiplyMatrixRec(row1, col1, A, row2, col2, B, C);
            CollectionAssert.AreEqual(expected, C);
        }
    

        [TestMethod]
        public void MatrixMulRecTest2()
        {
            int row1 = 2, col1 = 2,
            row2 = 2, col2 = 2;
            int[,] A = {{8, 2},
                       {5, 6} };
            Class1.i = 0; Class1.j = 0; Class1.k = 0;

            int[,] B = {{4, 5},
                       {5, 2} };

            int[,] C = new int[row1, col2];

            int[,] expected = { { 42, 44 },
                              { 50, 37 } };

            Class1.multiplyMatrixRec(row1, col1, A, row2, col2, B, C);
            CollectionAssert.AreEqual(expected, C);
        }

        [TestMethod]
        public void MatrixMulRecTest3()
        {
            int row1 = 2, col1 = 2,
            row2 = 2, col2 = 2;
            int[,] A = {{3, 6},
                       {4, 7} };
            Class1.i = 0; Class1.j = 0; Class1.k = 0;

            int[,] B = {{6 ,4},
                        {5, 1} };

            int[,] C = new int[row1, col2];

            int[,] expected = { { 48, 18 },
                              { 59, 23 } };

            Class1.multiplyMatrixRec(row1, col1, A, row2, col2, B, C);
            CollectionAssert.AreEqual(expected, C);
        }

        //MatrixMulStrTest
        [TestMethod]
        public void MatrixMulStrTest1()
        {
            float[,] array = { { 3, 3 },
                           { 4, 4 } };
            float n = 2;               

            float[,] array2 = { { 5, 5 },
                            { 6, 6 } };

            float[,] result = { { 33, 33 },
                            { 44, 44 } };

            float[,] exp = Class1.strassen(array, array2, 2);
            CollectionAssert.AreEqual(exp, result);
        }

        [TestMethod]
        public void MatrixMulStrTest2()
        {
            float[,] array = { { 3, 2 },
                           { 2, 4 } };
            float n = 2;

            float[,] array2 = { { 5, 3 },
                            { 6, 0 } };

            float[,] result = { { 27, 9 },
                            { 34, 6 } };

            float[,] exp = Class1.strassen(array, array2, 2);
            CollectionAssert.AreEqual(exp, result);
        }

        [TestMethod]
        public void MatrixMulStrTest3()
        {
            float[,] array = { { 4, 5 },
                           { 7, 4 } };
            float n = 2;

            float[,] array2 = { { 3, 0 },
                            { 4, 6 } };

            float[,] result = { { 32, 30 },
                            { 37, 24 } };

            float[,] exp = Class1.strassen(array, array2, 2);
            CollectionAssert.AreEqual(exp, result);
        }

        //MatrixMulItrTest
        [TestMethod]
        public void MatrixMulItrTest1()
        {
            int[,] array = { { 1, 1, 1, 1 },
                           { 2, 2, 2, 2 },
                           { 3, 3, 3, 3 },
                           { 4, 4, 4, 4 } };

            int[,] array2 = { { 1, 1, 1, 1 },
                            { 2, 2, 2, 2 },
                            { 3, 3, 3, 3 },
                            { 4, 4, 4, 4 } };

            int[,] result =  { { 10, 10, 10, 10 },
                             { 20, 20, 20, 20 },
                             { 30, 30, 30, 30 },
                             { 40, 40, 40, 40 } };

            int[,] exp = Class1.multiply(array, array2, result);
            CollectionAssert.AreEqual(exp, result);
        }

        [TestMethod]
        public void MatrixMulItrTest2()
        {
            int[,] array = { { 1, 3, 4, 2 },
                           { 2, 3, 1, 4 },
                           { 4, 3, 2, 1 },
                           { 3, 4, 1, 2 } };

            int[,] array2 = { { 4, 2, 3, 1 },
                            { 3, 4, 1, 2 },
                            { 1, 4, 2, 3 },
                            { 2, 3, 4, 1 } };

            int[,] result = { { 21, 36, 22, 21 },
                            { 26, 32, 27, 15 },
                            { 29, 31, 23, 17 },
                            { 29, 32, 23, 16 } };

            int[,] exp = Class1.multiply(array, array2, result);
            CollectionAssert.AreEqual(exp, result);

        }

        [TestMethod]
        public void MatrixMulItrTest3()
        {
            int[,] array = { { 3, 2, 1, 0 },
                           { 3, 2, 0, 1 },
                           { 1, 3, 0, 2 },
                           { 0, 1, 2, 3 } };

            int[,] array2 = { { 2, 4, 1, 0 },
                            { 4, 2, 0, 3 },
                            { 3, 0, 2, 4 },
                            { 0, 2, 1, 3 } };

            int[,] result = { { 17, 16, 5, 10 },
                            { 14, 18, 4, 9 },
                            { 14, 14, 3, 15 },
                            { 10, 8, 7, 20 } };
            int[,] exp = Class1.multiply(array, array2, result);
            CollectionAssert.AreEqual (exp, result);
        }

        //QuickSoLoTest
        [TestMethod]
        public void QuickSoLoTest1()
        {
            int[] array = { 5, 2, 1, 8, 9, 0, 7, 6 };
            int n = array.Length - 1;
            int[] expected = { 0, 1, 2, 5, 6, 7, 8 ,9 };

            Class1.quickSort(array, 0, n);
            CollectionAssert.AreEqual(array, expected);
        }

        [TestMethod]
        public void QuickSoLoTest2()
        {
            int[] array = { 31, 58, 53, 34, 33, 27, 78 };
            int n = array.Length - 1;
            int[] expected = { 27, 31, 33, 34, 53, 58, 78 };

            Class1.quickSort(array, 0, n);
            CollectionAssert.AreEqual(array, expected);
        }

        [TestMethod]
        public void QuickSoLoTest3()
        {
            int[] array = { 235, 532, 742, 364, 395, 294, 619 };
            int n = array.Length - 1;
            int[] expected = { 235, 294, 364, 395, 532, 619, 742 };

            Class1.quickSort(array, 0, n);
            CollectionAssert.AreEqual(array, expected);
        }

        //QuickSoHoTest
        [TestMethod]
        public void QuickSoHoTest1()
        {
            int[] array = { 6, 2, 8, 1, 0, 5, 9 };
            int n = array.Length - 1;
            int[] expected = { 0, 1, 2, 5, 6, 8, 9 };

            Class1.quickSortHo(array, 0, n);
            CollectionAssert.AreEqual(expected, array);
        }

        [TestMethod]
        public void QuickSoHoTest2()
        {
            int[] array = { 52, 32, 10, 84, 67, 93, 21 };
            int n = array.Length - 1;
            int[] expected = { 10, 21, 32, 52, 67, 84, 93 };

            Class1.quickSortHo(array, 0, n);
            CollectionAssert.AreEqual(expected, array);
        }

        [TestMethod]
        public void QuickSoHoTest3()
        {
            int[] array = { 535, 314, 183, 862, 651, 910, 253 };
            int n = array.Length - 1;
            int[] expected = { 183, 253, 314, 535, 651, 862, 910 };

            Class1.quickSortHo(array, 0, n);
            CollectionAssert.AreEqual(expected, array);
        }

        //RandomizedQuickSoLoTest
        [TestMethod]
        public void RandomizedQuickSoLoTest1()
        {
            int[] array = { 3, 1, 5, 7, 8, 0, 9 };
            int n = array.Length - 1;
            int[] expected = { 0, 1, 3, 5, 7, 8, 9 };

            Class1.QuickSoLo(array, 0, n);
            CollectionAssert.AreEqual(array, expected);
        }

        [TestMethod]
        public void RandomizedQuickSoLoTest2()
        {
            int[] array = { 27, 16, 87, 21, 22, 47, 36 };
            int n = array.Length - 1;
            int[] expected = { 16, 21, 22, 27, 36, 47, 87 };

            Class1.QuickSoLo(array, 0, n);
            CollectionAssert.AreEqual(array, expected);
        }

        [TestMethod]
        public void RandomizedQuickSoLoTest3()
        {
            int[] array = { 487, 134, 792, 376, 931, 685, 201 };
            int n = array.Length - 1;
            int[] expected = { 134, 201, 376, 487, 685, 792, 931 };

            Class1.QuickSoLo(array, 0, n);
            CollectionAssert.AreEqual(array, expected);
        }

        //RandomizedQuickSoHoTest
        [TestMethod]
        public void RandomizedQuickSoHoTest1()
        {
            int[] array = { 2, 8, 6, 9, 0, 1, 5, 3 };
            int n = array.Length;
            int[] expected = { 0, 1, 2, 3, 5, 6, 8, 9 };

            Class1.randomQuicksortHoare(array, 0, n-1);
            CollectionAssert.AreEqual(array, expected);
        }

        [TestMethod]
        public void RandomizedQuickSoHoTest2()
        {
            int[] array = { 46, 87, 13, 94, 51, 74, 25 };
            int n = array.Length;
            int[] expected = { 13, 25, 46, 51, 74, 87, 94 };

            Class1.randomQuicksortHoare(array, 0, n - 1);
            CollectionAssert.AreEqual(array, expected);
        }

        [TestMethod]
        public void RandomizedQuickSoHoTest3()
        {
            int[] array = { 325, 642, 419, 143, 962, 526, 793, 275 };
            int n = array.Length;
            int[] expected = { 143, 275, 325, 419, 526, 642, 793, 962 };

            Class1.randomQuicksortHoare(array, 0, n - 1);
            CollectionAssert.AreEqual(array, expected);
        }

        [TestMethod]
        public void SelectionProblem_1()
        {
            int[] arr = { 55, 63, 5, 8, 22, 9 };
            int n = arr.Length, k = 6;
            int expected = 63;
            int actual = Class1.kthSmallest(arr, 0, n - 1, k);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void SelectionProblemTest2()
        {
            int[] arr = { 43, 29, 7, 19, 17, 30 };
            int n = arr.Length, k = 1;
            int expected = 7;
            int actual = Class1.kthSmallest(arr, 0, n - 1, k);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SelectionProblemTest3()
        {
            int[] arr = { 4, 5, 9, 15, 33, 45 };
            int n = arr.Length, k = 6;
            int expected = 45;
            int actual = Class1.kthSmallest(arr, 0, n - 1, k);
            Assert.AreEqual(expected, actual);
        }


            //HeapSoTest
            [TestMethod]
        public void HeapSoTest1()
        {
            int[] array = new int[] { 3, 1, 6, 0, 2 };
            int n = array.Length;
            int[] expected = new int[] { 0, 1, 2, 3, 6 };

            Class1.heapSort(array, n);
            CollectionAssert.AreEqual(expected, array);
        }

        [TestMethod]
        public void HeapSoTest2()
        {
            int[] array = new int[] { 142, 72, 12, 50, 19 };
            int n = array.Length;
            int[] expected = new int[] { 12, 19, 50, 72, 142 };

            Class1.heapSort(array, n);
            CollectionAssert.AreEqual(expected, array);
        }

        [TestMethod]
        public void HeapSoTest3()
        {
            int[] array = new int[] { 368, 556, 741, 273, 410, 974 };
            int n = array.Length;
            int[] expected = new int[] { 273, 368, 410, 556, 741, 974 };

            Class1.heapSort(array, n);
            CollectionAssert.AreEqual(expected, array);
        }

        //PriotyQueueWithHeapTest
        [TestMethod]
        public void PriotyQueueWithHeapTest1()
        {
            int[] arr = new int[] { 5, 2, 7, 6, 1,  };
            Class1.insert(7);
            Class1.insert(6);
            Class1.insert(5);
            Class1.insert(2);
            Class1.insert(1);
            int expected = Class1.extractMax();
            Assert.AreEqual(7, expected);
        }

        [TestMethod]
        public void PriotyQueueWithHeapTest2()
        {
            int[] arr = new int[] { 13, 27, 82, 74, 43 };
            Class1.insert(82);
            Class1.insert(74);
            Class1.insert(43);
            Class1.insert(27);
            Class1.insert(13);
            int expected = Class1.extractMax();
            Assert.AreEqual(82, expected);
        }

        [TestMethod]
        public void PriotyQueueWithHeapTest3()
        {
            int[] arr = new int[] { 934, 512, 314, 183, 821 };
            Class1.insert(934);
            Class1.insert(821);
            Class1.insert(512);
            Class1.insert(314);
            Class1.insert(183);
            int expected = Class1.extractMax();
            Assert.AreEqual(934, expected);
        }


        //CountingSoTest
        [TestMethod]
        public void CountingSoTest1()
        {
            int[] array = new int[] { 5, 0, 6, 8, 3, 1 };
            int n = array.Length;
            int[] expected = new int[] { 0, 1, 3, 5, 6, 8 };

            Class1.CountingSort(array);
            CollectionAssert.AreEqual(expected, array);
        }

        [TestMethod]
        public void CountingSoTest2()
        {
            int[] array = { 46, 21, 14, 62, 97, 82 };
            int n = array.Length;
            int[] expected = new int[] { 14, 21, 46, 62, 82, 97 };

            Class1.CountingSort(array);
            CollectionAssert.AreEqual(expected, array);
        }

        [TestMethod]
        public void CountingSoTest3()
        {
            int[] array =  { 2, 8, 5, 1, 9, 0, 4 };
            int n = array.Length;
            int[] expected = { 0, 1, 2, 4, 5, 8, 9 };

            Class1.CountingSort(array);
            CollectionAssert.AreEqual(expected, array);
        }

        //RadixSoTest
        [TestMethod]
        public void RadixSoTest1()
        {
            int[] array = { 3, 5, 7, 6, 2, 1, 0 };
            int n = array.Length;
            int[] expected = { 0, 1, 2, 3, 5, 6, 7 };

            Class1.radixsort(array, n);
            CollectionAssert.AreEqual(expected, array);

        }

        [TestMethod]
        public void RadixSoTest2()
        {
            int[] array = { 15, 32, 58, 92, 81, 29 };
            int n = array.Length;
            int[] expected = { 15, 29, 32, 58, 81, 92 };

            Class1.radixsort(array, n);
            CollectionAssert.AreEqual(expected, array);
        }

        [TestMethod]
        public void RadixSoTest3()
        {
            int[] array = { 412, 914, 178, 713, 283 };
            int n = array.Length;
            int[] expected = { 178, 283, 412, 713, 914 };

            Class1.radixsort(array, n);
            CollectionAssert.AreEqual(expected, array);
        }


    }
}
