using Api_Impressora_ADO.NET.Interfaces;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Reflection.PortableExecutable;

namespace Api_Impressora_ADO.NET.Models
{
    public class BmImpressora : IBmImpressora
    {
        private IDbConnection _connection;

        //private readonly string _connection;
        public BmImpressora()//IConfiguration configuration)
        {

            //_connection = new SqlConnection(@"DefaultConnection");
            _connection = new SqlConnection(Environment.GetEnvironmentVariable("DefaultConnection")); // Environment.GetEnvironmentVariable - Variavel de ambiente.
        }

        public List<ImpressoraModel> GetImpressoras()
        {
            List<ImpressoraModel> impressoras = new List<ImpressoraModel>();

            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * from impressora";
                cmd.Connection = (SqlConnection)_connection;

                _connection.Open();

                SqlDataReader dataReader = cmd.ExecuteReader(); //Execulta o CommandText e guarda resposta dentro de dataReader.

                while (dataReader.Read())
                {
                    ImpressoraModel model = new ImpressoraModel();
                    model.ImpressoraID = dataReader.GetInt32("ImpressoraID");
                    model.Nome = dataReader.GetString("Nome");
                    model.ModeloToner = dataReader.GetString("ModeloToner");
                    model.RendimentoToner = dataReader.GetInt32("RendimentoToner");

                    if (!dataReader.IsDBNull(dataReader.GetOrdinal("Fotocondutor")))
                    {
                        model.Fotocondutor = dataReader.GetString("Fotocondutor");
                    }
                    else
                    {
                        model.Fotocondutor = null;
                    }

                    //model.RendimentoFotocondutor = dataReader.GetInt32("RendimentoFotocondutor");
                    //model.QtdToner = dataReader.GetInt32("QtdToner");
                    //model.VolumeImpressao = dataReader.GetDouble("VolumeImpressao");
                    //model.UnitTonerReais = dataReader.GetDecimal("UnitTonerReais");
                    //model.UnitFotoReais = dataReader.GetDecimal("UnitFotoReais");
                    //model.TotalTonerReais = dataReader.GetDecimal("TotalTonerReais");
                    //model.TotalFotoReais = dataReader.GetDecimal("TotalFotoReais");

                    impressoras.Add(model);
                }

            }
            finally
            {

                _connection.Close();
            }

            return impressoras;
        }

        public ImpressoraModel GetImpressora(int id)
        {

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * from impressora where ImpressoraID = @ID";
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Connection = (SqlConnection)_connection;

                _connection.Open();

                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {

                    ImpressoraModel model = new ImpressoraModel();
                    model.ImpressoraID = dataReader.GetInt32("ImpressoraID");
                    model.Nome = dataReader.GetString("Nome");
                    model.ModeloToner = dataReader.GetString("ModeloToner");
                    model.RendimentoToner = dataReader.GetInt32("RendimentoToner");

                    if (!dataReader.IsDBNull(dataReader.GetOrdinal("Fotocondutor")))
                    {
                        model.Fotocondutor = dataReader.GetString("Fotocondutor");
                    }
                    else
                    {
                        model.Fotocondutor = null;
                    }

                    return model;
                }

            }
            finally
            {

                _connection.Close();

            }
            return null;
        }

        public void AddImpressora(ImpressoraModel model)
        {
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Impressora(ImpressoraID, Nome, ModeloToner, RendimentoToner, Fotocondutor, RendimentoFotocondutor, QtdToner, QtdFoto, VolumeImpressao, UnitTonerReais, UnitFotoReais, TotalTonerReais, TotalFotoReais)" +
                    " VALUES (@ImpressoraID, @Nome, @ModeloToner, @RendimentoToner, @Fotocondutor, @RendimentoFotocondutor, @QtdToner, @QtdFoto, @VolumeImpressao, @UnitTonerReais, @UnitFotoReais, @TotalTonerReais, @TotalFotoReais)";
                cmd.Connection = (SqlConnection)_connection;

                cmd.Parameters.AddWithValue("@ImpressoraID", model.ImpressoraID);
                cmd.Parameters.AddWithValue("@Nome", model.Nome);
                cmd.Parameters.AddWithValue("@ModeloToner", model.ModeloToner);
                cmd.Parameters.AddWithValue("@RendimentoToner", model.RendimentoToner);
                cmd.Parameters.AddWithValue("@Fotocondutor", model.Fotocondutor);
                cmd.Parameters.AddWithValue("@RendimentoFotocondutor", model.RendimentoFotocondutor);
                cmd.Parameters.AddWithValue("@QtdToner", model.QtdToner);
                cmd.Parameters.AddWithValue("@QtdFoto", model.QtdFoto);
                cmd.Parameters.AddWithValue("@VolumeImpressao", model.VolumeImpressao);
                cmd.Parameters.AddWithValue("@UnitTonerReais", model.UnitTonerReais);
                cmd.Parameters.AddWithValue("@UnitFotoReais", model.UnitFotoReais);
                cmd.Parameters.AddWithValue("@TotalTonerReais", model.TotalTonerReais);
                cmd.Parameters.AddWithValue("@TotalFotoReais", model.TotalFotoReais);

                _connection.Open();

                cmd.ExecuteNonQuery();

            }
            finally
            {

                _connection.Close();

            }
        }
    }

}
