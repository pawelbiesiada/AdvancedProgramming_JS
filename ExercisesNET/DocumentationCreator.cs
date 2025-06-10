using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesNET
{
    internal class DocumentationCreator
    {
        public void Generate(string assemblyFile)
        {
            var assembly = Assembly.LoadFrom(assemblyFile);

            var classes = assembly.DefinedTypes.Where(x => x.IsPublic == true);

            foreach (var type in classes)
            {
                Console.WriteLine($"Klasa: {type.Name}");

                foreach (var item in type.GetMethods().Where(m => m.IsPublic && !m.IsStatic))
                {
                    Console.WriteLine($"\tMetoda: {item.ReturnType.Name} {item.Name}");
                }
                foreach (var prop in type.GetProperties())
                {
                    var attr = prop.GetCustomAttribute<ObsoleteAttribute>();
                    var obsoleteString = attr != null ? "is obsolete - don't use it anymore" : "";
                    

                    Console.WriteLine($"\tProperty: {prop.PropertyType.Name} {prop.Name} {obsoleteString}" );}
                Console.WriteLine();
            }

        }

        // nazwa klasy
            //metody
                //-
                //-
            //właściwości
                //- 
                //-

    }
}
