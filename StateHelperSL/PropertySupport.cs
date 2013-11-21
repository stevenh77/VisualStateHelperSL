using System;
using System.Linq.Expressions;
using System.Reflection;

namespace StateHelperSL
{
    public static class PropertySupport
    {
        public static string ExtractPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
            {
                throw new ArgumentNullException("propertyExpression");
            }
            var memberExpression = propertyExpression.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new ArgumentException("NotMemberAccessExpression");
            }
            var property = memberExpression.Member as PropertyInfo;
            if (property == null)
            {
                throw new ArgumentException("ExpressionNotProperty");
            }
            var getMethod = property.GetGetMethod(true);
            if (getMethod.IsStatic)
            {
                throw new ArgumentException("StaticExpression");
            }
            return memberExpression.Member.Name;
        }
    }
}