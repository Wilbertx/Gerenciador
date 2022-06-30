using System;
using System.Linq;
using System.Collections.Generic;
using Models;
using System.Text.RegularExpressions;


namespace Controllers
{
    public class UsuarioController
    {
        public static Usuario IncluirUsuario(string Nome, string Email, string Senha)
        {
            Regex validateEmailRegex = new Regex("^\\S+@\\S+\\.\\S+$");

            if(String.IsNullOrEmpty(Nome))
            {
                throw new Exception("Nome inválido");
            }

            if(!validateEmailRegex.IsMatch(Email))
            {
                throw new Exception("Email inválido");
            }

            if (String.IsNullOrEmpty(Senha) || Senha.Length < 8)
            {
                throw new Exception("Senha inválida");
            }
            else
            {
                Senha = BCrypt.Net.BCrypt.HashPassword(Senha);
            }

            return new Usuario(Nome, Email, Senha);
        }

        public static Usuario AlterarUsuario(int Id, string Nome, string Email, string Senha)
        {
            Regex validateEmailRegex = new Regex("^\\S+@\\S+\\.\\S+$");
            Usuario usuario = GetUsuario(Id);

            if(!String.IsNullOrEmpty(Nome))
            {
                Nome = Nome;
            }

            if (validateEmailRegex.IsMatch(Email))
            {
                Email = Email;
            }
            else
            {
                throw new Exception("Email inválido");
            }

            if(!String.IsNullOrEmpty(Senha) && !BCrypt.Net.BCrypt.Equals(Senha, usuario.Senha))
            {
                if (String.IsNullOrEmpty(Senha) || Senha.Length < 8)
                {
                    throw new Exception("Senha inválida");
                }
                else
                {
                    Senha = BCrypt.Net.BCrypt.HashPassword(Senha);
                    usuario.Senha = Senha;
                }
            }
            else
            {
                throw new Exception("Senha inválida");
            }

            Usuario.AlterarUsuario(Id, Nome, Email, Senha);

            return usuario;
        }

        public static Usuario RemoverUsuario(int Id)
        {
            Usuario usuario = GetUsuario(Id);
            Usuario.RemoverUsuario(usuario);
            return usuario;
        }

        public static Usuario GetUsuario(int Id)
        {
            Usuario usuario = (
                from Usuario in Usuario.GetUsuarios()
                    where Usuario.Id == Id
                    select Usuario
            ).First();

            if(usuario == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            return usuario;
        }

        public static IEnumerable<Usuario> VisualizarUsuario()
        {
            return Usuario.GetUsuarios();
        }

        public static void Auth(string Email, string Senha)
        {
            Usuario.Auth(Email, Senha);
        }
    }
}