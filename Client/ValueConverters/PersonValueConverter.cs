namespace Gajda.NovemberTests.Client.ValueConverters
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    using Gajda.NovemberTests.Client.Extensions;
    using Gajda.NovemberTests.Client.Models;

    [ValueConversion(typeof(Person), typeof(string))]
    public sealed class PersonValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var person = value as Person;

            if (person != null)
            {
                var list = new List<string> { person.FirstName, person.LastName };

                if (!string.IsNullOrEmpty(person.MiddleName))
                {
                    list.Insert(1, person.MiddleName);
                }

                return string.Format("{0} ({1})", string.Join(" ", list), person.DateOfBirth.YearsBetweenNow());
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}