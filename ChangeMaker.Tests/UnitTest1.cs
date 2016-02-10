using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChangeMaker.Models;

namespace ChangeMaker.Tests.Models
{
    [TestClass]
    public class TransactionTest
    {
        [TestMethod]
        public void TestCalcChange()
        {
            // Arrange
            Transaction transaction = new Transaction();

            // Act

            transaction.setAmountTendered(10, 0);
            transaction.setPurchasePrice(1, 25);

            //int[] result = transaction.calcChange(125, 1000, 0);
            int[] result = transaction.calcChange();
            int[] expected = { 0, 0, 1, 3, 3, 0, 0, 0 };


            
            // Assert
            CollectionAssert.AreEqual(expected, result);



        }

        [TestMethod]
        public void TestCalcChange2()
        {
            //Arrange
            Transaction transaction2 = new Transaction();

            //Act

            transaction2.setPurchasePrice(0, 1);
            transaction2.setAmountTendered(25, 0);
            //int[] result = transaction2.calcChange(1, 2500, 0);
            int[] result = transaction2.calcChange();
            int[] expected = { 1, 0, 0, 4, 3, 2, 0, 4 };

            //Assert
            CollectionAssert.AreEqual(expected, result);



        }


        
    }
}
