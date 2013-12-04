using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlackDragon.Shared;

namespace BlackDragon
{
    public static class Asserts
    {
        public static AssertHelper<T, TProperty> Assert<T, TProperty>(this T obj,
            Expression<Func<T, TProperty>> property)
        {
            return new AssertHelper<T, TProperty>(obj, property);
        }

        public static void IsNotNullOrWhiteSpace<T>(this AssertHelper<T, string> helper)
        {
            helper.IsTrue(x => !string.IsNullOrWhiteSpace(x), 
                "Is not null or white space");
        }
        public static void IsTrue<T>(this AssertHelper<T, bool> a)
        {
            a.AreEquals(true);
        }

        public static void HasAnyItem<T, TItem>(this AssertHelper<T, ICollection<TItem>> a,
            Func<TItem, bool> predicate)
        {
            a.IsTrue(x => x != null && x.Any(predicate), "HasAnyItem");
        }

        public static void HasAnyItem<T, TItem>(this AssertHelper<T, ICollection<TItem>> a)
        {
            a.IsTrue(x => x != null && x.Any(), "HasAnyItem");
        }

        public static void IsFalse<T>(this AssertHelper<T, bool> a)
        {
            a.AreEquals(false);
        }

        public static void MoreThanZero<T>(this AssertHelper<T, decimal> a)
        {
            a.IsTrue(x => x > 0, "MoreThanZero");
        }

        public static void IsBetween<T>(this AssertHelper<T, decimal> a, decimal minValue, decimal maxValue)
        {
            a.IsTrue(x => x > 0, string.Format("Between({0},{1})", minValue, maxValue));
        }
    }

    public class AssertHelper<T, TProperty>
    {
        private T obj;
        private Expression<Func<T, TProperty>> property;
        private string propertyName;

        public AssertHelper(T obj, Expression<Func<T, TProperty>> property)
        {
            this.obj = obj;
            this.property = property;
            this.propertyName = property.PropertyName();
        }

        public void IsTrue(Func<TProperty, bool> predicate, string assertName)
        {
            var actual = property.Compile()(obj);

            Assert.IsTrue(predicate(actual), "Assert.{1} failed. Property {0}", propertyName, assertName);

            Trace.WriteLine(string.Format("Assert.{1} succeeded. Type:{2}, Property:{0}",
                propertyName, assertName, typeof(T).Name));
        }

        public void AreNotEquals(TProperty notExpected)
        {
            var actual = property.Compile()(obj);

            Assert.AreNotEqual<TProperty>(notExpected, actual,
                "Assert.AreNotEqual failed. Property {0} NotExpected:<{1}> . Actual:<{2}>.",
            propertyName, notExpected, actual);

            Trace.WriteLine(string.Format("Assert.AreNotEqual succeeded. Property {0} NotExpected:<{1}> . Actual:<{2}>.",
                propertyName, notExpected, actual));
        }

        public void AreEquals(TProperty expected)
        {
            var actual = property.Compile()(obj);

            Assert.AreEqual<TProperty>(expected, actual,
            "Assert.AreEquals failed. Property {0} Expected:<{1}> . Actual:<{2}>.",
            propertyName, expected, actual);

            Trace.WriteLine(string.Format("Assert.AreEquals succeeded. Property {0} Expected:<{1}> . Actual:<{2}>.",
                propertyName, expected, actual));
        }
    }
}
