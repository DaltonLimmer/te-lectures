using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestableClasses.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestableClasses.Classes.Tests
{
    [TestClass()]
    public class StringExercisesTests
    {
        //Assert
        //.AreEqual() - compares expected and actual value for equality
        //.AreSame() - verifies two object variables refer to same object
        //.AreNotSame() - verifies two object variables refer to different objects
        //.Fail() - fails without checking conditions
        //.IsFalse()
        //.IsTrue()
        //.IsNotNull()
        //.IsNull()

        StringExercises _exercises = new StringExercises();

        //[UnitOfWork__StateUnderTest__ExpectedBehavior]
        //Public void Sum_NegativeNumberAs1stParam_ExceptionThrown()

        public void MakeAbba2()
        {
            

        }

        [TestMethod]
        public void MakeAbba()
        {
            string result = _exercises.MakeAbba("atta", "boy");
            Assert.AreEqual("attaboyboyatta", result, "Input: MakeAbba(\"atta\",\"boy\")");

            result = _exercises.MakeAbba("a tta", "b oy");
            Assert.AreEqual("a ttab oyb oya tta", result, "Input: MakeAbba(\"a tta\",\"b oy\")");

            try
            {
                result = _exercises.MakeAbba("a", "b");
                //Assert.Fail("Input: MakeAbba(null, null)");
            }
            catch (Exception)
            {
            }            
        }
    }
}