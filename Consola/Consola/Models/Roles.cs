using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consola.Models
{
    public class Rol
    {
        public int Valor { get; set; }
        public string Name { get; set; }
        public static string GetName(int role)
        {
            string name = "";
            switch (role)
            {
                case 1:
                    name = "Administrador";
                    break;
                case 2:
                    name = "Veterinario";
                    break;
                case 3:
                    name = "Secretaria";
                    break;
                case 4:
                    name = "Asistente";
                    break;
            }
            return name;
        }

        public static List<Rol> GetRoles(IEnumerable<int> rolesIds)
        {
            List<Rol> roles = new List<Rol>();
            foreach (int rol in rolesIds)
                roles.Add(new Rol { Valor= rol, Name= GetName(rol)});
            return roles;
        }

        public static List<Rol> GetRoles()
        {
            List<Rol> roles = new List<Rol>();
            var rolesIds = new int[] { 1, 2, 3, 4 };
            foreach (int rol in rolesIds)
                roles.Add(new Rol { Valor = rol, Name = GetName(rol) });
            return roles;
        }
    }
}