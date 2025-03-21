using System;
using System.Linq;
using System.Collections.Generic;
using Application_Manager.States;

namespace Application_Manager.Improved_Game_Manager.Runtime.Editor {
    public static class ReflectionHelper {
        public static List<Type> GetConcreteStates() {
            // Get all loaded assemblies. You might filter to a specific assembly if needed.
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => typeof(BaseState).IsAssignableFrom(type) && !type.IsAbstract)
                .ToList();
        }

        public static List<string> GetConcreteStateNames() {
            return GetConcreteStates().Select(t => t.Name).ToList();
        }
    }
}