namespace DesignPatternsDemo.Kernel;

public interface ICustomMapper<in TFrom, out TTo>
{
    TTo Map(TFrom from);
}