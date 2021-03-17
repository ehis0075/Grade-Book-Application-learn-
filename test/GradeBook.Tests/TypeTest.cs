 using System;
using Xunit;

namespace GradeBook.Tests

{
    public class BookTest1
    {

        public void StringsBehaveLikeValueTypes()
        {
            string name = "alex";
            var upper = MakeUpperCase(name);

            Assert.Equal("ALEX", name);
            Assert.Equal("ALEX", upper);
        }

        private string MakeUpperCase(string p)
        {
           return p.ToUpper(); 
           
        }

        // return value types using pass by ref
        [Fact]
        public void Test1()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);


        }

        private void SetInt(ref int z)
        {
            z = 42;
        }

        private int GetInt()
        {
            return 3;
        }



         // pass by out
        [Fact]
        public void CanPassByOut()
        {
              
            var book1 = GetBook("Book 1");
            GetBookSetName( book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

            private void GetBookSetName(ref Book book, string name)
        {
            //book = new Book(name);

        }
        
        // pass by reference
        [Fact]
        public void CanPassByReference()
        {
              
            var book1 = GetBook("Book 1");
            GetBookSetName1(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }
          
            private void GetBookSetName1(ref Book book, string name)
        {
            book = new Book(name);

        }


        // pass by value
        [Fact]
        public void CanPassByValue()
        {
              
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

            private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);

        }


        [Fact]
        public void CanSetNameToReference()
        {
              
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

    
        [Fact]
        public void GetBookReturnsTheSameBoject()
        {
              
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);

        }


        [Fact]
        public void Two()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));


        }    
            Book GetBook(string name)
            {
                return new Book(name);
            }
               
    }
}
