﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercicio01.Models.Repositorio
{
    public class Notas
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome nao pode ser vasio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Código da matricula não pode ser vsio")]
        public string CodrigoDaMaricula { get; set; }

        [Required(ErrorMessage = "Nota 1 não pode ser vsio")]
        [Range(0, 10, ErrorMessage = "A nota 1 tem q ser entre 0 e 10")]
        public double Nota1 { get; set; }

        [Required(ErrorMessage = "Nota 2 não pode ser vsio")]
        [Range(0, 10, ErrorMessage = "A nota 2 tem q ser entre 0 e 10")]
        public double Nota2 { get; set; }

        [Required(ErrorMessage = "Nota 3 não pode ser vsio")]
        [Range(0, 10, ErrorMessage = "A nota 3 tem q ser entre 0 e 10")]
        public double Nota3 { get; set; }

        [Required(ErrorMessage = "frequencia nao pode ser vasia")]
        [Range(0, 100, ErrorMessage = "A frequência tem q ser entre 0 e 100")]
        public byte Frequencia { get; set; }

        [Required(ErrorMessage="Fasltas deve ser preenchida")]
        [Range(0, 50, ErrorMessage="")]

    }
}