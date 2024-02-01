namespace Tester;

public class BMI
{
    public static double Calculate(double weight, double height)
    {
        return weight / (height * height);
    }
}

public class ArrayLargestAndSmallest
{
    public static int[] Find(int[] numbers)
    {
        if (numbers.Length == 0)
        {
            throw new ArgumentException("Numbers cannot be empty");
        }

        int smallest = numbers[0];
        int largest = numbers[0];

        foreach (int number in numbers)
        {
            if (number < smallest)
            {
                smallest = number;
            }

            if (number > largest)
            {
                largest = number;
            }
        }

        return [smallest, largest];
    }
}

public class PrintFile
{
    public static string GetContent(string fileName)
    {
        //return "";
        return System.IO.File.ReadAllText(fileName);
    }
}

public class UnitTest1
{
    [Fact]
    public void BMI_Test()
    {
        double weight = 10.0;
        double height = 20.0;

        double result = BMI.Calculate(weight, height);

        Assert.Equal(0.025, result);
    }

    [Fact]
    public void ArraySL_Test_Normal()
    {
        int[] numbers = [1, 2, 3, 4, 5, 6];
        int[] result = ArrayLargestAndSmallest.Find(numbers);

        Assert.Equal(1, result[0]);
        Assert.Equal(6, result[1]);

        numbers = [3, 3, 5];
        result = ArrayLargestAndSmallest.Find(numbers);

        Assert.Equal(3, result[0]);
        Assert.Equal(5, result[1]);

        numbers = [5000, 7000, 4000];
        result = ArrayLargestAndSmallest.Find(numbers);

        Assert.Equal(4000, result[0]);
        Assert.Equal(7000, result[1]);
    }

    [Fact]
    public void ArraySL_Test_EmptyArray()
    {
        int[] numbers = [];
        Assert.Throws<ArgumentException>(() => ArrayLargestAndSmallest.Find(numbers));
    }

    [Fact]
    public void ArraySL_Test_SingleNumber()
    {
        int[] numbers = [1];
        int[] result = ArrayLargestAndSmallest.Find(numbers);

        Assert.Equal(1, result[0]);
        Assert.Equal(1, result[1]);

        numbers = [3];
        result = ArrayLargestAndSmallest.Find(numbers);

        Assert.Equal(3, result[0]);
        Assert.Equal(3, result[1]);

        numbers = [5000];
        result = ArrayLargestAndSmallest.Find(numbers);

        Assert.Equal(5000, result[0]);
        Assert.Equal(5000, result[1]);
    }

    [Fact]
    public void ArraySL_Test_Negative()
    {
        int[] numbers = [-4, -6, -8];
        int[] result = ArrayLargestAndSmallest.Find(numbers);

        Assert.Equal(-8, result[0]);
        Assert.Equal(-4, result[1]);

        numbers = [-30, -5, 8];
        result = ArrayLargestAndSmallest.Find(numbers);

        Assert.Equal(-30, result[0]);
        Assert.Equal(8, result[1]);

        numbers = [-4000, -2000, 4000, 7000];
        result = ArrayLargestAndSmallest.Find(numbers);

        Assert.Equal(-4000, result[0]);
        Assert.Equal(7000, result[1]);
    }

    [Fact]
    public void File_Test()
    {
        string result = PrintFile.GetContent("../../../test1.txt");

        Assert.Equal("Hej", result);
    }

    [Fact]
    public void File_Test2()
    {
        File.WriteAllText("../../../test2.txt", "Blabla");
        string result = PrintFile.GetContent("../../../test2.txt");

        Assert.Equal("Blabla", result);
    }
}
