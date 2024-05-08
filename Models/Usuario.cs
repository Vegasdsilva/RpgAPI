using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace RpgApi.Models.Enuns
{
    public class Usuario
    {
        //prop atalho para criação

        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public byte[]? PasswordHash { get; set; }

        public byte[]? PasswordSalt { get; set; }

        public byte[]? Foto { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude  { get; set; }

        public DateTime? DataAcesso { get; set; }

        [NotMapped] //using System.ComponentModel.DataAnnotations.Schema

        public string PasswordString { get; set; } = string.Empty;

        public List<Personagem> personagens { get; set; } = new List<Personagem>();

        public string Perfil { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}