namespace Gajda.NovemberTests.Client.Models
{
    using System;
    using System.Collections.Generic;

    using Gajda.NovemberTests.Client.Extensions;

    public sealed class Person : BaseModel
    {
        private Guid id;

        private string firstName;

        private string middleName;

        private string lastName;

        private DateTime dateOfBirth;

        public Guid Id
        {
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
                this.OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                this.firstName = value;
                this.OnPropertyChanged();
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }
            set
            {
                this.middleName = value;
                this.OnPropertyChanged();
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
                this.OnPropertyChanged();
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return this.dateOfBirth;
            }
            set
            {
                this.dateOfBirth = value;
                this.OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            var list = new List<string> { this.FirstName, this.LastName };

            if (!string.IsNullOrEmpty(this.MiddleName))
            {
                list.Insert(1, this.MiddleName);
            }

            return string.Format("{0} ({1})", string.Join(" ", list), this.DateOfBirth.YearsBetweenNow());
        }
    }
}