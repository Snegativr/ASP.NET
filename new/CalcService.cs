// CalcService.cs
using Microsoft.AspNetCore.Mvc;

public class CalcService
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Subtract(int a, int b)
    {
        return a - b;
    }
    public int Multiplication(int a, int b)
    {
        return a * b;
    }
    public int Divide(int a, int b) 
    {  
        return a / b; 
    }
}

public class CalculatorController
{
    private CalcService calcService;

    public CalculatorController(CalcService calcService)
    {
        this.calcService = calcService;
    }

    public int Add(int a, int b)
    {
        return calcService.Add(a, b);
    }

    public int Subtract(int a, int b)
    {
        return calcService.Subtract(a, b);
    }
    public int Multiplication(int a, int b)
    {
        return calcService.Multiplication(a, b);
    }
    public int Divide(int a, int b)
    {
        return calcService.Divide(a, b);
    }
}
