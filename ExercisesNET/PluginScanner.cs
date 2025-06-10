using Exercises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesNET
{
    internal class PluginScanner
    {
        public void ScanAndUse()
        {
            var files = Directory.GetFiles(".","*.dll");

            foreach (var file in files) {

                try
                {
                    var assembly = Assembly
                        .LoadFile(Path.Combine(Directory.GetCurrentDirectory(), file));

                    var pluginMatchingTypes = assembly.DefinedTypes
                        .Where(t => t.ImplementedInterfaces.Any(x => x.FullName == typeof(IPlugin).FullName)
                                && t.IsClass && !t.IsAbstract);

                    foreach (var type in pluginMatchingTypes)
                    {
                        if (type.DeclaredConstructors.Any(c => c.GetParameters().Count() == 0))
                        { 
                            var pluginInstance = assembly.CreateInstance(type.FullName) as IPlugin;

                            var result = pluginInstance.GetText();

                            Console.WriteLine(result);
                        }
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            //skanuj dllki szukając klas implemementującej IPluging
            //Utwórz instancje tych klas i wywołaj metodę GetText()
        }
    }
}
