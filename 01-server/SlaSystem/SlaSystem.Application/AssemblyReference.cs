using System.Reflection;

namespace SlaSystem.Application;

public class AssemblyReference
{
    public static Assembly Assembly => typeof(AssemblyReference).Assembly;
}