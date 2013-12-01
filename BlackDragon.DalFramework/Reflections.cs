using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;

namespace BlackDragon.DalFramework
{
    public static class Reflections
    {
        /// <summary>
        /// Set value when value is not null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TPropertyType"></typeparam>
        /// <param name="item"></param>
        /// <param name="expr"></param>
        /// <param name="value"></param>
        public static void SetIfNotNull<T, TPropertyType>(this T item,
            Expression<Func<T, TPropertyType?>> expr, TPropertyType? value)
            where TPropertyType : struct
        {
            if (value.HasValue)
                item.SetProperty(expr, value);
        }

        /// <summary>
        /// Set target property
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        public static void SetProperty<T>(this T item, string propertyName, object value)
        {
            typeof(T).GetProperty(propertyName).SetValue(item, value, null);
        }

        /// <summary>
        /// Set target property
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TPropertyType"></typeparam>
        /// <param name="item"></param>
        /// <param name="expr"></param>
        /// <param name="value"></param>
        public static void SetProperty<T, TPropertyType>(this T item,
            Expression<Func<T, TPropertyType>> expr, TPropertyType value)
        {
            SetProperty(item, expr.PropertyName(), value);
        }

        /// <summary>
        /// Get property name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TPropertyType"></typeparam>
        /// <param name="expr"></param>
        /// <returns></returns>
        public static string PropertyName<T, TPropertyType>(this Expression<Func<T, TPropertyType>> expr)
        {
            return FindPropertyName(expr);
        }

        /// <summary>
        /// Get property name
        /// </summary>
        /// <param name="lambdaExpression"></param>
        /// <returns></returns>
        public static string FindPropertyName(LambdaExpression lambdaExpression)
        {
            var property = FindProperty(lambdaExpression);
            return property == null ? string.Empty : property.Name;
        }

        /// <summary>
        /// Get property from expression
        /// </summary>
        /// <param name="lambdaExpression"></param>
        /// <returns></returns>
        public static PropertyInfo FindProperty(this LambdaExpression lambdaExpression)
        {
            Expression expressionToCheck = lambdaExpression;

            bool done = false;

            while (!done)
            {
                switch (expressionToCheck.NodeType)
                {
                    case ExpressionType.Convert:
                        expressionToCheck = ((UnaryExpression)expressionToCheck).Operand;
                        break;
                    case ExpressionType.Lambda:
                        expressionToCheck = lambdaExpression.Body;
                        break;
                    case ExpressionType.MemberAccess:
                        var propertyInfo = ((MemberExpression)expressionToCheck).Member as PropertyInfo;
                        return propertyInfo;
                    default:
                        done = true;
                        break;
                }
            }

            return null;
        }

        /// <summary>
        /// Get method info from an expression
        /// </summary>
        /// <param name="lambdaExpression"></param>
        /// <returns></returns>
        public static MethodInfo FindMethod(LambdaExpression lambdaExpression)
        {
            Expression expressionToCheck = lambdaExpression;

            bool done = false;

            while (!done)
            {
                switch (expressionToCheck.NodeType)
                {
                    case ExpressionType.Convert:
                        expressionToCheck = ((UnaryExpression)expressionToCheck).Operand;
                        break;
                    case ExpressionType.Lambda:
                        expressionToCheck = lambdaExpression.Body;
                        break;
                    case ExpressionType.Call:
                        return ((MethodCallExpression)expressionToCheck).Method;
                    default:
                        done = true;
                        break;
                }
            }

            return null;
        }

        /// <summary>
        /// Get member type
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public static Type GetMemberType(this MemberInfo memberInfo)
        {
            var methodInfo = memberInfo as MethodInfo;

            if (methodInfo != null)
                return methodInfo.ReturnType;

            var propertyInfo = memberInfo as PropertyInfo;

            if (propertyInfo != null)
                return propertyInfo.PropertyType;

            var fieldInfo = memberInfo as FieldInfo;

            if (fieldInfo != null)
                return fieldInfo.FieldType;

            return null;
        }
    }
}
