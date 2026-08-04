using System;
using System.Collections.Generic;
using System.Text;

namespace Soundfree
{
    public class Audio
    {

        public string Nome { get; set; }

        public string Caminho { get; set; }

        public TimeSpan Duracao { get; set; }

        public Audio(string nome, string caminho)
        {
            Nome = nome;
            Caminho = caminho;
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
