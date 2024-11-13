using System;
using System.Linq;
using Xunit;

namespace LAB1.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test_EmptyFile_ShouldThrowException()
        {
            // Імітувати порожній файл (без рядків)
            string[] lines = Array.Empty<string>();

            var ex = Record.Exception(() => Program.ValidateInput(lines));
            Assert.NotNull(ex);
            Assert.IsType<InvalidOperationException>(ex);
            Assert.Equal("The input file must contain exactly one line.", ex.Message);
        }

        [Fact]
        public void Test_FileWithMultipleLines_ShouldThrowException()
        {
            // Імітувати файл з кількома рядками
            string[] lines = { "line1", "line2" };

            var ex = Record.Exception(() => Program.ValidateInput(lines));
            Assert.NotNull(ex);
            Assert.IsType<InvalidOperationException>(ex);
            Assert.Equal("The input file must contain exactly one line.", ex.Message);
        }

        [Fact]
        public void Test_InputLineExceeds8Characters_ShouldThrowException()
        {
            // Рядок довжиною більше 8 символів
            string[] lines = { "123456789" };

            var ex = Record.Exception(() => Program.ValidateInput(lines));
            Assert.NotNull(ex);
            Assert.IsType<InvalidOperationException>(ex);
            Assert.Equal("The input string length must be between 1 and 8 characters.", ex.Message);
        }

        [Fact]
        public void Test_InputLineWithSpecialCharacters_ShouldThrowException()
        {
            // Рядок зі спеціальними символами (які є недійсними)
            string[] lines = { "abc!@#$" };

            var ex = Record.Exception(() => Program.ValidateInput(lines));
            Assert.NotNull(ex);
            Assert.IsType<InvalidOperationException>(ex);
            Assert.Equal("The input string must only contain English letters and digits.", ex.Message);
        }

        [Fact]
        public void Test_ValidInput_NumbersOnly_ShouldPass()
        {
            // Коректне введення лише з числами
            string[] lines = { "123" };

            var ex = Record.Exception(() => Program.ValidateInput(lines));
            Assert.Null(ex); // Для коректного введення не повинно бути винятків

            // Перевірка обробки введених даних
            string result = Program.SolveProblem(lines[0]);
            string[] expected = { "123", "132", "213", "231", "312", "321" };

            // Розбити і результат, і очікуване на масиви перестановок
            string[] resultArray = result.Replace("\r\n", "\n").Trim().Split('\n');

            // Відсортувати обидва масиви та порівняти
            Assert.Equal(expected.OrderBy(x => x), resultArray.OrderBy(x => x));
        }

        [Fact]
        public void Test_ValidInput_CharactersOnly_ShouldPass()
        {
            // Коректне введення лише з літерами
            string[] lines = { "abc" };

            var ex = Record.Exception(() => Program.ValidateInput(lines));
            Assert.Null(ex); // Для коректного введення не повинно бути винятків

            // Перевірка обробки введених даних
            string result = Program.SolveProblem(lines[0]);
            string[] expected = { "abc", "acb", "bac", "bca", "cab", "cba" };

            // Розбити і результат, і очікуване на масиви перестановок
            string[] resultArray = result.Replace("\r\n", "\n").Trim().Split('\n');

            // Відсортувати обидва масиви та порівняти
            Assert.Equal(expected.OrderBy(x => x), resultArray.OrderBy(x => x));
        }

        [Fact]
        public void Test_ValidInput_NumbersAndCharacters_ShouldPass()
        {
            // Коректне введення з числами та літерами
            string[] lines = { "a1b2" };

            var ex = Record.Exception(() => Program.ValidateInput(lines));
            Assert.Null(ex); // Для коректного введення не повинно бути винятків

            // Перевірка обробки введених даних
            string result = Program.SolveProblem(lines[0]);

            // Очікувані варіанти перестановок (оскільки порядок може змінюватись)
            string[] expected = {
                "a1b2", "a12b", "ab12", "ab21", "a2b1", "a21b",
                "1ab2", "1a2b", "1ba2", "1b2a", "12ab", "12ba",
                "ba12", "ba21", "b1a2", "b12a", "b2a1", "b21a",
                "2ab1", "2a1b", "2ba1", "2b1a", "21ab", "21ba"
            };

            // Розбити і результат, і очікуване на масиви перестановок
            string[] resultArray = result.Replace("\r\n", "\n").Trim().Split('\n');

            // Відсортувати обидва масиви та порівняти
            Assert.Equal(expected.OrderBy(x => x), resultArray.OrderBy(x => x));
        }
    }
}
