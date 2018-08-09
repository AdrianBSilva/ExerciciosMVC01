using Exercicio01.DataBase;
using Exercicio01.Models.Repositorio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Exercicio01.Respositorio
{
    public class EscolaRepositorio
    {
        public List<Nota> ObterTodos()
        {
            List<Nota> notas = new List<Nota>();
            SqlCommand command = new BancoDados().ObterConexao();
            command.CommandText = "SELECT id,  nome, matricula, nota01, nota02, nota03, frequencia, faltas FROM escola";
            DataTable tabela = new DataTable();
            tabela.Load(command.ExecuteReader());
            foreach (DataRow linha in tabela.Rows)
            {
                Nota nota = new Nota()
                {
                    Id = Convert.ToInt32(linha[0].ToString()),
                    Nome = linha[1].ToString(),
                    CodrigoDaMaricula = linha[2].ToString(),
                    Nota1 = Convert.ToDouble(linha[3].ToString()),
                    Nota2 = Convert.ToDouble(linha[4].ToString()),
                    Nota3 = Convert.ToDouble(linha[5].ToString()),
                    Frequencia = Convert.ToByte(linha[6].ToString()),
                    Faltas = Convert.ToByte(linha[7].ToString())
                };
                notas.Add(nota);
            }
            return notas;
        }

        public int Cadastrar(Nota nota)
        {
            SqlCommand command = new BancoDados().ObterConexao();
            command.CommandText = "INSERT INTO escola (nome, matricula, nota01, nota02, nota03, frequencia, faltas) OUTPUT INSERTED.ID VALUES(@NOME, @MATRICULA, @NOTA01, @NOTA02, @NOTA03, @FREQUENCIA, @FALTAS)";
            command.Parameters.AddWithValue("@NOME", nota.Nome);
            command.Parameters.AddWithValue("@MATRICULA", nota.CodrigoDaMaricula);
            command.Parameters.AddWithValue("@NOTA01", nota.Nota1);
            command.Parameters.AddWithValue("@NOTA02", nota.Nota2);
            command.Parameters.AddWithValue("@NOTA03", nota.Nota3);
            command.Parameters.AddWithValue("@FREQUENCIA", nota.Frequencia);
            command.Parameters.AddWithValue("@FALTAS", nota.Faltas);
            int id = Convert.ToInt32(command.ExecuteScalar().ToString());
            return id;
        }

        public bool Alterar(Nota nota)
        {
            SqlCommand command = new BancoDados().ObterConexao();
            command.CommandText = "UPDATE escola SET nome = @NOME, matricula = @MATRICULA, nota01 = @NOTA01, nota02 = @NOTA02, nota03 = @NOTA03, frequencia = @FREQUENCIA, faltas = @FALTAS WHERE id = @ID";
            command.Parameters.AddWithValue("@NOME", nota.Nome);
            command.Parameters.AddWithValue("@MATRICULA", nota.CodrigoDaMaricula);
            command.Parameters.AddWithValue("@NOTA01", nota.Nota1);
            command.Parameters.AddWithValue("@NOTA02", nota.Nota2);
            command.Parameters.AddWithValue("@NOTA03", nota.Nota3);
            command.Parameters.AddWithValue("@FREQUENCIA", nota.Frequencia);
            command.Parameters.AddWithValue("@FALTAS", nota.Faltas);
            command.Parameters.AddWithValue("@ID", nota.Id);
            return command.ExecuteNonQuery() == 1;
        }

        public bool Excluir(int id)
        {
            SqlCommand command = new BancoDados().ObterConexao();
            command.CommandText = "DELETE FROM escola WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            return command.ExecuteNonQuery() == 1;


        }

        public Nota ObterPeloId(int id)
        {

            Nota nota = null;
            SqlCommand command = new BancoDados().ObterConexao();
            command.CommandText = "SELECT nome, matricula, nota01, nota02, nota03, frequencia, faltas FROM escola WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            DataTable tabela = new DataTable();
            tabela.Load(command.ExecuteReader());
            if (tabela.Rows.Count == 1)
            {
                nota = new Nota();
                nota.Id = id;
                nota.Nome = tabela.Rows[0][0].ToString();
                nota.CodrigoDaMaricula = tabela.Rows[0][2].ToString();
                nota.Nota1 = Convert.ToDouble(tabela.Rows[0][3].ToString());
                nota.Nota2 = Convert.ToDouble(tabela.Rows[0][4].ToString());
                nota.Nota3 = Convert.ToDouble(tabela.Rows[0][5].ToString());
                nota.Frequencia = Convert.ToByte(tabela.Rows[0][6].ToString());
                nota.Faltas = Convert.ToByte(tabela.Rows[0][7].ToString());
            }
            return nota;
        }
    }


}