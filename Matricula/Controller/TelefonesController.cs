﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
//Imports projeto
using Matricula.Model;
using System.Data;

namespace Matricula.Controller
{
    class TelefonesController
    {
        private SqlConnection conn = new Conexao().Conn;

        public void inserirFixo(string telefone, int matriculaId)
        {
            try
            {
                string insertFixo = "INSERT INTO Fixos (telefone, codMatricula) VALUES (@telefone, @codMatricula)";

                SqlCommand cmdInsertFixo = new SqlCommand(insertFixo, conn);
                cmdInsertFixo.Parameters.AddWithValue("@telefone", telefone);
                cmdInsertFixo.Parameters.AddWithValue("@codMatricula", matriculaId);

                conn.Open();
                cmdInsertFixo.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("SQL Error: " + sqlEx);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
            finally
            {
                try
                {
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
            }
        }

        public void inserirCelular(string telefone, int matriculaId)
        {
            try
            {
                string insertCelular = "INSERT INTO Celulares (celular, codMatricula) VALUES (@celular, @codMatricula)";

                SqlCommand cmdInsertFixo = new SqlCommand(insertCelular, conn);
                cmdInsertFixo.Parameters.AddWithValue("@celular", telefone);
                cmdInsertFixo.Parameters.AddWithValue("@codMatricula", matriculaId);

                conn.Open();
                cmdInsertFixo.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("SQL Error: " + sqlEx);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
            finally
            {
                try
                {
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
            }
        }

        public DataSet pesquisarTelefone(int codigo)
        {
            DataSet dt = new DataSet();
            try
            {
                string select = "SELECT telefone FROM Fixos WHERE codMatricula=@cod";

                SqlCommand pes = new SqlCommand(select, conn);
                pes.Parameters.AddWithValue("@cod", codigo);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(pes);
                da.Fill(dt);
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("SQL Erro: " + sqlEx);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public DataSet pesquisarCelular(int codigo)
        {
            DataSet dt = new DataSet();
            try
            {
                string select = "SELECT celular FROM Celulares WHERE codMatricula=@cod";

                SqlCommand pes = new SqlCommand(select, conn);
                pes.Parameters.AddWithValue("@cod", codigo);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(pes);
                da.Fill(dt);
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("SQL Erro: " + sqlEx);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
    }
}
